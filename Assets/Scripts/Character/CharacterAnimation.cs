using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator = null;

    private float isRun = 1;

    void Start()
    {
        _animator = GetComponent<Animator>();
        // EventManager.StartListening("PlayerJump", Jump);
        EventManager.StartListening("CharacterIsRun", IsRun);
        EventManager.StartListening("CharacterIsWalk", IsWalk);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (InputManager.Instance.Horizontal != 0 || InputManager.Instance.Vertical != 0)
        {
            _animator.SetBool("IsMove", true);
        }
        else
        {
            _animator.SetBool("IsMove", false);
        }

        float hInputValue = InputManager.Instance.Horizontal * isRun;
        float vInputValue = InputManager.Instance.Vertical * isRun;

        _animator.SetFloat("xDir", hInputValue);
        _animator.SetFloat("yDir", vInputValue);
    }

    private void IsRun()
    {
        isRun = 2;
    }

    private void IsWalk()
    {
        isRun = 1;
    }

    // private void Jump()
    // {
    //     _animator.SetTrigger("Jump");
    // }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator = null;

    void Start()
    {
        _animator = GetComponent<Animator>();
        // EventManager.StartListening("PlayerJump", Jump);
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
        _animator.SetFloat("xDir", InputManager.Instance.Horizontal);
        _animator.SetFloat("yDir", InputManager.Instance.Vertical);
    }

    // private void Jump()
    // {
    //     _animator.SetTrigger("Jump");
    // }
}

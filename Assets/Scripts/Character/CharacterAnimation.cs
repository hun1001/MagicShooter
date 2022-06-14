using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator = null;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (InputManager.Instance.Horizontal != 0 || InputManager.Instance.Vertical != 0)
        {
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
    }
}

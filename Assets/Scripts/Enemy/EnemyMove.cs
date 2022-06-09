using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float _speed = 10.0f;
    private Transform _target = null;
    private Rigidbody _rigidbody = null;


    void Start()
    {
        _target = FindObjectOfType<CharacterMove>().transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    void Move()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;

    private Transform _target = null;
    private Rigidbody _rigidbody = null;
    private EnemyEyes _eyes = null;

    public enum EnemyState
    {
        Idle,
        Chase
    }

    public EnemyState state = EnemyState.Idle;

    void Start()
    {
        _target = FindObjectOfType<CharacterMove>().transform;
        _rigidbody = GetComponent<Rigidbody>();
        _eyes = GetComponent<EnemyEyes>();
    }

    void Update()
    {
        switch (state)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.Chase:
                Move();
                break;
        }
    }

    void Move()
    {
        Vector3 move = (_target.position - transform.position).normalized;
        _rigidbody.MovePosition(_rigidbody.position + move * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            _rigidbody.AddForce(other.transform.position * -1, ForceMode.Impulse);
        }
    }
}

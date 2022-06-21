using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyes : EnemyBase
{
    [SerializeField]
    private float _viewDistance = 15f;
    private Transform _target = null;

    void Start()
    {
        _target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        CheckTarget();
    }

    void CheckTarget()
    {
        if (_target != null)
        {
            if (Vector3.Distance(transform.position, _target.position) < _viewDistance)
            {
                _brain.OnCkTarget(_target.gameObject);
            }
        }
    }
}

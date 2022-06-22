using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyBase
{
    [Header("Fight properties")]
    private float _hp = 50;
    private float _attackRange = 1.5f;
    private float _attackDamage = 10.0f;

    void SetAtk()
    {
        float distance = Vector3.Distance(_brain._targetTransform.position, transform.position);
        if (distance > _attackRange + 0.5f)
        {
            _brain._state = EnemyState.CHASE;
        }
    }

    public void Damaged(float damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            _brain._state = EnemyState.DEATH;
        }
    }
}

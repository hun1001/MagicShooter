using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyBase
{
    [Header("Fight properties")]
    private float _hp = 50;
    private float _attackRange = 1.5f;
    private float _attackDamage = 10.0f;

    private bool _isAttacking = false;

    void Start()
    {
        EventManager.StartListening("EnemyAttack", SetAtk);
    }

    void SetAtk()
    {
        float distance = Vector3.Distance(_brain._targetTransform.position, transform.position);
        if (distance > _attackRange + 0.5f)
        {
            _brain.State = EnemyState.CHASE;
        }
        else
        {
            Attack();
        }
    }

    private void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        CharacterManager.Instance.CharacterStat.Damage(_attackDamage);
        EventManager.TriggerEvent("UpdatePlayerInfoUI");
    }

    public void Damaged(float damage)
    {
        _hp -= damage;
        Debug.Log(_hp);
        if (_hp <= 0)
        {
            _brain.State = EnemyState.DEATH;
        }
    }
}

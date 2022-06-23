using System.Net.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellBase : MonoBehaviour
{

    [SerializeField]
    protected float _speed = 50f;

    [SerializeField]
    protected float _damage = 10;

    [SerializeField]
    protected GameObject _hitEffect = null;

    protected virtual void Update()
    {
        SpellMove();
    }

    protected virtual void SpellMove()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyAttack>().Damaged(_damage);
        }
        DeSpawn();
    }

    protected virtual void DeSpawn()
    {
        GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

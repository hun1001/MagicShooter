using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : SpellBase
{
    [SerializeField]
    private float _explosionDamage = 5;

    [SerializeField]
    private GameObject _rangeEffect = null;

    private SphereCollider _sphereCollider = null;

    private GameObject _firstHitObject = null;

    private void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (_firstHitObject == null)
        {
            _firstHitObject = other.gameObject;
        }

        if (other.CompareTag("Enemy"))
        {
            if (_firstHitObject == other.gameObject)
            {
                other.GetComponent<EnemyAttack>().Damaged(_damage);
            }
            else
            {
                other.GetComponent<EnemyAttack>().Damaged(_explosionDamage);
            }
        }
        DeSpawn();
    }

    protected override void DeSpawn()
    {
        GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
        GameObject rangeEffect = Instantiate(_rangeEffect, transform.position, Quaternion.identity);
        _sphereCollider.radius = 30f;
        Destroy(gameObject, 2);
    }
}

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

    private void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    protected override void DeSpawn()
    {
        GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

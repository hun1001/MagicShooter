using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : SpellBase
{
    [SerializeField]
    private float _explosionDamage = 2;

    [SerializeField]
    private float _slow = 0.5f;

    [SerializeField]
    private float _slowTime = 1f;

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
                StartCoroutine(ObjectSlow(other.gameObject, 0));
            }
            else
            {
                other.GetComponent<EnemyAttack>().Damaged(_explosionDamage);
                StartCoroutine(ObjectSlow(other.gameObject, _slow));
            }
        }
        DeSpawn();
    }

    IEnumerator ObjectSlow(GameObject obj, float slowPercent)
    {
        if (slowPercent == 0)
        {
            float temp = obj.GetComponent<EnemyMove>()._speed;
            obj.GetComponent<EnemyMove>()._speed = slowPercent;
            yield return new WaitForSeconds(2f);
            obj.GetComponent<EnemyMove>()._speed = temp;
        }
        else
        {
            obj.GetComponent<EnemyMove>()._speed *= slowPercent;
            yield return new WaitForSeconds(2f);
            obj.GetComponent<EnemyMove>()._speed /= slowPercent;
        }
    }

    protected override void DeSpawn()
    {
        GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
        GameObject rangeEffect = Instantiate(_rangeEffect, transform.position, Quaternion.identity);
        _sphereCollider.radius = 30f;
        Destroy(gameObject, 2);
    }
}

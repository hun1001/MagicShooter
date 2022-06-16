using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab = null;

    private Transform _bulletSpawn = null;

    void Start()
    {
        _bulletSpawn = transform.Find("BulletSpawnPos");
        EventManager.StartListening("PlayerFire", Fire);
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 100.0f, Color.blue);
        //Debug.DrawRay();
    }

    void Fire()
    {
        if (_bulletSpawn == null)
        {
            Debug.LogError("BulletSpawn not found");
            return;
        }
        Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
    }
}

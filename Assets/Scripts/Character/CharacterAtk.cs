using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAtk : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab = null;

    private Transform _bulletSpawn = null;

    void Start()
    {
        _bulletSpawn = GetComponent<Transform>();//transform.Find("BulletSpawn");
        EventManager.StartListening("Fire", Fire);
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 100.0f, Color.blue);
    }

    void Fire()
    {
        Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
    }
}

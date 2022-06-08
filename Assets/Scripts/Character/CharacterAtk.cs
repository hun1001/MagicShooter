using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAtk : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    void Start()
    {
        EventManager.StartListening("Fire", Fire);

    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 100.0f, Color.blue);
    }

    void Fire()
    {
        Instantiate(_bulletPrefab, transform.position, transform.rotation);
    }
}

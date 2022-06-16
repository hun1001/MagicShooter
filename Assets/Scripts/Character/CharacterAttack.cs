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
    }

    void Fire()
    {
        if (_bulletSpawn == null)
        {
            Debug.LogError("BulletSpawn not found");
            return;
        }
        Vector3 layDir = CameraManager.Instance.GetAimDirection();
        RaycastHit hit;

        Debug.DrawRay(Camera.main.transform.position, layDir * 100.0f, Color.red, 5f);
        if (Physics.Raycast(Camera.main.transform.position, layDir, out hit, 100.0f))
        {
            layDir = hit.point - _bulletSpawn.position;
        }

        if (Physics.Raycast(_bulletSpawn.position, layDir, out hit, 100.0f))
        {
            layDir = hit.point - _bulletSpawn.position;
            Debug.Log(hit.point);
            Debug.DrawRay(_bulletSpawn.position, layDir * 100.0f, Color.blue, 5f);
        }

        GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.LookRotation(layDir));
    }
}

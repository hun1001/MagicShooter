using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab = null;

    private Transform _bulletSpawn = null;
    private RaycastHit hit;

    public WeaponBase _weapon { get; private set; } = null;

    void Start()
    {
        _weapon = transform.GetComponentInChildren<WeaponBase>();
        _bulletSpawn = _weapon._bulletSpawn;
        EventManager.StartListening("PlayerFire", Fire);
        EventManager.StartListening("PlayerReload", Reload);
    }

    void Update()
    {
        //Debug.DrawRay(transform.position, transform.forward * 100.0f, Color.blue);
    }

    void Fire()
    {
        if (_bulletSpawn == null)
        {
            Debug.LogError("BulletSpawn not found");
            return;
        }
        Vector3 layDir = CameraManager.Instance.GetAimDirection();

        if (Physics.Raycast(Camera.main.transform.position, layDir, out hit, 100.0f))
        {
            layDir = hit.point - _bulletSpawn.position;
        }

        if (Physics.Raycast(_bulletSpawn.position, layDir, out hit, 100.0f))
        {
            layDir = hit.point - _bulletSpawn.position;
        }

        //GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.LookRotation(layDir));
        _weapon.Fire(_bulletPrefab, layDir);
    }

    void Reload()
    {
        _weapon.Reload();
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.normal.textColor = Color.black;

        GUI.Label(new Rect(10, 10, 300, 100), "Hit point" + hit.point, style);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField]
    protected int _maxAmmo = 0;

    [SerializeField]
    protected GameObject _bulletPrefab = null;

    protected abstract void Fire();

    protected abstract void Reload();
}

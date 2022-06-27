using UnityEngine;
using System.Collections.Generic;

public abstract class WeaponBase : MonoBehaviour
{
    public int _maxAmmo = 0;

    public int _currentAmmo { get; protected set; }

    [SerializeField]
    protected float _distance = 20f;

    [SerializeField]
    protected float _reloadTime = 0.5f;

    public Transform _bulletSpawn { get; protected set; } = null;

    public Sprite _sprite = null;

    protected bool _isReload = false;

    private List<GameObject> _useBullet = null;

    protected virtual void Awake()
    {
        _bulletSpawn = transform.parent.parent.transform.Find("BulletSpawnPos");
        _useBullet = new List<GameObject>();
        _isReload = false;
    }

    protected virtual void Update()
    {
        _useBullet.ForEach((bullet) =>
        {
            if (Vector3.Distance(transform.position, bullet.transform.position) >= _distance)
            {
                _useBullet.Remove(bullet);
                Destroy(bullet);
            }
        });
    }

    protected void AddUseBullet(GameObject bullet)
    {
        _useBullet.Add(bullet);
    }

    public abstract void Fire(GameObject bulletPrefab, Vector3 direction);

    public abstract void Reload();
}

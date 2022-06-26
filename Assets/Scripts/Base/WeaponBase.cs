using UnityEngine;

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

    protected virtual void Awake()
    {
        _bulletSpawn = transform.parent.parent.transform.Find("BulletSpawnPos");
        _isReload = false;
    }

    public abstract void Fire(GameObject bulletPrefab, Vector3 direction);

    public abstract void Reload();
}

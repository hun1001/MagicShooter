using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField]
    protected int _maxAmmo = 0;

    public Transform _bulletSpawn { get; protected set; } = null;

    public Sprite _sprite = null;

    protected virtual void Awake()
    {
        _bulletSpawn = transform.parent.transform.Find("BulletSpawnPos");
    }

    public abstract void Fire(GameObject bulletPrefab, Vector3 direction);

    public abstract void Reload();
}

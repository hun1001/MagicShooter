using UnityEngine;

public class Rifle : WeaponBase
{
    public override void Fire(GameObject bulletPrefab, Vector3 direction)
    {
        Debug.Log("Rifle.Fire()");
        GameObject bullet = Instantiate(bulletPrefab, _bulletSpawn.position, Quaternion.LookRotation(direction));
    }

    public override void Reload()
    {
        Debug.Log("Rifle.Reload()");
    }
}

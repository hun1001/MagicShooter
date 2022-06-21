using UnityEngine;

public class Rifle : WeaponBase
{
    public override void Fire(GameObject bulletPrefab, Vector3 direction)
    {
        Debug.Log("Rifle.Fire()");
    }

    public override void Reload()
    {
        Debug.Log("Rifle.Reload()");
    }
}

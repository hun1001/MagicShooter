using UnityEngine;

public class Pistol : WeaponBase
{
    public override void Fire(GameObject bulletPrefab, Vector3 direction)
    {
        Debug.Log("Pistol.Fire()");
    }

    public override void Reload()
    {
        Debug.Log("Pistol.Reload()");
    }
}

using System.Collections;
using UnityEngine;

public class Rifle : WeaponBase
{
    public override void Fire(GameObject bulletPrefab, Vector3 direction)
    {
        if (_isReload || _currentAmmo <= 0)
        {
            CharacterManager.Instance.CharacterStat.UseMana(10);
            return;
        }
        GameObject bullet = Instantiate(bulletPrefab, _bulletSpawn.position, Quaternion.LookRotation(direction));
        _currentAmmo--;
        EventManager.TriggerEvent("UpdatePlayerInfoUI");
    }

    public override void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        if (!_isReload)
        {
            _isReload = true;
            yield return new WaitForSeconds(_reloadTime);
            _currentAmmo = _maxAmmo;
            _isReload = false;
            EventManager.TriggerEvent("UpdatePlayerInfoUI");
        }
    }
}

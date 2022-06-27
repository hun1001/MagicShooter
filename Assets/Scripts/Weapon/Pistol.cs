using System;
using System.Collections;
using UnityEngine;

public class Pistol : WeaponBase
{
    private bool _wasFire = false;
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _wasFire = false;
        }
    }

    public override void Fire(GameObject bulletPrefab, Vector3 direction)
    {
        if (_wasFire)
            return;

        _wasFire = true;
        if (_isReload || _currentAmmo <= 0)
        {
            UIManager.Instance.ErrorText("Please Reload you're using mana");
            if (CharacterManager.Instance.CharacterStat.MP <= 5)
                return;
            CharacterManager.Instance.CharacterStat.UseMana(5);
            _currentAmmo++;
        }
        GameObject bullet = Instantiate(bulletPrefab, _bulletSpawn.position, Quaternion.LookRotation(direction));
        _currentAmmo--;
        //AddUseBullet(bullet);
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

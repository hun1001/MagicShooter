using System.Collections;
using UnityEngine;

public class Rifle : WeaponBase
{
    [SerializeField]
    private float _delay = 0.05f;
    private bool _isFire = false;

    public override void Fire(GameObject bulletPrefab, Vector3 direction)
    {
        StartCoroutine(FireCoroutine(bulletPrefab, direction));
    }

    public override void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    public IEnumerator FireCoroutine(GameObject bulletPrefab, Vector3 direction)
    {
        if (!_isFire)
        {
            if (_isReload || _currentAmmo <= 0)
            {
                if (CharacterManager.Instance.CharacterStat.MP >= 10)
                {
                    _isFire = true;
                    CharacterManager.Instance.CharacterStat.UseMana(10);
                    _currentAmmo++;
                    GameObject bullet = Instantiate(bulletPrefab, _bulletSpawn.position, Quaternion.LookRotation(direction));
                    _currentAmmo--;
                    EventManager.TriggerEvent("UpdatePlayerInfoUI");
                    yield return new WaitForSeconds(_delay);
                    _isFire = false;
                }
            }
            else
            {
                _isFire = true;
                GameObject bullet = Instantiate(bulletPrefab, _bulletSpawn.position, Quaternion.LookRotation(direction));
                _currentAmmo--;
                EventManager.TriggerEvent("UpdatePlayerInfoUI");
                yield return new WaitForSeconds(_delay);
                _isFire = false;
            }
        }
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

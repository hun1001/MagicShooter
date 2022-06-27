using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoSingleton<ShopManager>
{
    [SerializeField]
    private GameObject SpellRockParents = null;

    [SerializeField]
    private GameObject WeaponContent = null;

    private Image[] _spellRocks = null;
    private List<Image> _weaponList = null;

    private WeaponUseState[] _canUseWeapon;

    void Awake()
    {
        _spellRocks = SpellRockParents.transform.GetComponentsInChildren<Image>();
        _weaponList = WeaponContent.GetComponentsInChildren<Image>().ToList();

        _weaponList = new List<Image>();

        _weaponList.Add(WeaponContent.transform.GetChild(0).GetComponent<Image>());
        _weaponList.Add(WeaponContent.transform.GetChild(1).GetComponent<Image>());

        _canUseWeapon = new WeaponUseState[_weaponList.Count];
        for (int i = 0; i < _weaponList.Count; ++i)
        {
            _canUseWeapon[i] = WeaponUseState.NONE;
        }
    }

    void Start()
    {
        CharacterManager.Instance.CharacterStat._money += 100;
        SelectWeapon(0);
        SelectWeapon(0);
    }

    public void UnRockSpell(int type)
    {
        if (CharacterManager.Instance.CharacterStat.LEVEL > 10)
        {
            CharacterManager.Instance.CharacterStat.UseLevel(10);
            _spellRocks[(int)type].enabled = false;
            SpellManager.Instance.SetSpell((SpellType)type, true);
            EventManager.TriggerEvent("UpdatePlayerInfoUI");
        }
        else
        {
            UIManager.Instance.ErrorText("You need more level");
        }
    }

    public void SelectWeapon(int type)
    {
        Debug.Log("SelectWeapon");
        if (_canUseWeapon[type] == WeaponUseState.NONE)
        {
            BuyWeapon(type);
        }
        else if (_canUseWeapon[type] == WeaponUseState.HAVING)
        {
            _canUseWeapon[type] = WeaponUseState.USING;
            GameObject temp = CharacterManager.Instance.CharacterAttack._weapon.gameObject.gameObject.transform.parent.gameObject;
            CharacterManager.Instance.CharacterAttack.SetWeapon(null);
            Destroy(temp.transform.GetChild(0).gameObject);
            GameObject weaponTemp;
            Debug.Log((WeaponType)type);
            switch ((WeaponType)type)
            {
                case WeaponType.PISTOL:
                    weaponTemp = Resources.Load<GameObject>("Prefabs/Weapon/Pistol");
                    break;
                case WeaponType.RIFLE:
                    weaponTemp = Resources.Load<GameObject>("Prefabs/Weapon/Rifle");
                    break;
                default:
                    weaponTemp = null;
                    break;
            }

            weaponTemp = Instantiate(weaponTemp, temp.transform);
            weaponTemp.GetComponent<SkinnedMeshRenderer>().rootBone = CharacterManager.Instance.transform.Find("Hips");
            CharacterManager.Instance.CharacterAttack.SetWeapon(weaponTemp.GetComponent<WeaponBase>());
            EventManager.TriggerEvent("UpdatePlayerInfoUI");
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < _weaponList.Count; ++i)
        {
            switch (_canUseWeapon[i])
            {
                case WeaponUseState.HAVING:
                    _weaponList[i].color = new Color(1f, 1f, 1f, 1f);
                    break;
                case WeaponUseState.USING:
                    _weaponList[i].color = new Color(0.5f, 0.5f, 0.5f, 1f);
                    break;
                case WeaponUseState.NONE:
                    _weaponList[i].color = new Color(0.9f, 0.4f, 0.4f, 1f);
                    break;
            }
        }
    }

    private void BuyWeapon(int type)
    {
        if (CharacterManager.Instance.CharacterStat._money >= 100)
        {
            CharacterManager.Instance.CharacterStat._money -= 100;
            _canUseWeapon[type] = WeaponUseState.HAVING;
            EventManager.TriggerEvent("UpdatePlayerInfoUI");
        }
        else
        {
            UIManager.Instance.ErrorText("You don't have money");
        }
    }
}

using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterUIController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private Image _playerInfo = null;

    private Image _hpBar = null;
    private Image _mpBar = null;

    private TextMeshProUGUI _levelText = null;
    private Image _weaponImage = null;
    private TextMeshProUGUI _ammoText = null;

    private CharacterStat _stat = null;
    private CharacterAttack _attack = null;

    [SerializeField]
    private TextMeshProUGUI _money = null;

    [SerializeField]
    private Image _shopWeaponImage = null;

    void Awake()
    {
        _stat = CharacterManager.Instance.CharacterStat;
        _attack = CharacterManager.Instance.CharacterAttack;
        _hpBar = _playerInfo.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        _mpBar = _playerInfo.transform.GetChild(0).GetChild(1).GetComponent<Image>();
        _levelText = _playerInfo.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        _weaponImage = _playerInfo.transform.parent.GetChild(2).GetComponent<Image>();
        _ammoText = _playerInfo.transform.parent.GetChild(3).GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        UpdatePlayerInfoUI();
        EventManager.StartListening("UpdatePlayerInfoUI", UpdatePlayerInfoUI);
    }

    private void UpdatePlayerInfoUI()
    {
        _hpBar.fillAmount = _stat.HP / _stat.MAXHP;
        _mpBar.fillAmount = _stat.MP / _stat.MAXMP;
        _levelText.text = _stat.LEVEL.ToString();
        _weaponImage.sprite = _attack._weapon._sprite;
        _shopWeaponImage.sprite = _attack._weapon._sprite;
        _ammoText.text = $"{_attack._weapon._currentAmmo}/{_attack._weapon._maxAmmo}";
        _money.text = $"money : {CharacterManager.Instance.CharacterStat._money}";
    }
}

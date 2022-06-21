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

    private CharacterStat _stat = null;

    void Awake()
    {
        _stat = GetComponent<CharacterStat>();
        _hpBar = _playerInfo.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        _mpBar = _playerInfo.transform.GetChild(0).GetChild(1).GetComponent<Image>();
        _levelText = _playerInfo.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void UpdatePlayerInfoUI()
    {
        _hpBar.fillAmount = _stat.HP / _stat.MAXHP;
        _mpBar.fillAmount = _stat.MP / _stat.MAXMP;
        _levelText.text = _stat.LEVEL.ToString();
    }
}

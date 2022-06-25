using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private GameObject SpellRockParents = null;

    private Image[] _spellRocks = null;

    void Start()
    {
        _spellRocks = SpellRockParents.transform.GetComponentsInChildren<Image>();
    }


    public void UnRockSpell(int type)
    {
        // TODO : 구매 추가 재화 사라지게 만들기
        _spellRocks[(int)type].enabled = false;
        SpellManager.Instance.SetSpell((SpellType)type, true);
        EventManager.TriggerEvent("UpdatePlayerInfoUI");
    }
}

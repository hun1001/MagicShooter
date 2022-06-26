using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private GameObject SpellRockParents = null;

    private Image[] _spellRocks = null;

    void Awake()
    {
        _spellRocks = SpellRockParents.transform.GetComponentsInChildren<Image>();
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
}

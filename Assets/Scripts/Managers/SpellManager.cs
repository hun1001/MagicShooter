using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SpellManager : MonoSingleton<SpellManager>
{
    private bool[] _spellUseState;

    [SerializeField]
    private GameObject Spells;

    private Image[] _spellImages;

    private SpellType _usingSpell;

    void Start()
    {
        _usingSpell = SpellType.MPBALL;

        _spellImages = Spells.GetComponentsInChildren<Image>();
        EventManager.StartListening("UpdatePlayerInfoUI", SpellImagesUpdate);
        EventManager.TriggerEvent("UpdatePlayerInfoUI");
    }

    void ChangeSpell(SpellType type)
    {

    }

    public void SetSpell(SpellType type, bool state)
    {
        _spellUseState[(int)type] = state;
    }

    void SpellImagesUpdate()
    {
        for (int i = 0; i < 3; ++i)
        {
            if (_spellUseState[i])
            {
                _spellImages[i].DOFade(1, 2f);
            }
            else
            {
                _spellImages[i].DOFade(0, 0.1f);
            }
        }
    }
}

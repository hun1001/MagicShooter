using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoSingleton<SpellManager>
{
    private bool _mpBall;
    private bool _fireBall;
    private bool _iceBall;

    [SerializeField]
    private GameObject Spells;

    private Image[] _spellImages;

    void Start()
    {
        _spellImages = GetComponentsInChildren<Image>();
        EventManager.StartListening("UpdatePlayerInfoUI", SpellImagesUpdate);
    }

    void SpellImagesUpdate()
    {
        if (_mpBall)
        {

        }
        if (_fireBall)
        {

        }
        if (_iceBall)
        {

        }
    }
}

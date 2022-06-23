using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public int LEVEL => _level;
    public float HP => _hp;
    public float MP => _mp;
    public float MAXHP => _maxHP;
    public float MAXMP => _maxMP;

    private int _level = 1;
    private float _hp = 100;
    private float _maxHP = 100;
    private float _mp = 100;
    private float _maxMP = 100;

    private void Start()
    {
        _hp = _maxHP;
        _mp = _maxMP;
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.normal.textColor = Color.black;

        GUI.Label(new Rect(10, 90, 300, 100), $"Character HP : {_hp}", style);
    }

    public void LevelUp()
    {
        _level++;
        _maxHP += 10;
        _maxMP += 10;
        _hp = _maxHP;
        _mp = _maxMP;
    }

    public void Damage(float damage)
    {
        _hp -= damage;
        if (_hp < 0)
        {
            _hp = 0;
        }
    }

    public void Heal(float heal)
    {
        _hp += heal;
        if (_hp > _maxHP)
        {
            _hp = _maxHP;
        }
    }

    public void AddMana(float mana)
    {
        _mp += mana;
        if (_mp > _maxMP)
        {
            _mp = _maxMP;
        }
    }

    public void UseMana(float mana)
    {
        _mp -= mana;
        if (_mp < 0)
        {
            _mp = 0;
        }
    }
}

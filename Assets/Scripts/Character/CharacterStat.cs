using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public float HP => _hp;
    public float MP => _mp;

    private float _hp = 100;
    private float _maxHp = 100;
    private float _mp = 100;
    private float _maxMp = 100;

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
        if (_hp > _maxHp)
        {
            _hp = _maxHp;
        }
    }

    public void AddMana(float mana)
    {
        _mp += mana;
        if (_mp > _maxMp)
        {
            _mp = _maxMp;
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

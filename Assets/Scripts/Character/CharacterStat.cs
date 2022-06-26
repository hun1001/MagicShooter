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

    // 이거 여기 넣으면 안되지만 시간 이슈로 걍 여기 넣자 그리고 public으로 해도 안됨
    public int _money = 100;

    private bool _isDamaged = false;

    private void Start()
    {
        _hp = _maxHP;
        _mp = _maxMP;
        _money = 100;
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.normal.textColor = Color.black;
        GUI.Label(new Rect(10, 90, 300, 100), $"Character HP : {_hp}", style);
    }

    public void LevelUp(int value = 1)
    {
        _level += value;
        _maxHP += 10;
        _maxMP += 10;
        _hp = _maxHP;
        _mp = _maxMP;
        EventManager.TriggerEvent("UpdatePlayerInfoUI");
    }

    public void UseLevel(int value = 1)
    {
        _level -= value;
        EventManager.TriggerEvent("UpdatePlayerInfoUI");
    }

    public void Damage(float damage)
    {
        if (!_isDamaged)
        {
            StartCoroutine(DamageCoroutine(damage));
        }
    }

    private IEnumerator DamageCoroutine(float damage)
    {
        _isDamaged = true;
        _hp -= damage;
        yield return new WaitForSeconds(2f);
        if (_hp <= 0)
        {
            CharacterManager.Instance.Dead();
            _hp = 0;
        }
        _isDamaged = false;
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

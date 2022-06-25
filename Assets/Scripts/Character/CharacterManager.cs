using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoSingleton<CharacterManager>
{
    public CharacterStat CharacterStat => _characterStat;
    public CharacterAttack CharacterAttack => _characterAttack;

    private CharacterStat _characterStat = null;
    private CharacterAttack _characterAttack = null;

    void Awake()
    {
        _characterStat = GetComponent<CharacterStat>();
        _characterAttack = GetComponent<CharacterAttack>();
    }

    public void Dead()
    {
        EventManager.TriggerEvent("CharacterDie");
        EventManager.TriggerEvent("GameOver");
    }
}

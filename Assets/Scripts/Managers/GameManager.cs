using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    void Start()
    {
        MouseManager.Lock(true);
        MouseManager.Show(false);

        CharacterManager.Instance.CharacterStat.LevelUp(10);
        FindObjectOfType<ShopManager>().UnRockSpell((int)SpellType.MPBALL);

        EventManager.StartListening("GameOver", GameOver);
    }

    private void GameOver()
    {
        StartCoroutine(StopTimeCoroutine());
        MouseManager.Lock(false);
        MouseManager.Show(true);
    }

    private IEnumerator StopTimeCoroutine()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public int score;

    void Start()
    {
        MouseManager.Lock(true);
        MouseManager.Show(false);

        score = 0;

        CharacterManager.Instance.CharacterStat.LevelUp(10);
        FindObjectOfType<ShopManager>().UnRockSpell((int)SpellType.MPBALL);

        EventManager.StartListening("GameOver", GameOver);
        StartCoroutine(Setting());
    }

    private IEnumerator Setting()
    {
        yield return null;
        EventManager.TriggerEvent("UseMPSpell");
        EventManager.TriggerEvent("PlayerReload");
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

    public void ExitGame()
    {
        Application.Quit();
    }
}

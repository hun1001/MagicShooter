using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        MouseManager.Lock(true);
        MouseManager.Show(false);
        EventManager.StartListening("GameOver", GameOver);
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        MouseManager.Lock(false);
        MouseManager.Show(true);
    }
}

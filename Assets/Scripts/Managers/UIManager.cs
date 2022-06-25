using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Canvas _gamePlayCanvas;

    [SerializeField]
    private Canvas _inventoryCanvas;

    [SerializeField]
    private Canvas _gameOverCanvas = null;

    void Start()
    {
        _gamePlayCanvas.enabled = true;
        _inventoryCanvas.enabled = false;
        _gameOverCanvas.enabled = false;

        EventManager.StartListening("ChangeCanvas", ChangeCanvas);
        EventManager.StartListening("GameOver", GameOver);
    }

    private void ChangeCanvas()
    {
        _gamePlayCanvas.enabled = !_gamePlayCanvas.enabled;
        _inventoryCanvas.enabled = !_inventoryCanvas.enabled;
    }

    private void OnInventory()
    {
        _gamePlayCanvas.enabled = false;
        _inventoryCanvas.enabled = true;
    }

    private void GameOver()
    {
        _gameOverCanvas.enabled = true;
        _inventoryCanvas.enabled = false;
        _gamePlayCanvas.enabled = false;
    }
}

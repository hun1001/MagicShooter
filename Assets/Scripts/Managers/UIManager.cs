using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField]
    private Canvas _gamePlayCanvas;

    [SerializeField]
    private Canvas _inventoryCanvas;

    [SerializeField]
    private Canvas _gameOverCanvas = null;

    [SerializeField]
    private Text _errorText = null;

    void Start()
    {
        _gamePlayCanvas.enabled = true;
        _inventoryCanvas.enabled = false;
        _gameOverCanvas.enabled = false;

        EventManager.StartListening("ChangeCanvas", ChangeCanvas);
        EventManager.StartListening("GameOver", GameOver);
    }

    public void ErrorText(string text)
    {
        StartCoroutine(ErrorTextCoroutine(text));
    }

    private void ChangeCanvas()
    {
        MouseManager.Show(!Cursor.visible);
        MouseManager.Lock(Cursor.lockState == CursorLockMode.Locked ? false : true);
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

    private IEnumerator ErrorTextCoroutine(string text)
    {
        _errorText.text = text;
        yield return new WaitForSeconds(1.5f);
        _errorText.text = "";
    }
}

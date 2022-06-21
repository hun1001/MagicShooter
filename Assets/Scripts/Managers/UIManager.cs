using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Canvas _GamePlayCanvas;

    [SerializeField]
    private Canvas _inventoryCanvas;

    void Start()
    {
        _GamePlayCanvas.enabled = true;
        _inventoryCanvas.enabled = false;
        EventManager.StartListening("ChangeCanvas", ChangeCanvas);
    }

    private void ChangeCanvas()
    {
        _GamePlayCanvas.enabled = !_GamePlayCanvas.enabled;
        _inventoryCanvas.enabled = !_inventoryCanvas.enabled;
    }

    private void OnInventory()
    {
        _GamePlayCanvas.enabled = false;
        _inventoryCanvas.enabled = true;
    }
}

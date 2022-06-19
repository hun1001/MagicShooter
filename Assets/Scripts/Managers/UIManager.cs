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
    }

    void Update()
    {

    }
}

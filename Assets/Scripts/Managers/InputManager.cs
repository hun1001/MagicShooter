using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    [Tooltip("Mouse Sensitivity")]
    [SerializeField]
    private float _mouseSensitivity = 50.0f;

    public float Horizontal => _horizontal;
    public float Vertical => _vertical;
    public Vector2 MouseMovement => _mouseMovement;

    private float _horizontal;
    private float _vertical;

    private Vector2 _mouseMovement;

    void Update()
    {
        UpdateHorizontal();
        UpdateVertical();
        UpdateMouseMovement();
        if (Input.GetMouseButtonDown(0))
        {
            EventManager.TriggerEvent("PlayerFire");
        }
        if (Input.GetMouseButtonDown(1))
        {
            EventManager.TriggerEvent("Zoom");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // EventManager.TriggerEvent("PlayerJump");
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            EventManager.TriggerEvent("ChangeCanvas");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            EventManager.TriggerEvent("PlayerReload");
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            EventManager.TriggerEvent("CharacterIsRun");
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            EventManager.TriggerEvent("CharacterIsWalk");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EventManager.TriggerEvent("UseMPSpell");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EventManager.TriggerEvent("UseFireBall");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EventManager.TriggerEvent("UseIceBall");
        }
    }

    private void UpdateHorizontal()
    {
        _horizontal = Input.GetAxis("Horizontal");
    }

    private void UpdateVertical()
    {
        _vertical = Input.GetAxis("Vertical");
    }

    private void UpdateMouseMovement()
    {
        _mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        _mouseMovement = Vector2.Scale(_mouseMovement, new Vector2(_mouseSensitivity, _mouseSensitivity));
    }
}

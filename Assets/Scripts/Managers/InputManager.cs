using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    public float Horizontal => _horizontal;
    public float Vertical => _vertical;
    public Vector2 MouseMovement => _mouseMovement;

    private float _horizontal;
    private float _vertical;

    private Vector2 _mouseMovement;

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}

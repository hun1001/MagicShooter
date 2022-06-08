using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;

    [SerializeField]
    private float _sensitivity = 45.0f;

    private CharacterController _controller;

    private Camera _camera;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        // Rotate();
    }

    private void Move()
    {
        float x = InputManager.Instance.Horizontal;
        float z = InputManager.Instance.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;

        _controller.Move(move * _speed * Time.deltaTime);
    }

    private void Rotate()
    {
        float y = Input.GetAxis("Mouse X");

        Vector3 rotation = new Vector3(0, y, 0);

        transform.Rotate(rotation * _sensitivity * Time.deltaTime);
    }
}

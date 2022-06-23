using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]
    private float _walkSpeed = default;

    [SerializeField]
    private float _runSpeed = default;

    private float _usingSpeed = default;

    // [SerializeField]
    // private float _jumpForce = default;

    private CharacterController _controller = null;

    private CollisionFlags _collisionFlags = CollisionFlags.None;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _usingSpeed = _walkSpeed;
        //EventManager.StartListening("PlayerJump", Jump);
        EventManager.StartListening("CharacterIsRun", SelectRunSpeed);
        EventManager.StartListening("CharacterIsWalk", SelectWalkSpeed);
    }

    void Update()
    {
        Move();
        Rotate();
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.normal.textColor = Color.black;

        GUI.Label(new Rect(10, 60, 300, 100), $"Pos {transform.position}", style);
    }

    private void Move()
    {
        float x = InputManager.Instance.Horizontal;
        float z = InputManager.Instance.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;

        move -= AddGravity();

        _collisionFlags = _controller.Move(move * _usingSpeed * Time.deltaTime);
    }

    void SelectWalkSpeed()
    {
        _usingSpeed = _walkSpeed;
    }

    void SelectRunSpeed()
    {
        _usingSpeed = _runSpeed;
    }

    // 게임에 안어울려서 일단 제외
    // private void Jump()
    // {
    //     _collisionFlags = _controller.Move(Vector3.up * _jumpForce * Time.deltaTime);
    // }

    private void Rotate()
    {
        float y = InputManager.Instance.MouseMovement.x;

        Vector3 rotation = new Vector3(0, y, 0);

        transform.Rotate(rotation * Time.deltaTime);
    }

    Vector3 AddGravity()
    {
        Vector3 gravity = Vector3.zero;

        if ((_collisionFlags & CollisionFlags.Below) == 0)
        {
            gravity = Vector3.down * Physics.gravity.y * Time.deltaTime;
        }

        return gravity;
    }
}

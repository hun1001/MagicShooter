using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _distance = 10.0f;

    private Vector2 _mouseInput;

    private void Start()
    {
        if (_target == null)
        {
            Debug.LogError("Target is null");
            return;
        }
    }

    private void LateUpdate()
    {
        MoveRotate();
    }

    private void MoveRotate()
    {
        _mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        transform.LookAt(_target);

        transform.RotateAround(_target.position, Vector3.up, _mouseInput.x);
        transform.RotateAround(_target.position, Vector3.right, -_mouseInput.y);

        transform.position = _target.position - transform.forward * _distance;
    }
}

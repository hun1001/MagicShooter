using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    [SerializeField]
    private Transform _targetTransform;

    [SerializeField]
    private Vector3 _offset = Vector3.zero;

    [SerializeField]
    private float _moveDamping = 15f;

    [SerializeField]
    private float _rotateDamping = 10f;

    private void Start()
    {
        if (_targetTransform == null)
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
        Vector2 mouseMovement = Vector2.zero;

        Debug.Log(mouseMovement);

        transform.RotateAround(_targetTransform.position, Vector3.up, mouseMovement.x * _rotateDamping * Time.deltaTime);
        transform.RotateAround(_targetTransform.position, transform.right, -mouseMovement.y * _rotateDamping * Time.deltaTime);
    }
}

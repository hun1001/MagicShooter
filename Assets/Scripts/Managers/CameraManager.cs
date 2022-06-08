using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    [SerializeField]
    private Transform _targetTransform;

    [SerializeField]
    private Vector3 _offset = Vector3.zero;

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
        Vector2 mouseMovement = InputManager.Instance.MouseMovement;
        Vector3 targetPosition = _targetTransform.position + _offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private Vector3 _offset = Vector3.zero;

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
        transform.position = _target.position + _offset;

    }
}

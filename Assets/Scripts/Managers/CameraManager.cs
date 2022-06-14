using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    [SerializeField]
    private Transform _cameraTransform;

    private Transform _lookAtTransform;

    private void Start()
    {
        if (_cameraTransform == null)
        {
            Debug.LogError("Target is null");
            return;
        }
        _lookAtTransform = _cameraTransform.GetChild(0);
        EventManager.StartListening("Zoom", Zoom);
    }

    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position = _cameraTransform.position;
        transform.LookAt(_lookAtTransform);
    }

    private void Zoom()
    {
        Debug.Log("Zoom");
    }
}

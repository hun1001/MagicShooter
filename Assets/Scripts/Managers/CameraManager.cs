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

        _lookAtTransform.localPosition += new Vector3(0, InputManager.Instance.MouseMovement.y * 0.001f, 0);

        _lookAtTransform.localPosition = new Vector3(
            _lookAtTransform.localPosition.x,
            Mathf.Clamp(_lookAtTransform.localPosition.y, -1.5f, 3f),
            _lookAtTransform.localPosition.z);

        transform.LookAt(_lookAtTransform);
    }

    public Vector3 GetAimDirection()
    {
        return (_lookAtTransform.position - _cameraTransform.position).normalized;
    }

    private void Zoom()
    {
        Debug.Log("Zoom");
    }
}

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
        FirstCameraMoveRotate();
    }

    // 이거 무조건 수정하기 1인칭으로 안할꺼임
    private void FirstCameraMoveRotate()
    {
        transform.position = _targetTransform.position + _offset;
        transform.rotation = _targetTransform.rotation;
    }

    private void Move()
    {

    }

    private void Rotate()
    {
        // Vector2 mouseMovement = InputManager.Instance.MouseMovement;
        // transform.RotateAround(_targetTransform.position, _targetTransform.up, mouseMovement.x * Time.deltaTime * 50.0f);
        // transform.RotateAround(_targetTransform.position, transform.right, -mouseMovement.y * Time.deltaTime);
    }

    public void Zoom()
    {

    }
}

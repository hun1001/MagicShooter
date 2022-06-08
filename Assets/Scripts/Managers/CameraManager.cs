using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    [Range(2.0f, 20.0f)]
    private float _distance = 10.0f;

    [SerializeField]
    [Range(0.0f, 10.0f)]
    private float _height = 2f;

    [SerializeField]
    private float _moveDamping = 15f;

    [SerializeField]
    private float _rotateDamping = 10f;

    [SerializeField]
    private float _targetOffset = 2f;

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
        Vector3 pos = _target.position
                      + (-_target.forward * _distance)
                      + (_target.up * _height);

        // 카메라 위치 설정
        transform.position = Vector3.Slerp(transform.position, pos, _moveDamping * Time.deltaTime);

        // 구면 보간 : 현재 회전 -> 타겟의 회전 
        transform.rotation = Quaternion.Slerp(transform.rotation, _target.rotation, _rotateDamping * Time.deltaTime);

        transform.LookAt(_target.position + (_target.up * _targetOffset));

    }
}

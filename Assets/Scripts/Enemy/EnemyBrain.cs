using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public EnemyState _state = EnemyState.IDLE;
    private EnemyMove _move;

    public GameObject _target { get; private set; } = null;

    public Transform _targetTransform { get; private set; } = null;

    void Start()
    {
        _state = EnemyState.IDLE;
    }

    void Update()
    {
        CkState();
    }

    void OnCkTarget(GameObject target)
    {
        _target = target;
        _targetTransform = _target.transform;
        _state = EnemyState.CHASE;
    }

    void CkState()
    {
        switch (_state)
        {
            case EnemyState.IDLE:
                EventManager.TriggerEvent("EnemyIdle");
                break;
            case EnemyState.CHASE:
            case EnemyState.WALK:
                EventManager.TriggerEvent("EnemyMove");
                break;
            case EnemyState.ATTACK:
                EventManager.TriggerEvent("EnemyAttack");
                break;
            default:
                break;
        }
    }
}

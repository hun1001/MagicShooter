using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public EnemyState State
    {
        get
        {
            return _state;
        }
        set
        {
            if (_state == EnemyState.DEATH)
            {
                _state = EnemyState.DEATH;
            }
            else
            {
                _state = value;
            }
        }
    }

    private EnemyState _state;

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

    public void OnCkTarget(GameObject target)
    {
        _target = target;
        _targetTransform = _target.transform;
    }

    // 생각해 보니 적같은 경우 이벤트 매니저 말고 SendMassage사용 해야될듯 나중에 수정하기
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

    void Dead()
    {
        CharacterManager.Instance.CharacterStat.LevelUp();
        StartCoroutine(DeadCoroutine());
    }

    private IEnumerator DeadCoroutine()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(0.89f);
        Destroy(gameObject);
    }
}

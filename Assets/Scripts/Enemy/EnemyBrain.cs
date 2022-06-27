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

    private bool _isDead = false;

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
                SendMessage("SetIdle");
                break;
            case EnemyState.CHASE:
            case EnemyState.WALK:
                SendMessage("SetMove");
                break;
            case EnemyState.ATTACK:
                SendMessage("SetAtk");
                break;
            default:
                break;
        }
    }

    void Dead()
    {
        if (_isDead)
        {
            return;
        }

        _isDead = true;
        CharacterManager.Instance.CharacterStat.LevelUp();
        CharacterManager.Instance.CharacterStat._money += 10;
        EventManager.TriggerEvent("UpdatePlayerInfoUI");
        StartCoroutine(DeadCoroutine());
    }

    private IEnumerator DeadCoroutine()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(0.89f);
        EnemySpawnManager.Instance.GhoulDead(this.gameObject);
    }
}

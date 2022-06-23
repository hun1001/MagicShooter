using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyBase
{
    [SerializeField]
    private float _speed = 5.0f;

    private Vector3 _targetPos = Vector3.zero;

    void Start()
    {
        EventManager.StartListening("EnemyMove", SetMove);
        EventManager.StartListening("EnemyIdle", SetIdle);
    }

    void SetMove()
    {
        Vector3 distance = Vector3.zero;
        Vector3 posLookAt = Vector3.zero;
        Vector3 amount = Vector3.zero;
        Vector3 direction = Vector3.zero;

        switch (_brain.State)
        {
            case EnemyState.WALK:
                if (_targetPos != Vector3.zero)
                {
                    distance = _targetPos - transform.position;

                    if (distance.magnitude < 1.5f)
                    {
                        SetWait();
                        return;
                    }

                    posLookAt = new Vector3(_targetPos.x, transform.position.y, _targetPos.z);
                }
                break;
            case EnemyState.CHASE:
                if (_brain._target != null)
                {
                    distance = _brain._target.transform.position - transform.position;
                    if (distance.magnitude < 1.5f)
                    {
                        _brain.State = EnemyState.ATTACK;
                        return;
                    }
                    posLookAt = new Vector3(_brain._target.transform.position.x, transform.position.y, _brain._target.transform.position.z);
                }
                break;
            default:
                break;
        }

        direction = distance.normalized;

        direction = new Vector3(direction.x, 0, direction.z);

        amount = direction * _speed * Time.deltaTime;

        transform.Translate(amount, Space.World);

        transform.LookAt(posLookAt);
    }

    void SetWait()
    {
        StartCoroutine(SetWaitCoroutine());
    }

    IEnumerator SetWaitCoroutine()
    {
        _brain.State = EnemyState.WAIT;
        float timeWait = Random.Range(1.0f, 3.0f);
        yield return new WaitForSeconds(timeWait);
        _brain.State = EnemyState.IDLE;
    }


    void SetIdle()
    {
        if (_brain._target == null)
        {
            _targetPos = new Vector3(transform.position.x + Random.Range(-10.0f, 10.0f), transform.position.y + 1000f, transform.position.z + Random.Range(-10.0f, 10.0f));
            Ray ray = new Ray(_targetPos, Vector3.down);

            RaycastHit infoRayCast = new RaycastHit();

            if (Physics.Raycast(ray, out infoRayCast, Mathf.Infinity))
            {
                _targetPos.y = infoRayCast.point.y;
            }
            _brain.State = EnemyState.WALK;
        }
        else
        {
            _brain.State = EnemyState.CHASE;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private EnemyBrain _brain = null;

    [SerializeField]
    private float _speed = 5.0f;

    private GameObject _target = null;
    private Transform _targetTransform = null;
    private Vector3 _targetPos = Vector3.zero;

    [Header("Fight properties")]
    private float _hp = 500;
    private float _attackRange = 1.5f;
    private float _attackDamage = 10.0f;

    void Start()
    {
        _brain = GetComponent<EnemyBrain>();
        OnCkTarget(GameObject.FindGameObjectWithTag("Player"));
    }

    void Update()
    {
        CkState();
    }

    void CkState()
    {
        switch (_brain._state)
        {
            case EnemyState.Idle:
                SetIdle();
                break;
            case EnemyState.Chase:
            case EnemyState.Walk:
                SetMove();
                break;
            case EnemyState.Attack:
                SetAtk();
                break;
            default:
                break;
        }
    }

    void SetMove()
    {
        Vector3 distance = Vector3.zero;
        Vector3 posLookAt = Vector3.zero;

        switch (_brain._state)
        {
            case EnemyState.Walk:
                if (_targetPos != Vector3.zero)
                {
                    distance = _targetPos - transform.position;

                    if (distance.magnitude < _attackRange)
                    {
                        StartCoroutine(SetWait());
                        return;
                    }

                    posLookAt = new Vector3(_targetPos.x, transform.position.y, _targetPos.z);
                }
                break;
            case EnemyState.Chase:
                if (_target != null)
                {
                    distance = _target.transform.position - transform.position;
                    if (distance.magnitude < _attackRange)
                    {
                        _brain._state = EnemyState.Attack;
                        return;
                    }
                    posLookAt = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z);
                }
                break;
            default:
                break;
        }

        Vector3 direction = distance.normalized;

        direction = new Vector3(direction.x, 0, direction.z);

        Vector3 amount = direction * _speed * Time.deltaTime;

        transform.Translate(amount, Space.World);

        transform.LookAt(posLookAt);
    }

    IEnumerator SetWait()
    {
        _brain._state = EnemyState.Wait;
        float timeWait = Random.Range(1.0f, 3.0f);
        yield return new WaitForSeconds(timeWait);
        _brain._state = EnemyState.Idle;
    }

    void OnCkTarget(GameObject target)
    {
        _target = target;
        _targetTransform = _target.transform;
        _brain._state = EnemyState.Chase;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            _hp -= 10;
            if (_hp > 0)
            {
                //Instantiate(_effectDamage, other.transform.position, Quaternion.identity);

                //effectDamageTween();
            }
            else
            {
                _brain._state = EnemyState.Death;
            }
        }
    }

    void SetAtk()
    {
        float distance = Vector3.Distance(_targetTransform.position, transform.position);
        if (distance > _attackRange + 0.5f)
        {
            _brain._state = EnemyState.Chase;
        }
    }

    void SetIdle()
    {
        if (_target == null)
        {
            _targetPos = new Vector3(transform.position.x + Random.Range(-10.0f, 10.0f), transform.position.y + 1000f, transform.position.z + Random.Range(-10.0f, 10.0f));
            Ray ray = new Ray(_targetPos, Vector3.down);

            RaycastHit infoRayCast = new RaycastHit();

            if (Physics.Raycast(ray, out infoRayCast, Mathf.Infinity))
            {
                _targetPos.y = infoRayCast.point.y;
            }
            _brain._state = EnemyState.Walk;
        }
        else
        {
            _brain._state = EnemyState.Chase;
        }
    }
}

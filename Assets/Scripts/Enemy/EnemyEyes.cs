using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyes : MonoBehaviour
{
    [SerializeField]
    private float _viewDistance = 10.0f;

    [SerializeField]
    private float _viewAngle = 45.0f;

    private Transform _target = null;

    private EnemyMove _enemyMove = null;

    private bool _isView = false;

    private void Start()
    {
        _target = FindObjectOfType<CharacterMove>().transform;
        _enemyMove = GetComponent<EnemyMove>();
    }

    void Update()
    {
        if (Vector3.Dot(transform.forward, (_target.position - transform.position).normalized) > Mathf.Cos(_viewAngle * Mathf.Deg2Rad) && !_isView)
        {
            if (Vector3.Distance(transform.position, _target.position) < _viewDistance)
            {
                _isView = true;
                _enemyMove.state = EnemyMove.EnemyState.Chase;
                gameObject.SendMessageUpwards("FindTarget");
                Debug.Log("Find");
            }
        }
    }

    void ChangeState()
    {
        _enemyMove.state = EnemyMove.EnemyState.Chase;
        _isView = true;
        Debug.Log("ChangeChase");
    }

    public bool IsView()
    {
        return _isView;
    }
}

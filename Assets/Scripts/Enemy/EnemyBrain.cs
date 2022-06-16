using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public EnemyState _state;

    void Start()
    {
        _state = EnemyState.Idle;
    }

    void Update()
    {

    }
}

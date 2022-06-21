using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected EnemyBrain _brain = null;

    void Awake()
    {
        _brain = GetComponent<EnemyBrain>();
    }
}

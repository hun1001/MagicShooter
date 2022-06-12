using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    void Start()
    {
        EventManager.StartListening("PlayMoveAnimation", Move);
    }

    private void Move()
    {

    }
}

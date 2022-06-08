using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAtk : MonoBehaviour
{
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * Mathf.Infinity, Color.blue);
    }
}

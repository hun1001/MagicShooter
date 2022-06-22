using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroy : MonoBehaviour
{
    [SerializeField]
    private float _destroyTime = 1f;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(_destroyTime);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 예비로 만들어둔 스크립트 삭제하고 다시 만들 예정
/// </summary>
public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float _speed = 50.0f;
    void Start()
    {
        StartCoroutine(Pull());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    IEnumerator Pull()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}

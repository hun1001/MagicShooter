using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterSelect : MonoBehaviour
{
    void Start()
    {
        EventManager.StartListening("Check", Check);
    }

    void Check()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5.0f))
        {
            Renderer renderer = hit.transform.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                StartCoroutine(ChangeColor(renderer));
            }
        }
    }

    IEnumerator ChangeColor(Renderer renderer)
    {
        Color color = renderer.material.color;
        renderer.material.color = Color.red;
        renderer.transform.DORotate(new Vector3(0, renderer.transform.rotation.eulerAngles.y + 180, 0), 0.5f);
        yield return new WaitForSeconds(0.5f);
        renderer.material.color = color;
    }
}

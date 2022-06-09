using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        yield return new WaitForSeconds(0.5f);
        renderer.material.color = color;
    }
}

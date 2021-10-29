using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon;

    private GameObject instance;

    private void OnMouseDown()
    {
        instance = Instantiate(weapon, transform.position, transform.rotation);
        instance.GetComponent<Collider2D>().enabled = false;
    }

    private void OnMouseDrag()
    {
        instance.transform.position =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);
        instance.transform.position =
            new Vector3(instance.transform.position.x,
                instance.transform.position.y,
                0);
    }

    private void OnMouseUp()
    {
        instance.GetComponent<Collider2D>().enabled = true;
        instance.transform.position =
            new Vector3(Mathf.Round(instance.transform.position.x),
                Mathf.Round(instance.transform.position.y),
                0);
    }

    // private void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         instance =
    //             Instantiate(weapon, transform.position, transform.rotation);
    //     }
    //     if (Input.GetMouseButton(0))
    //     {
    //         Vector2 touchPos =
    //             Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         instance.transform.position = touchPos;
    //     }
    // }
}

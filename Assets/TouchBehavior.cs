using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
        }
    }
    // private void OnMouseDown()
    // {
    //     Instantiate(weapon, transform.position, Quaternion.identity);
    // }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy (gameObject);
        }
    }
    // private void OnMouseDown()
    // {
    //     Instantiate(weapon, transform.position, Quaternion.identity);
    // }
}

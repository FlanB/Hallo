using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private int value;

    private GameObject instance;

    private void OnMouseDown()
    {
        instance = Instantiate(weapon, transform.position, transform.rotation);
        instance.GetComponent<Collider2D>().enabled = false;
        GameObject
            .Find("money")
            .GetComponent<MoneyBehavior>()
            .SubtractMoney(value);
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
        if (instance.transform.position.y < -3)
        {
            instance.transform.position =
                new Vector3(instance.transform.position.x, -2.5f, 0);
        }
    }
}

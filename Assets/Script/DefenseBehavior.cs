using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBehavior : MonoBehaviour
{
    [SerializeField]
    private int health;


    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy (gameObject);
        }
    }

    public int getHealth()
    {
        return health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}

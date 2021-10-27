using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehavior : DefenseBehavior
{
    [SerializeField]
    private int strength;
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Destroy (gameObject);
            collider.gameObject.GetComponent<EnemyBehavior>().TakeDamage(strength);
        }
    }
}

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
            gameObject.GetComponent<Animator>().SetTrigger("Explode");
            collider
                .gameObject
                .GetComponent<EnemyBehavior>()
                .TakeDamage(strength);
            StartCoroutine(DestroyMine());
        }
    }

    IEnumerator DestroyMine()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy (gameObject);
    }
}

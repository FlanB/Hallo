using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private int speed;

    [SerializeField]
    private int health;

    [SerializeField]
    private int strength;

    void Start()
    {
    }

    void Update()
    {
        MoveDown();

        // delete gameObject when leaves screen
        if (transform.position.y < -7 || health <= 0)
        {
            Destroy (gameObject);
        }
    }

    public void MoveDown()
    {
        rb2d.velocity = new Vector2(0, -speed);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Defense")
        {
            StartCoroutine(Attack(collider));
        }
    }

    private IEnumerator Attack(Collision2D collider)
    {
        DefenseBehavior DB =
            collider.gameObject.GetComponent<DefenseBehavior>();

        while (DB.getHealth() > 0)
        {
            DB.TakeDamage (strength);
            yield return new WaitForSeconds(1);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}

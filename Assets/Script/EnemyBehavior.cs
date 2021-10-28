using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private float speed;

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

        if (transform.position.y < -5)
        {
            GameObject
                .Find("Ancre")
                .GetComponent<LifeBehavior>()
                .LoseLife(health);
            LifeToZero();
        }
        if (health <= 0)
        {
            LifeToZero();
        }
    }

    public virtual void LifeToZero()
    {
        Destroy (gameObject);
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
        StartCoroutine(Flash(gameObject.GetComponent<SpriteRenderer>()));
    }

    private IEnumerator Flash(SpriteRenderer other)
    {
        other.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        other.color = Color.white;
    }

    private IEnumerator FlashCamera()
    {
        Camera.main.backgroundColor = Color.red;
        yield return new WaitForSeconds(0.1f);
        Camera.main.backgroundColor = new Color32(49, 121, 99, 255);
        LifeToZero();
    }
}

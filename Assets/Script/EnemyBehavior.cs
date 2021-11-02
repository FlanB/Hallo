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
    public float health;

    [SerializeField]
    private int strength;

    [SerializeField]
    private AudioSource audioSource;

    private bool once = false;

    public void multiplyHealth(float newHealth)
    {
        health *= newHealth;
    }

    private void Update()
    {
        MoveDown();
        if (!once)
        {
            if (transform.position.y < -5)
            {
                GameObject
                    .Find("Ancre")
                    .GetComponent<LifeBehavior>()
                    .LoseLife(health);
                LifeToZero();
                once = true;
            }
            if (health <= 0)
            {
                GameObject
                    .Find("money")
                    .GetComponent<MoneyBehavior>()
                    .AddMoney(strength);
                LifeToZero();
                once = true;
            }
        }
    }

    public virtual void LifeToZero()
    {
        audioSource.Play();
        StartCoroutine(DestroyEnemy());
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.2f);
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
            yield return new WaitForSeconds(1);
            gameObject.GetComponent<Animator>().SetBool("isAttacking", true);
            DB.TakeDamage (strength);
        }
        gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
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
}

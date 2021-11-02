using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private int speed;

    [SerializeField]
    private int strength;

    [SerializeField]
    private AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        MoveUp();
        if (transform.position.y > 5)
        {
            Destroy (gameObject);
        }
    }

    private void MoveUp()
    {
        rb2d.velocity = new Vector2(0, speed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            audioSource.Play();
            collider
                .gameObject
                .GetComponent<EnemyBehavior>()
                .TakeDamage(strength);
                StartCoroutine(DestroyBullet());
        }
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy (gameObject);
    }
}

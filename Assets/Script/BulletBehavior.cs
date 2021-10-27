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

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        MoveUp();
        if (transform.position.y > 7)
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
            collider
                .gameObject
                .GetComponent<EnemyBehavior>()
                .TakeDamage(strength);
            Destroy (gameObject);
        }
    }
}

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
    }

    public void MoveDown()
    {
        rb2d.velocity = new Vector2(0, -speed);
    }
}

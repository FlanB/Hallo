using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JakoBehavior : EnemyBehavior
{
    [SerializeField]
    GameObject skeletonToSpawn;

    private bool once = false;

    public override void LifeToZero()
    {
        if (!once)
        {
            for (int i = 0; i < 2; i++)
            {
                Instantiate(skeletonToSpawn,
                transform.position,
                Quaternion.identity);
            }
            once = true;
        }
        base.LifeToZero();
    }
}

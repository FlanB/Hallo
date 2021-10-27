using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JakoBehavior : EnemyBehavior
{
    [SerializeField] GameObject skeletonToSpawn;
    
        // Start is called before the first frame update
    void Start()
    {
    }

    public override void LifeToZero()
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(skeletonToSpawn, transform.position, Quaternion.identity);
        }
            base.LifeToZero();

    }

}

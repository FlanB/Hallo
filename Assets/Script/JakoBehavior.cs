using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JakoBehavior : EnemyBehavior
{
    [SerializeField] GameObject skeletonToSpawn;
    
        // Start is called before the first frame update
    void Start()
    {
       // LifeToZero();
    }

    public override void LifeToZero()
    {
        GameObject newSkeleton1 = Instantiate(skeletonToSpawn);
        newSkeleton1.transform.position = this.transform.position;
        base.LifeToZero();

    }

}

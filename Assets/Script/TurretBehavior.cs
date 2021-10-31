using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : DefenseBehavior
{
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private int projectileFrequency;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(projectile,
            transform.position + new Vector3(0, 0.5f, 0),
            Quaternion.identity);
            yield return new WaitForSeconds(projectileFrequency);
        }
    }
}

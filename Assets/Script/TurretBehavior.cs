using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : DefenseBehavior
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private int projectileFrequency;

       private IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(projectileFrequency);
        }
    }
}

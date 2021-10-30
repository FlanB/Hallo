using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeBehavior : MonoBehaviour
{
    [SerializeField]
    private float life;

    private int totalLife;

    private void Start()
    {
        totalLife = (int) life;
    }

    public void LoseLife(int damage)
    {
        //passage en pourcentage
        life = life - damage;
        transform.localScale = new Vector3(life / totalLife, 1, 1);
    }

    private void Update()
    {
        if (life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}

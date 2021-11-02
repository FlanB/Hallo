using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeBehavior : MonoBehaviour
{
    [SerializeField]
    private float life;

    [SerializeField]
    private AudioSource audioSource;

    private int totalLife;

    private bool once = false;

    private void Start()
    {
        totalLife = (int) life;
    }

    public void LoseLife(float damage)
    {
        //passage en pourcentage
        if (!once)
        {
            life = life - damage;
            transform.localScale = new Vector3(life / totalLife, 1, 1);
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}

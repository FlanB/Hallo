using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = EnemySpawner.wave;

    private void Start()
    {
        GetComponent<Text>().text = "Vague " + score;
    }
}

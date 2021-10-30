using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField]
    private string SceneName = "MainScene";

    public void NextScene()
    {
        SceneManager.LoadScene (SceneName);
    }
}

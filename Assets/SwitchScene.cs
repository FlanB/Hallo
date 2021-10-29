using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
 
public class Control : MonoBehaviour
{
    private const string SceneName = "MainScene";

    public void NextScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}

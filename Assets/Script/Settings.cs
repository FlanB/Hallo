using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private GameObject other;

    public void OpenSettings()
    {
        other.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseSettings()
    {
        other.SetActive(false);
        Time.timeScale = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public static bool GameIsPaused { get; private set; }

    void Start()
    {
        GameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ChangePauseStatus();
    }

    public void ChangePauseStatus()
    {
        GameIsPaused = !GameIsPaused;
        Time.timeScale = GameIsPaused ? 0 : 1;
    }
}

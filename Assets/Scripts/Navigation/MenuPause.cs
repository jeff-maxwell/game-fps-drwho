using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public Canvas PauseMenu;


    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (GameInfo.GameIsPaused)
            {
                PauseGame(false);
            }
            else
            {
                PauseGame(true);
            }
        }
    }


    public void PauseGame(bool pause)
    {
        GameInfo.GameIsPaused = pause;
        PauseMenu.enabled = pause;

        if (pause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }


}

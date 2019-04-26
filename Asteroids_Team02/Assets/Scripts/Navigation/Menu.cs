using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool isMainMenu = false;
    public static bool GameIsPaused = false;
    

    void Start()
    {
        if (isMainMenu)
        {
            this.transform.Find("ButtonPlay").gameObject.GetComponentInChildren<Text>().text = "Play";
        }
        else
        {
            this.transform.Find("ButtonPlay").gameObject.GetComponentInChildren<Text>().text = "Pause";
            this.gameObject.gameObject.SetActive(GameIsPaused);
        }
    }

    void Update()
    {
        if (!isMainMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                if (GameIsPaused)
                {
                    PauseGame(false);
                }
                else
                {
                    PauseGame(true);
                }
            }
        }
    }

    public void PauseGame(bool pause)
    {
        GameIsPaused = pause;
        this.gameObject.gameObject.SetActive(pause);

        if (pause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }



    public void PlayGame()
    {
        if (isMainMenu)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            this.gameObject.gameObject.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameInfo.IsDead)
        {
            
            
        }
    }

    public void PlayGame()
    {
        GameInfo.IsDead = false;
        GameInfo.currentScore = 0;
        GameInfo.currentHealth = 100;
        GameInfo.GameIsPaused = false;
        GameInfo.LevelIteration = 1;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

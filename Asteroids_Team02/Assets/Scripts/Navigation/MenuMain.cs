using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuMain : MonoBehaviour
{
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        if (isGameOver)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameInfo.IsDead)
        {
            Time.timeScale = 0f;
            this.gameObject.SetActive(true);
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

using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuMain : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void PlayGame()
    {
        GameInfo.IsDead = false;
        GameInfo.currentScore = 0;
        GameInfo.currentHealth = 100;
        GameInfo.GameIsPaused = false;
        GameInfo.LevelIteration = 1;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}

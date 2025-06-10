using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPause = false;
    public GameObject PauseMenuUI;
    [SerializeField] private string SceneName;
    // Update is called once per frame\  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
      
            if(GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
    public void QuitGame()
    {
        SceneManager.LoadScene(SceneName);
    }    
}

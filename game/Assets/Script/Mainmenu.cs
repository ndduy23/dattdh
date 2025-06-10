using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level1");
        if (PermanetUI.perm != null)
        {
            PermanetUI.perm.Reset();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class checkpoint : MonoBehaviour
{
    [SerializeField] private string SceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}


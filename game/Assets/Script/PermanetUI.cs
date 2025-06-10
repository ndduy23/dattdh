using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PermanetUI : MonoBehaviour
{
    // PLayer stats
    public int cherries = 0;
    public TextMeshProUGUI cherryText;

    public static PermanetUI perm;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if(!perm)
        {
            perm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Reset()
    {
        cherries = 0;
        cherryText.text = cherries.ToString();
    }
}

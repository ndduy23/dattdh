using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Highscore : MonoBehaviour
{
    //HighScore
    [SerializeField] private int highScore = 0;
    public string playerIdentifier = "player";
    [SerializeField] private TextMeshProUGUI highScoreText;
    void Start()
    {
        
        LoadPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        //Save score
        if (PermanetUI.perm.cherries > highScore)
        {
            highScore = PermanetUI.perm.cherries;
            SavePlayerData();
            UpdateHighScoreUI();
        }
    }
    void SavePlayerData()
    {
        PlayerPrefs.SetInt(playerIdentifier + "_PlayerScore", PermanetUI.perm.cherries);
        PlayerPrefs.SetInt(playerIdentifier + "_HighScore", highScore);
        PlayerPrefs.Save();
        Debug.Log("Dữ liệu đã được lưu cho " + playerIdentifier);
    }
    void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey(playerIdentifier + "_HighScore"))
        {
            highScore = PlayerPrefs.GetInt(playerIdentifier + "_HighScore");
            Debug.Log("Đã đọc dữ liệu HighScore cho " + playerIdentifier + ": " + highScore);
        }
        else
        {
            // Không có dữ liệu HighScore, set giá trị mặc định hoặc thực hiện hành động phù hợp
            highScore = 0;
            Debug.Log("Không có dữ liệu HighScore cho " + playerIdentifier + ". Đặt giá trị mặc định là 0.");
        }
        UpdateHighScoreUI();        
    }
    private void UpdateHighScoreUI()
    {
        highScoreText.text = "High Score: " + highScore;
    }
}
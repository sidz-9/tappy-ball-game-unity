using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public static UiController instance;
    public GameObject gameOverPanel;
    public GameObject startUi;
    public GameObject gameOverImage;
    public Text scoreText;
    public Text highScoreText;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ScoreController.instance.score.ToString();
    }

    public void GameStart() {
        startUi.SetActive(false);
    }
    public void GameOver() {
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Replay() {
        SceneManager.LoadScene("Level1");
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool gameOver;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        UiController.instance.GameStart();
        PipeSpawnner.instance.StartSpawnningPipes();
    }

    public void StopGame() {
        UiController.instance.GameOver();
        ScoreController.instance.StopScore();
    }
}

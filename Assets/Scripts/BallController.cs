using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    public float upForce;
    bool started;
    bool gameOver;
    public float rotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;      // isKinematic - no physics forces are applied on the object
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started) {
            if(Input.GetMouseButtonDown(0)){
                GameController.instance.StartGame();
                started = true;
                rb.isKinematic = false;     // the physics forces will be enabled, and ball falls down due to gravity
            }
        }
        else if(started && !gameOver){

            transform.Rotate(0, 0, rotation);

            if(Input.GetMouseButtonDown(0)) {
                // GameController.instance.StartGame();
                rb.velocity = Vector2.zero;     // setting the velocity to zero, else the ball will fall down directly, without the player getting any chance to react
                rb.AddForce(new Vector2(0, upForce));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        GetComponent<Animator>().Play("ball_shock");
        gameOver = true;
        GameController.instance.StopGame();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Pipe") {
            GetComponent<Animator>().Play("ball_shock");
            gameOver = true;
            GameController.instance.gameOver = true;
            GameController.instance.StopGame();
        }

        if(col.gameObject.tag == "ScoreChecker" && !gameOver) {
        // if(col.gameObject.tag == "ScoreChecker" && !GameController.instance.gameOver) {
            ScoreController.instance.IncrementScore();
        }
    }
}

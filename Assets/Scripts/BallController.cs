using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    public float upForce;
    bool started;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;      // isKinematic - no physics forces are applied on the object
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started) {
            if(Input.GetMouseButtonDown(0)){
                started = true;
                rb.isKinematic = false;     // the physics forces will be enabled, and ball falls down due to gravity
            }
        }
        else {
            if(Input.GetMouseButtonDown(0)) {
                rb.velocity = Vector2.zero;     // setting the velocity to zero, else the ball will fall down directly, without the player getting any chance to react
                rb.AddForce(new Vector2(0, upForce));
            }
        }
    }
}

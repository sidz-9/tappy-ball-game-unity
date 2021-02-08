using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float upDownSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Move();
        InvokeRepeating("SwitchUpDownd", 0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchUpDownd() {
        upDownSpeed = -upDownSpeed;
        rb.velocity = new Vector2(-speed, upDownSpeed);
    }

    void Move() {
        rb.velocity = new Vector2(-speed, upDownSpeed);
    }
}

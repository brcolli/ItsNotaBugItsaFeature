using System;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float sprintFactor = 1.5f;
    private bool grounded_ = false;
    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        if (grounded_ && Input.GetKey(KeyCode.LeftShift))
        {
            x *= sprintFactor;
            z *= sprintFactor;
        }

        if (grounded_ && Input.GetKeyDown(KeyCode.Space))
        {
            grounded_ = false;
            rb.AddForce(transform.up*jumpSpeed);
        }

        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);

        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground") || collision.gameObject.tag.Equals("Wall"))
            grounded_ = true;
    }
}
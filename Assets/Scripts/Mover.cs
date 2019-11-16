using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float speed = 800f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.forward * speed;
        rb2d.AddForce(transform.up * speed);
    }
}

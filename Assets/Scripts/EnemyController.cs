using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb2d;
    // private float curAngle = 0f;
    // private float rotSpeed = 90f;
    // private bool isRotating = false;
    private Vector2 dir;

    public float speed = 5f;
    public float delay = 1f;
    public float fireRate = 1.5f;
    public GameObject shot;
    public Transform shotSpawn;
    public Transform originPoint1;
    public Transform originPoint2;
    public Transform originPoint3;
    public Transform originPoint4;
    public Transform originPoint5;
    public Transform originPoint6;
    public float range1;
    public float range2;
    public float range3;
    public float range4;
    public float range5;
    public float range6;
    public float time = 10f;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("Fire", delay, fireRate);
        dir = transform.position;
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        Debug.DrawRay(originPoint1.position, dir * range1);
        RaycastHit2D hit1 = Physics2D.Raycast(originPoint1.position, dir, range1);
        RaycastHit2D hit2 = Physics2D.Raycast(originPoint2.position, dir, range2);
        RaycastHit2D hit3 = Physics2D.Raycast(originPoint3.position, dir, range3);
        RaycastHit2D hit4 = Physics2D.Raycast(originPoint4.position, dir, range4);
        RaycastHit2D hit5 = Physics2D.Raycast(originPoint5.position, dir, range5);
        RaycastHit2D hit6 = Physics2D.Raycast(originPoint6.position, dir, range6);

        if (hit1)
        {
            if (hit1.collider.CompareTag("Obstacles") || hit1.collider.CompareTag("Barrier") || hit1.collider.CompareTag("Steel"))
            {
                transform.Rotate(0f, 0f, 90f);
                dir *= -1;
            }
        } else if (hit2)
        {
            if (hit2.collider.CompareTag("Obstacles") || hit2.collider.CompareTag("Barrier") || hit2.collider.CompareTag("Steel"))
            {
                transform.Rotate(0f, 0f, -90f);
                dir *= -1;
            }
        } else if (hit3)
        {
            if (hit3.collider.CompareTag("Obstacles") || hit3.collider.CompareTag("Barrier") || hit3.collider.CompareTag("Steel"))
            {
                transform.Rotate(0f, 0f, 90f);
                dir *= -1;
            }
        } else if (hit4)
        {
            if (hit4.collider.CompareTag("Player"))
            {
                transform.Rotate(0f, 0f, 180f);
                dir *= 1;
            }
        } else if (hit5)
        {
            if (hit5.collider.CompareTag("Player"))
            {
                transform.Rotate(0f, 0f, 180f);
                dir *= 1;
            }
        } else if (hit6)
        {
            if (hit6.collider.CompareTag("Player"))
            {
                transform.Rotate(0f, 0f, 180f);
                dir *= 1;
            }
        }

        time -= Time.deltaTime;

        if (time <= 0f)
        {
            transform.Rotate(0f, 0f, -90f);
            time = 10f;
        }
    }

    void Fire()
    {
        Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());

        // if (collision.gameObject.CompareTag("Barrier") && !isRotating)
        // {
        //     isRotating = true;

        //     while (curAngle < 90f)
        //     {
        //         float dAngle = rotSpeed * Time.deltaTime;
        //         curAngle += dAngle;
        //         transform.Rotate(0f, 0f, dAngle);
        //     }

        //     curAngle -= 90f;
        //     isRotating = false;
        // }

        // if (collision.gameObject.CompareTag("Obstacles") && !isRotating)
        // {
        //     isRotating = true;

        //     while (curAngle < 90f)
        //     {
        //         float dAngle = rotSpeed * Time.deltaTime;
        //         curAngle += dAngle;
        //         transform.Rotate(0f, 0f, dAngle);
        //     }

        //     curAngle -= 90f;
        //     isRotating = false;
        // }

        // if (collision.gameObject.CompareTag("Steel") && !isRotating)
        // {
        //     isRotating = true;

        //     while (curAngle < 90f)
        //     {
        //         float dAngle = rotSpeed * Time.deltaTime;
        //         curAngle += dAngle;
        //         transform.Rotate(0f, 0f, dAngle);
        //     }

        //     curAngle -= 90f;
        //     isRotating = false;
        // }

        // if (collision.gameObject.CompareTag("Alive") && !isRotating)
        // {
        //     isRotating = true;

        //     while (curAngle < 90f)
        //     {
        //         float dAngle = rotSpeed * Time.deltaTime;
        //         curAngle += dAngle;
        //         transform.Rotate(0f, 0f, dAngle);
        //     }

        //     curAngle -= 90f;
        //     isRotating = false;
        // }
    }
}

// private Transform target;
// private float distanceToTarget;
// public float chaseRange;

// var player = GameObject.FindGameObjectWithTag("Player");

// if (player != null)
//     target = player.GetComponent<Transform>();
        
// if (distanceToTarget < chaseRange)

// void FixedUpdate()
// {
//     if (target != null)
//     {
//         distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            
//         if (distanceToTarget < chaseRange)
//         {
//             Vector3 targetDir = target.transform.position - transform.position;
//             float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
//             Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
//             transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
            
//             transform.Translate(Vector3.up * 1f * Time.deltaTime);
//         }
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    private float nextFire;

    public GameObject shot;
    public Transform shotSpawn;
    public float speed = 10f;
    public float fireRate;
    public bool canMove;
    public static PlayerController instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    void Update()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            }

            // Up
            if (Input.GetKey(KeyCode.UpArrow))
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            
            // Down
            if (Input.GetKey(KeyCode.DownArrow))
                transform.Translate(Vector2.down * speed * Time.deltaTime);

            // Left
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                transform.rotation *= Quaternion.Euler(0f, 0f, 90f);

            // Right
            if (Input.GetKeyDown(KeyCode.RightArrow))
                transform.rotation *= Quaternion.Euler(0f, 0f, -90f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            if (GM.health < 3)
            {
                GM.instance.AddHealth();
                Destroy(other.gameObject);
            } else
            {
                Destroy(other.gameObject);
            }
        }
    }
}

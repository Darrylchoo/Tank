using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour
{
    public float speed = 1f;
    public int damageNumber = 1;
    public Text displayNumber;

    void Update()
    {
        displayNumber.text = "-" + damageNumber.ToString();
        transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
    }
}

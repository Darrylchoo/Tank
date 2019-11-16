using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{
    public GameObject playerExplosion;
    public GameObject obstacleExplosion;
    public GameObject damageNumber;
    public AnimatorController myAnim;
    public float invincibleTime = 2f;

    void Start()
    {
        myAnim = AnimatorController.instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Barrier") || other.CompareTag("Player") || other.CompareTag("Player_Bullet") || other.CompareTag("Obstacles") || other.CompareTag("Steel") || other.CompareTag("Alive"))
            Destroy(gameObject);

        if (other.CompareTag("Player"))
        {
            GM.instance.HurtPlayer();
            Instantiate(damageNumber, other.transform.position, Quaternion.identity);
            myAnim.TriggerHurt(invincibleTime);
            
            if (GM.health == 0)
            {
                Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("Player_Bullet"))
            Destroy(other.gameObject);

        if (other.CompareTag("Obstacles"))
        {
            Instantiate(obstacleExplosion, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBullet : MonoBehaviour
{
    public GameObject enemyExplosion;
    public GameObject obstacleExplosion;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Barrier") || other.CompareTag("Enemy") || other.CompareTag("Enemy_Bullet") || other.CompareTag("Obstacles") || other.CompareTag("Steel") || other.CompareTag("Alive"))
            Destroy(gameObject);

        if (other.CompareTag("Enemy"))
        {
            Instantiate(enemyExplosion, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);

            GM.instance.KillEnemy();
            GM.instance.UpdateScore();
        }

        if (other.CompareTag("Enemy_Bullet"))
            Destroy(other.gameObject);

        if (other.CompareTag("Obstacles"))
        {
            Instantiate(obstacleExplosion, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }    
}

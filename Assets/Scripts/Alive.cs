using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Alive : MonoBehaviour
{
    private bool isDestroyed = false;

    public GameObject effect;
    public GameObject dead;
    public float delay = 1f;
    public float effectDelay = 0.5f;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Player_Bullet") || other.CompareTag("Enemy_Bullet")) && !isDestroyed)
        {            
            isDestroyed = true;

            StartCoroutine(Effect());            
            GM.instance.gameOver.gameObject.SetActive(true);
            Time.timeScale = 0.25f;      

            var player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                PlayerController move = player.GetComponent<PlayerController>();
                move.canMove = false; 
            }
        }
    }

    IEnumerator Effect()
    {        
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(effect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(effectDelay);           
        Instantiate(dead, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(delay);        
        SceneManager.LoadScene("GameOver");
        Destroy(gameObject);
    }
}

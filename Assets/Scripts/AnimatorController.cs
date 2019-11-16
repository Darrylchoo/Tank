using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator myAnim;

    public static AnimatorController instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    public void TriggerHurt(float hurtTime)
    {
        StartCoroutine(HurtBlinker(hurtTime));
    }

    IEnumerator HurtBlinker(float hurtTime)
    {
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int playerLayer = LayerMask.NameToLayer("Player");

        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer);

        myAnim.SetLayerWeight(1, 1);

        yield return new WaitForSeconds(hurtTime);

        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);

        myAnim.SetLayerWeight(1, 0);
    }
}

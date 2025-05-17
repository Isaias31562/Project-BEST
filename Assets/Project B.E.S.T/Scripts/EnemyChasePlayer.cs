using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Need a Rigidbody 2D, "Body Type" set to "dynamic" (this allows it to move)
//Collider of some sort (Capsule Collider 2D)
public class EnemyChasePlayer : MonoBehaviour
{
    public float speed;
    private bool isChasing;

    private Rigidbody2D rb;
    private Transform player;


    //Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    //Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (isChasing == true)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player == null)
            {
                player = collision.transform;
            }
            isChasing = true;
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.linearVelocity = Vector2.zero;
            isChasing = false;
        }
    }
}
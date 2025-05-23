using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//With this class, "collision" will now refer to the player whenever he collides with the enemy
public class EnemyDamage : MonoBehaviour
{
    //"OnCollisionEnter2D" is a Unity method that will fire when the enemy hits a collider.
    //"Collision2D" is the type of collision it will look for.
    //"collision" keeps track of the last collider the enemy hit

    public int damage = 1;
    public int Health = 5;
    void Update()
    {

    }

    //"OnCollisionEnter2D" is a method that will fire when the enemy hits a collider.
    //"collision2D is the type of collion it will look for.
    //"collision" keeps track of the last collider the enemy hit.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Negative "damage" or else the player would "heal" instead of take damage.
        collision.gameObject.GetComponent<HealthSlider>().TakeDamage(damage);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            takeDamage();

        }
    }
    void takeDamage()
    {
        Health -= damage;
        if (Health < -0)
        {
            Destroy(gameObject);
        }

    }
}
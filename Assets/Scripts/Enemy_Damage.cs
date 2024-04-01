using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    // Calls the PlayerHealth Script in order to damage the Player.
    // Drag the Player Object into the Inspector for THIS Object's Player Health option
    // in order to affect the Player's Health and link the two scripts.
    public PlayerHealth playerHealth;

    // When the Player Collides with the Enemy
    private void OnCollisionEnter2D(Collision2D collision)
    { // If the Enemy collides with an object with the "Player" tag
        if (collision.gameObject.tag == "Player")
        {  // Calls the TakeDamage script to affect Player Health.
            // This value can be changed in the Inspector to alter how much damage
            // the enemy does to the Player.
            playerHealth.TakeDamage(damage);
        }
    }


}


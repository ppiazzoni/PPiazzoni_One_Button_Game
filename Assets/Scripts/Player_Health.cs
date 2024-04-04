using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Variable for the Player's MAX HEALTH
    public int maxHealth = 3;
    // Variable that keeps track of Player's Health
    public int health;
    public GameObject deathScreen;

    void Start()
    {
        // Game begins with the Player at MAX HEALTH.
        health = maxHealth;
    }
    // Amount of damage the enemy will deal
    public void TakeDamage(int damage)
    {
        // Makes Health go DOWN when Player takes damage.
        health -= damage;

        // If Player's health reaches ZERO Player is DEFEATED
        if (health <= 0)
        {
            //LoadSceneMode? Losingscreen;
            deathScreen.SetActive(true);
        }
    }

}
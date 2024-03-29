using UnityEngine;

public class Parry : MonoBehaviour
{
    public float parryDuration = 0.5f; // Duration of parry window
    public float parryCooldown = 1f; // Cooldown time before next parry can be initiated

    private Collider playerCollider;
    private bool isParrying = false; // Flag to indicate if the player is currently parrying
    private float lastParryTime; // Time when the last parry was initiated

    private void Awake()
    {
        playerCollider = this.GetComponent<Collider>();
    }
    void Update()
    {
        // Check for user input to toggle parry
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleParry();
        }
    }

    void ToggleParry()
    {
        if (!isParrying && Time.time >= lastParryTime + parryCooldown)
        {
            StartParry();
        }
        else
        {
            EndParry();
        }
    }

    void StartParry()
    {
        playerCollider.isTrigger = false;
        isParrying = true;
        lastParryTime = Time.time;

        // Enable some visual or audio feedback to indicate the player is parrying

        // Invoke a method to detect if an enemy's attack collides with the player during parry
        Invoke("EndParry", parryDuration);
    }

    void EndParry()
    {
        isParrying = false;

        // Disable the visual or audio feedback for parry
    }

    // Method to be called by enemies when their attack collides with the player
    public void OnEnemyAttackCollision()
    {
        if (isParrying)
        {
            // Handle successful parry
            Debug.Log("Parry successful!");

            // You can add more logic here, like stunning the enemy or dealing damage to them
        }
        else
        {
            // Handle player getting hit by enemy attack
            Debug.Log("Player got hit!");
        }
    }
}
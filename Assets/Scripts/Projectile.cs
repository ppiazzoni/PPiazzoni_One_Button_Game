using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Method to be called when the projectile collides with something
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the Parry component from the player GameObject
            Parry parry = other.GetComponent<Parry>();

            // If the Parry component exists, call the OnEnemyAttackCollision method
            if (parry != null)
            {
                parry.OnEnemyAttackCollision();
            }
        }

        // Perform any necessary actions when the projectile collides with something
        // For example, destroy the projectile
        Destroy(gameObject);
    }
}
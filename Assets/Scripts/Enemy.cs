using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the damaging projectile
    public float projectileSpeed = 5f; // Speed of the projectile
    public float launchInterval = 2f; // Time interval between each projectile launch

    private Transform player; // Reference to the player's transform
    private float lastLaunchTime; // Time when the last projectile was launched

    void Start()
    {
        // Find the player GameObject and get its transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(LaunchIntervalRandomizer());
    }

    void Update()
    {
        // Check if it's time to launch another projectile
        if (Time.time >= lastLaunchTime + launchInterval)
        {
            LaunchProjectile();
            lastLaunchTime = Time.time;
        }
    }

    void LaunchProjectile()
    {
        // Calculate the direction towards the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Instantiate the projectile prefab
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Set the velocity of the projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
    }

    IEnumerator LaunchIntervalRandomizer()
    {
        yield return new WaitForSeconds(2f);
        launchInterval = Random.Range(1f, 2f);
        StartCoroutine(LaunchIntervalRandomizer());
    }

    // Method to be called when the projectile collides with something
    public void OnProjectileCollision()
    {
        Destroy(gameObject);
    }
}
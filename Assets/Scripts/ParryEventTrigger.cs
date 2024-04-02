using UnityEngine;

public class ParryEventTrigger : MonoBehaviour
{
    public ParticleSystem particleSystem; // Reference to the ParticleSystem component

    // Start is called before the first frame update
    void Start()
    {
        // Disable the particle system at the start
        if (particleSystem != null)
        {
            particleSystem.Stop();
        }

        // Subscribe to the "parry" event
        ParryEventManager.OnParry += ActivateParticleSystem;
    }

    // Method to activate the particle system
    void ActivateParticleSystem()
    {
        if (particleSystem != null)
        {
            // Check if the particle system is already playing
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
            else
            {
                // Restart the particle system if it's already playing
                particleSystem.Stop();
                particleSystem.Play();
            }
        }
        else
        {
            Debug.LogError("Particle system reference is not assigned!");
        }
    }
}

// Class for managing parry events
public static class ParryEventManager
{
    // Delegate for parry event
    public delegate void ParryAction();

    // Event that gets triggered when a parry occurs
    public static event ParryAction OnParry;

    // Method to invoke the parry event
    public static void Parry()
    {
        OnParry?.Invoke();
    }
}
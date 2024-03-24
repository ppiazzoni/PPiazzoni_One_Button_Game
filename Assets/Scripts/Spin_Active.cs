using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animation anim; // Reference to your animation component
    public KeyCode keyToPress = KeyCode.Space; // Keybind to trigger the animation

    void Update()
    {
        // Check if the key is pressed
        if (Input.GetKeyDown(keyToPress))
        {
            // Check if the animation is not already playing to prevent interruption
            if (!anim.isPlaying)
            {
                // Trigger the animation
                anim.Play();
            }
        }
    }
}
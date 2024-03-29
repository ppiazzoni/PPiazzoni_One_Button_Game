using UnityEngine;

public class Spin_Active : MonoBehaviour
{
    public KeyCode keyToPress = KeyCode.Space; // Keybind to trigger the animation

    private Animator anim; // Reference to your animation component

    private void Awake()
    {
        anim = this.GetComponent<Animator>();
    }
    void Update()
    {
        // Check if the key is pressed
        if (Input.GetKeyDown(keyToPress))
        {
            anim.SetTrigger("parry");
        }
    }
}
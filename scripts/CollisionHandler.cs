using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update        
    private Animator animator;
    private bool isPaused = false;
     
    void Start()
    {
        // Assuming the Animator component is attached to the same GameObject as this script
        animator = GetComponent<Animator>();
        TogglePause();
    }


    public void TogglePause()
    {
        // Toggle the isPaused flag
        isPaused = !isPaused;

        // Set the playback speed based on whether the animation is paused
        if (isPaused)
        {
            // Pause the animation by setting playback speed to 0
            animator.speed = 0f;
        }
        else
        {
            // Resume the animation by setting playback speed to 1
            animator.speed = 1f;
        }
    }
}

using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;
    public Transform player;
    // Remove the line: public Transform door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Not Detected Car"))
        {
            anim.SetBool("Near", true);
            other.tag = "Gate Detected Car";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gate Detected Car"))
        {
            anim.SetBool("Near", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Debug.Log("Player is null");
            // If the player is not assigned, try to find the main camera
            player = Camera.main?.transform;
            
            // If the main camera is still not found, you might need to manually assign the player in the Inspector.
        }
    }
}

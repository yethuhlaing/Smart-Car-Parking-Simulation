using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollision : MonoBehaviour
{
    // This method is called when another collider enters the trigger collider
    public GameObject mainCamera;
    public string ParkingLiftName(){
        GameObject currentObject = gameObject;
        currentObject = currentObject.transform.parent.gameObject;
        while (currentObject.transform.parent != null)
        {
            // Move to the parent GameObject
            currentObject = currentObject.transform.parent.gameObject;
        }
        return currentObject.name;
    } 
    IEnumerator RotateLift()
    {
        string parkingLiftName = ParkingLiftName();
        GameObject ParkingLift = GameObject.Find(parkingLiftName);
        CollisionHandler CollisionHandlerScript = ParkingLift.GetComponent<CollisionHandler>();   
        yield return new WaitForSeconds(2.5f);
        CollisionHandlerScript.TogglePause();
    }
    // This method is called while another collider stays inside the trigger collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has a specific tag or component
        if (other.CompareTag("Gate Detected Car"))
        {
            Debug.Log("Car is inside the trigger!");
            // Do something while the player stays inside the trigger
            // Check if the GameObject is found
            string parkingLiftName = ParkingLiftName();
            GameObject ParkingLift = GameObject.Find(parkingLiftName);
            Debug.Log(parkingLiftName);
            if (ParkingLift != null)
            {
                // Try to get the ScriptA component
                CollisionHandler CollisionHandlerScript = ParkingLift.GetComponent<CollisionHandler>();

                // Check if the ScriptA component is found
                if (CollisionHandlerScript != null)
                {
                    other.transform.SetParent(transform);
                    Rigidbody carRigidbody = other.GetComponent<Rigidbody>();
                    if (carRigidbody != null)
                    {
                        carRigidbody.useGravity=false;
                        carRigidbody.isKinematic=true;
                    }

                    other.tag = "Parked Car";
                    CollisionHandlerScript.TogglePause();
                    StartCoroutine(RotateLift());
                }
                else
                {
                    Debug.LogError("CollisionHandlerScript component not found on the GameObject.");
                }
            }
            else
            {
                Debug.LogError("ParkingLift GameObject with the name 'ObjectWithScriptA' not found.");
            }

        }
    }
}

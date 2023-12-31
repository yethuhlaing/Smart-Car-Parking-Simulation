using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{ 
    public GameObject objectToInstantiate;
    public Transform spawner;

    void Start()
    {
        // Ensure that a spawner is assigned
        if (spawner == null)
        {
            Debug.LogError("Spawn Point is not assigned to the script.");
        }
    }

    public void OnButtonClick()
    {
        // Check if the object to instantiate is assigned
        if (objectToInstantiate != null && spawner != null)
        {
            // Instantiate the object at the specified spawn point
            GameObject instantiatedObject = Instantiate(objectToInstantiate, spawner.position, spawner.rotation);
            instantiatedObject.tag="Not Detected Car";
            CameraFollow cameraFollow = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
            cameraFollow.carTransform=instantiatedObject.transform;
            // Access the Rigidbody component of the new car
            Rigidbody carRigidbody = instantiatedObject.GetComponent<Rigidbody>();

            // Check if the Rigidbody component exists
            if (carRigidbody != null)
            {
                // Modify the useGravity property of the Rigidbody
                carRigidbody.useGravity = true; // Set to true or false based on your requirements
                carRigidbody.isKinematic = false;
            }
            else
            {
                Debug.LogError("Rigidbody component not found on the instantiated car.");
            }
            Debug.Log("Object instantiated!");
        }
        else
        {
            Debug.LogError("Object to instantiate or spawn point is not assigned.");
        }
    }
}

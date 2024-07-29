using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGripper : MonoBehaviour
{
    public Transform gripperTransform; // The transform of the gripper
    public float pickupRange = 1.0f; // The range within which the robot can pick up objects
    private GameObject currentObject; // The object currently being picked up

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Change this to your input key
        {
            if (currentObject != null)
            {
                ReleaseObject();
            }
            else
            {
                TryPickupObject();
            }
        }
    }

    private void TryPickupObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(gripperTransform.position, gripperTransform.forward, out hit, pickupRange))
        {
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                PickupObject(hit.collider.gameObject);
            }
        }
    }

    private void PickupObject(GameObject obj)
    {
        currentObject = obj;
        obj.transform.SetParent(gripperTransform); // Parent the object to the gripper
        obj.GetComponent<Rigidbody>().isKinematic = true; // Disable physics on the object
    }

    private void ReleaseObject()
    {
        currentObject.transform.SetParent(null); // Unparent the object
        currentObject.GetComponent<Rigidbody>().isKinematic = false; // Enable physics on the object
        currentObject = null;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject object1; // Assign the first object in the Inspector
    public GameObject object2; // Assign the second object in the Inspector
    public GameObject object3; // Assign the third object in the Inspector

    private List<GameObject> objects; // List to hold the objects
    private int currentObjectIndex = -1; // Start with no object active

    void Start()
    {
        // Initialize the list with the assigned objects
        objects = new List<GameObject> { object1, object2, object3 };

        // Ensure all objects are inactive at the start
        SetActiveObject(currentObjectIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Use the space bar to switch objects
        {
            SwitchObject();
        }
    }

    void SwitchObject()
    {
        // Deactivate the current object if it's within valid index range
        if (currentObjectIndex >= 0 && currentObjectIndex < objects.Count)
        {
            objects[currentObjectIndex].SetActive(false);
        }

        // Calculate the index of the next object
        currentObjectIndex = (currentObjectIndex + 1) % (objects.Count + 1);

        // Activate the next object if it's within valid index range
        SetActiveObject(currentObjectIndex);
    }

    void SetActiveObject(int objectIndex)
    {
        // Deactivate all objects
        foreach (var obj in objects)
        {
            obj.SetActive(false);
        }

        // If the index is valid, activate the selected object
        if (objectIndex >= 0 && objectIndex < objects.Count)
        {
            objects[objectIndex].SetActive(true);
        }
    }
}


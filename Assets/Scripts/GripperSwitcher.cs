using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripperSwitcher : MonoBehaviour
{
    public GameObject gripper1; // Assign the first gripper in the Inspector
    public GameObject gripper2; // Assign the second gripper in the Inspector
    public GameObject gripper3; // Assign the third gripper in the Inspector

    private List<GameObject> grippers; // List to hold the grippers
    private int currentGripperIndex = -1; // Start with no gripper active

    void Start()
    {
        // Initialize the list with the assigned grippers
        grippers = new List<GameObject> { gripper1, gripper2, gripper3 };

        // Ensure all grippers are inactive at the start
        SetActiveGripper(currentGripperIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // Use a different key to switch grippers, e.g., 'G'
        {
            SwitchGripper();
        }
    }

    void SwitchGripper()
    {
        // Deactivate the current gripper if it's within valid index range
        if (currentGripperIndex >= 0 && currentGripperIndex < grippers.Count)
        {
            grippers[currentGripperIndex].SetActive(false);
        }

        // Calculate the index of the next gripper
        currentGripperIndex = (currentGripperIndex + 1) % (grippers.Count + 1);

        // Activate the next gripper if it's within valid index range
        SetActiveGripper(currentGripperIndex);
    }

    void SetActiveGripper(int gripperIndex)
    {
        // Deactivate all grippers
        foreach (var gripper in grippers)
        {
            gripper.SetActive(false);
        }

        // If the index is valid, activate the selected gripper
        if (gripperIndex >= 0 && gripperIndex < grippers.Count)
        {
            grippers[gripperIndex].SetActive(true);
        }
    }
}


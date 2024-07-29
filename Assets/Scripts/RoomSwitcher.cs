using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitcher : MonoBehaviour
{
    public GameObject defaultRoom; // Assign the default room object in the Inspector
    public GameObject kitchenRoom; // Assign the kitchen room object in the Inspector
    public GameObject livingRoom; // Assign the living room object in the Inspector
    public GameObject officeRoom; // Assign the office room object in the Inspector

    private List<GameObject> rooms; // List to hold the room objects
    private int currentRoomIndex = 0;

    void Start()
    {
        // Initialize the list with the assigned room objects
        rooms = new List<GameObject> { defaultRoom, kitchenRoom, livingRoom, officeRoom };

        // Set only the default room active
        SetActiveRoom(currentRoomIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SwitchRoom();
        }
    }

    void SwitchRoom()
    {
        // Deactivate the current room
        rooms[currentRoomIndex].SetActive(false);

        // Calculate the index of the next room
        currentRoomIndex = (currentRoomIndex + 1) % rooms.Count;

        // Activate the next room
        SetActiveRoom(currentRoomIndex);
    }

    void SetActiveRoom(int roomIndex)
    {
        // Activate the selected room
        rooms[roomIndex].SetActive(true);
    }
}

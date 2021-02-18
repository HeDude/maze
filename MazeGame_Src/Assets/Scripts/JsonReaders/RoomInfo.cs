using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo : MonoBehaviour
{
    [SerializeField] private string roomPosition;
    private int roomIndex;

    private void Start()
    {
        switch (roomPosition)
        {
            case "center": roomIndex = 0; break;
            case "left": roomIndex = 1; break;
            case "right": roomIndex = 2; break;
            case "top": roomIndex = 3; break;
            case "top-left": roomIndex = 4; break;
            case "top-right": roomIndex = 5; break;
            case "bottom": roomIndex = 6; break;
            case "bottom-left": roomIndex = 7; break;
            case "bottom-right": roomIndex = 8; break;
            default: roomIndex = -1; break;
        }
    }

    public int getRoomIndex()
    {
        return roomIndex;
    }
}

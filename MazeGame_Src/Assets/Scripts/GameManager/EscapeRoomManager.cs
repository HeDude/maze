using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeRoomManager : MonoBehaviour
{
    //Start is called before the first frame update
    private void Start()
    {
        //Sets the correct position and language for each escaperoom in the scene
        GameObject[] escapeRooms = GameObject.FindGameObjectsWithTag("EscapeRoom");

        foreach (GameObject e in escapeRooms)
        {
            EscapeRoom escapeRoom = e.GetComponent<EscapeRoomHolder>().escapeRoom;
            if (e.name == "ERT_topleft") { escapeRoom.Position = "top-left"; };
            if (e.name == "ERT_top") { escapeRoom.Position = "top"; };
            if (e.name == "ERT_topright") { escapeRoom.Position = "top-right"; };
            if (e.name == "ERT_left") { escapeRoom.Position = "left"; };
            if (e.name == "ERT_middle") { escapeRoom.Position = "middle"; };
            if (e.name == "ERT_right") { escapeRoom.Position = "right"; };
            if (e.name == "ERT_bottom-left") { escapeRoom.Position = "bottom-left"; };
            if (e.name == "ERT_bottom") { escapeRoom.Position = "bottom"; };
            if (e.name == "ERT_bottom-right") { escapeRoom.Position = "bottom-right"; };
        }
    }
}

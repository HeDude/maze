using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class ReadJsonFile : MonoBehaviour
{
    private string rawJsonData;
    private JsonData escapeRoomData;

    //Start is called before the first frame update
    private void Start()
    {
        //Read the json file (The raw data from the json file)
        rawJsonData = File.ReadAllText(Application.dataPath + "/JsonFiles/escaperooms.json");

        //This holds the Json object that we need to parse out into string text
        //The JsonMapper maps the raw text to a dictionary, so we can read it like any other dictionary
        escapeRoomData = JsonMapper.ToObject(rawJsonData);
    }

    //Checks for collision for a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        //Checks whether the tag of the collided object is Escape Room
        if(other.tag == "EscapeRoom")
        {
            //Tries to find the RoomInfo component
            RoomInfo roomInfo = other.gameObject.GetComponent<RoomInfo>();

            //If the collided object has the RoomInfo component
            if (roomInfo != null)
            {
                //Debugs the name of the escape room depending on its position
                Debug.Log(escapeRoomData["escaperooms"][roomInfo.roomPosition]["name"]);
            }
        }
    }
}

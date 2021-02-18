using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class ReadJsonFile : MonoBehaviour
{
    //Data for the escape room
    private string rawEscaperoomData;
    private JsonData escapeRoomData;

    //Data for the questions
    private string rawQuestionData;
    private JsonData questionData;

    //Start is called before the first frame update
    private void Start()
    {
        //Read the json file (The raw data from the json file)
        rawEscaperoomData = File.ReadAllText(Application.dataPath + "/JsonFiles/escaperooms.json");

        //This holds the Json object that we need to parse out into string text
        //The JsonMapper maps the raw text to a dictionary, so we can read it like any other dictionary
        escapeRoomData = JsonMapper.ToObject(rawEscaperoomData);

        //Read the json file (The raw data from the json file)
        rawQuestionData = File.ReadAllText(Application.dataPath + "/JsonFiles/questions.json");

        //This holds the Json object that we need to parse out into string text
        //The JsonMapper maps the raw text to a dictionary, so we can read it like any other dictionary
        questionData = JsonMapper.ToObject(rawQuestionData);
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
                Debug.Log(escapeRoomData["escaperooms"][roomInfo.getRoomIndex()]["name"]);
                Debug.Log(questionData["Questions"][roomInfo.getRoomIndex()]["Reproductive"]);
            }
        }
    }
}

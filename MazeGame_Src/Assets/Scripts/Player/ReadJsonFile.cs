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
        rawQuestionData = File.ReadAllText(Application.dataPath + "/JsonFiles/questions.json");

        //This holds the Json object that we need to parse out into string text
        //The JsonMapper maps the raw text to a dictionary, so we can read it like any other dictionary
        escapeRoomData = JsonMapper.ToObject(rawEscaperoomData);
        questionData = JsonMapper.ToObject(rawQuestionData);
    }

    //Checks for collision for a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        //Checks whether the tag of the collided object is Escape Room
        if(other.tag == "EscapeRoom")
        {
            //Tries to find the RoomInfo component
            EscapeRoom escapeRoom = other.gameObject.GetComponent<EscapeRoomHolder>().escapeRoom;

            //If the collided object has the RoomInfo component
            if (escapeRoom != null)
            {
                //Debugs the name of the escape room depending on its position
                Debug.Log("P: " + escapeRoom.Position);
                Debug.Log("L: " + escapeRoom.Language);
                Debug.Log("Q: " + escapeRoom.Question);
                Debug.Log("A1: " + escapeRoom.AnswerApplication);
                Debug.Log("A2: " + escapeRoom.AnswerMeaning);
                Debug.Log("A3: " + escapeRoom.AnswerProductive);
                Debug.Log("A4: " + escapeRoom.AnswerReproductive);
            }
        }
    }
}

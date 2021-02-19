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

        //Sets the correct position and language for each escaperoom in the scene
        GameObject[] escapeRooms = GameObject.FindGameObjectsWithTag("EscapeRoom");
        
        foreach (GameObject e in escapeRooms)
        {
            EscapeRoom escapeRoom = e.GetComponent<EscapeRoom>();
            if (e.name == "ERT_topleft") { escapeRoom.Position = "top-left"; };
            if (e.name == "ERT_top") { escapeRoom.Position = "top"; };
            if (e.name == "ERT_topright") { escapeRoom.Position = "top-right"; };
            if (e.name == "ERT_left") { escapeRoom.Position = "left"; };
            if (e.name == "ERT_middle") { escapeRoom.Position = "middle"; };
            if (e.name == "ERT_right") { escapeRoom.Position = "right"; };
            if (e.name == "ERT_bottom-left") { escapeRoom.Position = "bottom-left"; };
            if (e.name == "ERT_bottom") { escapeRoom.Position = "bottom"; };
            if (e.name == "ERT_bottom-right") { escapeRoom.Position = "bottom-right"; };

            escapeRoom.Language = "nl";

        }
    }

    //Checks for collision for a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        //Checks whether the tag of the collided object is Escape Room
        if(other.tag == "EscapeRoom")
        {
            //Tries to find the RoomInfo component
            EscapeRoom escapeRoom = other.gameObject.GetComponent<EscapeRoom>();

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

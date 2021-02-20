using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class EscapeRoomHolder : MonoBehaviour
{
    //Data for the escape room
    private string escaperooms_json;

    //Data for the questions
    private string questions_json;

    //Data for the language
    private string language_json;

    //Instance of the escapeRoom
    public EscapeRoom escapeRoom { get; set; }

    //Start is called before the first frame update
    private void Awake()
    {
        //Read the json file (The raw data from the json file)
        escaperooms_json = File.ReadAllText(Application.dataPath + "/JsonFiles/escaperooms.json");
        questions_json = File.ReadAllText(Application.dataPath + "/JsonFiles/questions.json");
        language_json = File.ReadAllText(Application.dataPath + "/Locale/nl.json");

        escapeRoom = new EscapeRoom(escaperooms_json, questions_json, language_json);
    }
}

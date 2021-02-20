using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeRoom {

    public string Position { get; set; }
    public string Language { get; set; }

    public string Question { get; set; }
    public string AnswerReproductive { get; set; }
    public string AnswerApplication { get; set; }
    public string AnswerMeaning { get; set; }
    public string AnswerProductive { get; set; }

    public EscapeRoom(string _escaperooms_json, string _questions_json, string _language_json)
    {
        Question = "Which tool would you bring with you?";
        AnswerReproductive = "Survival guide";
        AnswerApplication = "Tool box";
        AnswerMeaning = "Navigation system";
        AnswerProductive = "Camera";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeRoom : MonoBehaviour {
    //methods: EscapeRoom.Position, EscapeRoom.Language, EscapeRoom.Question, EscapeRoom.AnswerReproductive, EscapeRoom.AnswerApplication, EscapeRoom.AnswerMeaning en EscapeRoom.AnswerProductive

    public string Position { get; set; }
    public string Language { get; set; }

    public string Question { get; set; }
    public string AnswerReproductive { get; set; }
    public string AnswerApplication { get; set; }
    public string AnswerMeaning { get; set; }
    public string AnswerProductive { get; set; }

    private void Start()
    {
        Question = "Which tool would you bring with you?";
        AnswerReproductive = "Survival guide";
        AnswerApplication = "Tool box";
        AnswerMeaning = "Navigation system";
        AnswerProductive = "Camera";
    }
}

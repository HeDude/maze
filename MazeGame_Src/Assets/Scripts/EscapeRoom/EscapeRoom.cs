using System;
using System.Text.Json;

public class EscaperoomConfig
{
    public EscaperoomPosition Positions { get; set; }
}
public class EscaperoomInfo
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Reference { get; set; }
}
public class EscaperoomPosition
{
    public EscaperoomInfo Center { get; set; }
    public EscaperoomInfo Topleft { get; set; }
    public EscaperoomInfo Top { get; set; }
    public EscaperoomInfo Topright { get; set; }
    public EscaperoomInfo Right { get; set; }
    public EscaperoomInfo Bottomright { get; set; }
    public EscaperoomInfo Bottom { get; set; }
    public EscaperoomInfo Bottomleft { get; set; }
    public EscaperoomInfo Left { get; set; }
}

public class EscaperoomQuestion
{
    public string Reproductive { get; set; }
    public string Application { get; set; }
    public string Meaning { get; set; }
    public string Productive { get; set; }
}

public class EscapeRoom
{
    public string Position { get; set; }
 
    public string Question
    {
        get
        {
            if ( QuestionIndex() == "" )
            {
                return "";
            }
            string QuestionText = LanguageConfig.RootElement.GetProperty(QuestionIndex()).GetString();
            if ( QuestionText == null )
            {
                return "";
            }
            return QuestionText;
        }
    }
    public string AnswerReproductive
    {
        get
        {
            EscaperoomQuestion Answers = QuestionAnswers();
            return AnswerText( Answers.Reproductive );
         }
    }
    public string AnswerApplication
    {
        get
        {
            EscaperoomQuestion Answers = QuestionAnswers();
            return AnswerText( Answers.Application );
       }
    }
    public string AnswerMeaning
     {
        get
        {
            EscaperoomQuestion Answers = QuestionAnswers();
            return AnswerText( Answers.Meaning );
         }
    }
   public string AnswerProductive
     {
        get
        {
            EscaperoomQuestion Answers = QuestionAnswers();
            return AnswerText( Answers.Productive );
        }
    }

    private readonly JsonSerializerOptions options = new JsonSerializerOptions
    {
        AllowTrailingCommas = true
    };
    private readonly EscaperoomConfig EscaperoomConfig;
    private readonly JsonDocument QuestionsConfig;
    private readonly JsonDocument LanguageConfig;
    private EscaperoomQuestion EscaperoomQuestion;

    public EscapeRoom(string escaperooms_json, string questions_json, string language_json)
    {
        EscaperoomConfig = JsonSerializer.Deserialize<EscaperoomConfig>(escaperooms_json, options);
        LanguageConfig = JsonDocument.Parse(language_json);
        QuestionsConfig = JsonDocument.Parse(questions_json);
    }
    private string QuestionIndex()
    {
        if ( Position == null || Position == "" )
        {
            return "";
        }
        var Property = EscaperoomConfig.Positions.GetType().GetProperty( Position );
        if ( Property == null )
        {
            return "";
        }
        EscaperoomInfo position = (EscaperoomInfo)Property.GetValue( EscaperoomConfig.Positions, null );
        return position.Reference;
    }
    private EscaperoomQuestion QuestionAnswers()
    {
        if ( QuestionIndex() == "" )
        {
            return new EscaperoomQuestion();
        }
        string Property = QuestionsConfig.RootElement.GetProperty(QuestionIndex()).ToString();
        return JsonSerializer.Deserialize<EscaperoomQuestion>(Property, options);
    }

    private string AnswerText( string AnswerIndex )
    {
        if ( AnswerIndex == null || AnswerIndex == "")
        {
            return "";
        }
        return LanguageConfig.RootElement.GetProperty(AnswerIndex).GetString();
    }
}
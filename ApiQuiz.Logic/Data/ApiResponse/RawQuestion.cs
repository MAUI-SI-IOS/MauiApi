namespace ApiQuiz.Logic.Data.ApiResponse;

using System.Text.Json.Serialization;
using BusQuestion = Bus.Question;


public class RawQuestion
{
    [JsonPropertyName("question")]
    public string Question { get; set; }
    [JsonPropertyName("correct_answer")]
    public string GoodAnswer { get; set; }
    [JsonPropertyName("incorrect_answers")]
    public List<string> BadAnswers { get; set; }


    public override string ToString() => $"{Question},\nGood answer: {GoodAnswer}\nBad answer:\n{string.Join('\n', BadAnswers)}\n\n";

    public BusQuestion IntoQuestion() =>  new(this);
}

using Microsoft.Maui.Controls;
namespace ApiQuiz;

[QueryProperty(nameof(ScoreQuery), "score")]
[QueryProperty(nameof(QuizLengthQuery), "quizLenght")]
public partial class ResultPage : ContentPage, IQueryAttributable
{
    // backing property used for query parsing
    string QuizLengthQuery
    {
        set
        {
            if (int.TryParse(value, out var s))
            {
                QuizLength = s;
            }
            else
            {
                QuizLength = 0;
            }
        }
    }
    string ScoreQuery
    {
        set
        {
            if (int.TryParse(value, out var s))
            {
                Score = s;
            }
            else
            {
                Score = 0;
            }
        }
    }

    public int Score { get; private set; }
    public int QuizLength { get; private set; }
    public ResultPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ScoreLabel.Text = $"Score: {Score}/{QuizLength}";
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Score = (int)query["score"];
        QuizLength = (int)query["quizLenght"];
    }
}
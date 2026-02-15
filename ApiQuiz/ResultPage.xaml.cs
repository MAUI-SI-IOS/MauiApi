using Microsoft.Maui.Controls;
namespace ApiQuiz;

[QueryProperty(nameof(ScoreQuery), "score")]
public partial class ResultPage : ContentPage, IQueryAttributable
{
    // backing property used for query parsing
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

    public ResultPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ScoreLabel.Text = $"Score: {Score}";
        }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Score = (int)query["score"];
    }
}
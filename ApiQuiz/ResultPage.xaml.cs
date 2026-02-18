namespace ApiQuiz;

using System.Linq;
using Microsoft.Maui.Controls;

[QueryProperty(nameof(ScoreQuery), "score")]
[QueryProperty(nameof(QuizLengthQuery), "quizLength")]
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

    public TimeSpan[] TimeSpentAnswering { get; private set; }

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
        PopulateTimes();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Score = (int)query["score"];
        QuizLength = (int)query["quizLength"];
        TimeSpentAnswering = (TimeSpan[])query["timespan"];
    }

    private void PopulateTimes()
    {
        TimesFlex.Children.Clear();

        if (TimeSpentAnswering == null || TimeSpentAnswering.Length == 0)
        {
            TimesFlex.Children.Add(new Label
            {
                Text = "No timing data.",
                TextColor = Colors.Black,
                Margin = new Thickness(6)
            });

            TotalTimeLabel.Text = "Total: 00:00.000";
            AverageTimeLabel.Text = "Average: 00:00.000";
            return;
        }

        long totalTicks = 0;

        for (var i = 0; i < TimeSpentAnswering.Length; i++)
        {
            var t = TimeSpentAnswering[i];
            totalTicks += t.Ticks;
            var text = $"{i + 1}. {t.ToString(@"mm\:ss\.fff")}";
            
            var chip = new Border
            {
                Stroke = Colors.LightGray,
                StrokeThickness = 0.5,
                BackgroundColor = Colors.White,
                Padding = new Thickness(8, 6),
                Margin = new Thickness(4),
                StrokeShape = new Microsoft.Maui.Controls.Shapes.RoundRectangle
                {
                    CornerRadius = new CornerRadius(8)
                },
                Content = new Label
                {
                    Text = text,
                    TextColor = Colors.Black,
                    FontSize = 14
                }
            };

            TimesFlex.Children.Add(chip);
        }

        var total = new TimeSpan(totalTicks);
        var average = new TimeSpan(totalTicks / TimeSpentAnswering.Length);

        TotalTimeLabel.Text = $"Total: {total.ToString(@"mm\:ss\.fff")}";
        AverageTimeLabel.Text = $"Average: {average.ToString(@"mm\:ss\.fff")}";
    }

    protected async void Restart(object? sender, EventArgs arg)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}
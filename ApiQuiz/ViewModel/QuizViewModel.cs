namespace ApiQuiz.ViewModel;

using Logic.GameService;
using Logic.Data.UI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


public partial class QuizViewModel(
    IGameCreator creator
) : ObservableObject {
    //------------- logic of quiz -------------//
    IGame _game;
    IEnumerator<Question> _iterator;


//-------------   variables   -------------//
[ObservableProperty]
string currentQuestion;
[ObservableProperty]
Answer[] answers;

    public async Task LoadQuizAsync()
    {   
        _game = await creator.CreateGame();
        _iterator = _game.GetEnumerator();
        GetNextQuestion();
    }


    public void GetNextQuestion()
    {
        if(_iterator.MoveNext())
        {
            var current = _iterator.Current;

            CurrentQuestion = current.Value;
            Answers         = current.PossibleAnswers;
        }
        else _ = GoToResultAsync();
    }

    [RelayCommand]
    public void Answer(int position)
    {
        _game.CheckAnswer(position);
        GetNextQuestion();
    }

    private async Task GoToResultAsync()
    {
        // TODO: pass the result to the result page
        var query = new Dictionary<string, object>
        {
            ["score"] = _game.Score,
        };

    await Shell.Current.GoToAsync(nameof(ResultPage), query);
    }


}
using ApiQuiz.Logic.TimingService;

namespace ApiQuiz.ViewModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Logic.Data.UI;
using Logic.GameService;
using Microsoft.Maui.Controls;



public partial class QuizViewModel(
    IGameCreator creator
) : ObservableObject
    {
        //------------- logic of quiz -------------//
        IGame _game;
        IEnumerator<Question> _iterator;

        private TimerService _gameTimer;


        //-------------   variables   -------------//
        [ObservableProperty]
        string currentQuestion;
        [ObservableProperty]
        Answer[] answers;
        [ObservableProperty]
        string score;           // score afficher
        [ObservableProperty]
        string gameLenght;      // length of quiz
        [ObservableProperty]
        double ratio;           // progressBar
        [ObservableProperty]
        int numberQuestion;     //question the person is at
        [ObservableProperty]
        Color bColor;          //background color

        public async Task LoadQuizAsync()
        {
            try
            {
                _game = await creator.CreateGame();
                _iterator = _game.GetEnumerator();

                _gameTimer = new TimerService(_game.Length);

                Score = "0";
                numberQuestion = 0;
                GameLenght = _game.Length.ToString();
                GetNextQuestion();
            }
            catch
            {
                //Pour Hnadle les Too many request
                await Shell.Current.DisplayAlertAsync("Error", "internal error try again in a moment", "OK");
                await Shell.Current.GoToAsync("..");
            }
        }


        
    public void GetNextQuestion()     
    {
        BColor = Colors.AliceBlue; // default color
            
        if (_iterator.MoveNext())    
        {
            var current = _iterator.Current;

            CurrentQuestion = current.Value;
            Answers = current.PossibleAnswers;
            _gameTimer.Start();
        }
        else _ = GoToResultAsync();
    }

        [RelayCommand]
        public async Task Answer(int position)
        {
            _gameTimer.Stop();
            _game.CheckAnswer(position);
            // update page variable
            Score = _game.Score.ToString();
            Ratio = (double)++numberQuestion / _game.Length;

            // update ui
            BColor = _game.IsGoodAnswer(position) ? Colors.Green : Colors.Red;
            await Task.Delay(1000);
            GetNextQuestion();
        }

        private async Task GoToResultAsync()
        {
        // TODO: pass the result to the result page
        var query = new Dictionary<string, object>
        {
            ["score"]      = _game.Score,
            ["quizLength"] = _game.Length,
            ["timespan"]   = _gameTimer.GetResult(),
        };

            await Shell.Current.GoToAsync(nameof(ResultPage), query);
        }

}

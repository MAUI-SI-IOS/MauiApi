using ApiQuiz.Logic.Data.UI;
using ApiQuiz.GameService;
using ApiQuiz.Logic.GameService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApiQuiz.ViewModel
{
    public partial class QuizViewModel(
        IGameCreator creator
    ) : ObservableObject {
        //------------- logic of quiz -------------//
        IGame _game;
        IEnumerator<Question> _iterator;
        int numberQuestion;

        //-------------   variables   -------------//
        [ObservableProperty]
        string currentQuestion;
        [ObservableProperty]
        Answer[] answers;
        [ObservableProperty]
        string score;           // score afficher
        [ObservableProperty]
        string gameSize;        // length of quiz
        [ObservableProperty]
        double ratio;           // progressBar               
        [ObservableProperty]
        Color bColor;

        public async Task LoadQuizAsync()
        {   
            _game     = await creator.CreateGame();
            _iterator = _game.GetEnumerator();
            Score     = "0";
            numberQuestion = 0;
            GameSize  = _game.GetLenght().ToString();
            GetNextQuestion();
        }
        public void GetNextQuestion()
        {
            BColor = Colors.AliceBlue;
            if (_iterator.MoveNext())
            {
                var current = _iterator.Current;
                CurrentQuestion = current.Str;
                Answers = current.Array;
            }
            else _ = GoToResultAsync();
        }
        [RelayCommand]
        public async Task Answer(int position)
        {
            _game.CheckAnswer(position);
            
            // update page variable
            Score = _game.GetScore().ToString();
            Ratio =  (double)++numberQuestion/ _game.GetLenght();

            // update ui
            BColor = _game.IsGoodAnswer(position) ? Colors.Green : Colors.Red;
            await Task.Delay(1000);

            GetNextQuestion();
        }


        private static async Task GoToResultAsync()
        {
            // TODO: pass the result to the result page
            await Shell.Current.GoToAsync(nameof(ResultPage));
        }


    }
}

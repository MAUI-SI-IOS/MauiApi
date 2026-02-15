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


        //-------------   variables   -------------//
        [ObservableProperty]
        string currentQuestion;
        [ObservableProperty]
        Answer[] answers;
        [ObservableProperty]
        string score;

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

                CurrentQuestion = current.Str;
                Answers         = current.Array;
            }
            else _ = GoToResultAsync();
        }

        [RelayCommand]
        public void Answer(int position)
        {
            _game.CheckAnswer(position);
            Score = _game.GetScore().ToString();
            GetNextQuestion();
        }

        private static async Task GoToResultAsync()
        {
            // TODO: pass the result to the result page
            await Shell.Current.GoToAsync(nameof(ResultPage));
        }


    }
}

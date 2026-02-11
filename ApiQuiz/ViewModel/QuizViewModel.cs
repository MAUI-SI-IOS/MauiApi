using ApiQuiz.Logic.Data.UI;
using ApiQuiz.GameService;
using ApiQuiz.Logic.Data.UI;
using ApiQuiz.Logic.GameService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace ApiQuiz.ViewModel
{
    public partial class QuizViewModel : ObservableObject
    {
        //------------- logic of quiz -------------//
        IGameCreator _creator;
        IGame _game;
        IEnumerator<Question> _iterator;


        //-------------   variables   -------------//
        [ObservableProperty]
        string currentQuestion;
        [ObservableProperty]
        Answer[] answers;

        public QuizViewModel(IGameCreator creator)
        {
            _creator = creator;
        }
        public async Task LoadQuizAsync()
        {   
            _game = await _creator.CreateGame();
            _iterator = _game.GetEnumerator();
            GetNextQuestion();
        }


        [RelayCommand]
        public void GetNextQuestion()
        {
            if(_iterator.MoveNext())
            {
                var current = _iterator.Current;

                CurrentQuestion = current.Str;
                Answers         = current.Array;
            }
            else
            {
                //end game
            }
        }

        [RelayCommand]
        public void Answer(int x)
        {
            _game.CheckAnswer(x);
        }
    }
}

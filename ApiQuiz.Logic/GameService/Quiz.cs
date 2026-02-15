using System.Collections;
using ApiQuiz.GameService;
using BusQuestion = ApiQuiz.Logic.Data.Bus.Question;
using UIQuestion = ApiQuiz.Logic.Data.UI.Question;

namespace ApiQuiz.Logic.GameService
{
    public class Quiz(BusQuestion[] questions) : IGame
    {
        BusQuestion?   currentQuestion = null;
        public UIQuestion? CurrentUiQuestion => currentQuestion?.GetUIQuestion();
        public int Score { get; private set; } = 0;

        public void CheckAnswer(int x) 
        {
            if(currentQuestion?.IsGoodAnswer(x) == true) 
                Score += 1;
        }

        public IEnumerator<UIQuestion> GetEnumerator()
        {
            foreach (BusQuestion q in questions)
            {
                currentQuestion = q;
                yield return q.GetUIQuestion();
            }
        }
    }
}

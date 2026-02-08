using ApiQuiz.Logic.ApiService;
using ApiQuiz.Logic.TimingService;
using System.Collections;
using ApiQuiz.GameService;
namespace ApiQuiz.Logic.GameService
{
    public class Quiz : IGame
    {
        Data.bus.Question[] questions;
        Data.bus.Question?   currentQuestion;
        int score;


        public Quiz(Data.bus.Question[] questions)
        {
            this.questions = questions;

            currentQuestion = null;
            score  = 0;
        }

        public void CheckAnswer(int x){
            if(currentQuestion?.IsGoodAnswer(x) == true) {
                score += 1;
            }
        }

        public IEnumerator<Data.UI.Question> GetEnumerator()
        {
            foreach(var q in this.questions)
            {
                currentQuestion = q;
                yield return q.GetUIQuestion();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

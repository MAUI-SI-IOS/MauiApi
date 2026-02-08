using ApiQuiz.Data;
using ApiQuiz.Logic.ApiService;
using ApiQuiz.Logic.TimingService;
using System.Collections;
using ApiQuiz.GameService;
using ApiQuiz.Logic.Data;

namespace ApiQuiz.Logic.GameService
{
    public class Quiz : IGame
    {
        Question[] questions;
        Question?   currentQuestion;
        int score;


        public Quiz(Question[] questions)
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

        public IEnumerator<UIQuestion> GetEnumerator()
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

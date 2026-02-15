using ApiQuiz.Logic.ApiService;
using ApiQuiz.Logic.TimingService;
using System.Collections;
using ApiQuiz.GameService;
using ApiQuiz.Logic.Data.bus;
using ApiQuiz.Logic.Data.UI;

namespace ApiQuiz.Logic.GameService
{
    public class Quiz : IGame
    {
        Data.bus.Question[] questions;
        Data.bus.Question?  currentQuestion;
        int score;

        public Quiz(Data.bus.Question[] questions)
        {
            this.questions = questions;
            currentQuestion = null;
            score  = 0;
        }

        public void CheckAnswer(int x){
            if(currentQuestion?.IsGoodAnswer(x) == true) {
                //stop timer 
                score += 1;
            }
        }
        public bool IsGoodAnswer(int x)
        {
            return currentQuestion?.IsGoodAnswer(x) ?? true;
        }

        public int GetScore()
        {
            return score;
        }
        public int GetLenght()
        {
            return questions.Length;
        }

        public IEnumerator<Data.UI.Question> GetEnumerator()
        {
            foreach(var q in this.questions)
            {
                //start timer

                //change currentquestion
                currentQuestion = q;

                //return formated answer
                yield return q.GetUIQuestion();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

namespace ApiQuiz.Logic.GameService;

using System.Collections;
using System.ComponentModel.DataAnnotations;
using BusQuestion = Data.Bus.Question;
using UIQuestion = Data.UI.Question;


public class Quiz(BusQuestion[] questions) : IGame
{
    BusQuestion?   currentQuestion = null;
    public int Score { get; private set; } = 0;
    int IGame.Score => Score;
    int IGame.Length => questions.Length;

    public void CheckAnswer(int x) 
    {
        if(currentQuestion?.IsGoodAnswer(x) == true) 
            Score += 1;
    }
    public bool IsGoodAnswer(int x) => currentQuestion?.IsGoodAnswer(x) ?? true;


    public IEnumerator<UIQuestion> GetEnumerator()
    {
        foreach (BusQuestion q in questions)
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

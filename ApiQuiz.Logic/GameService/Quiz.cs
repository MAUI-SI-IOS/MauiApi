namespace ApiQuiz.Logic.GameService;

using BusQuestion = Data.Bus.Question;
using UIQuestion = Data.UI.Question;


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

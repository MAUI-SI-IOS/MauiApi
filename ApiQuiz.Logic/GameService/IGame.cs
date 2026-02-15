using ApiQuiz.Logic.Data.UI;
using System.Collections;

// Aliases
using UIQuestion = ApiQuiz.Logic.Data.UI.Question;

namespace ApiQuiz.Logic.GameService;

public interface IGame
{
    void CheckAnswer(int x);
    IEnumerator<UIQuestion> GetEnumerator();
    int Score { get; }
}

using ApiQuiz.Logic.Data.UI;

// Aliases
using UIQuestion = ApiQuiz.Logic.Data.UI.Question;

namespace ApiQuiz.GameService;

public interface IGame
{
    public void CheckAnswer(int x);
    IEnumerator<UIQuestion> GetEnumerator();
}

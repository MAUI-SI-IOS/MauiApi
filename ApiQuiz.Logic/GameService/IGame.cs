using ApiQuiz.Logic.Data.UI;


using ApiQuiz.Logic.Data.UI;

namespace ApiQuiz.GameService;

public interface IGame : IEnumerable<Question>
{
    public void CheckAnswer(int x);
    public int GetScore();
}

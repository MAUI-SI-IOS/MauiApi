


using ApiQuiz.Logic.Data;

namespace ApiQuiz.GameService;

public interface IGame : IEnumerable<UIQuestion>
{
    public void CheckAnswer(int x);

}

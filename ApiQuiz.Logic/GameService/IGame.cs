using ApiQuiz.Logic.Data.UI;
using System.Collections;

// Aliases
using UIQuestion = ApiQuiz.Logic.Data.UI.Question;

namespace ApiQuiz.Logic.GameService;

public interface IGame: IEnumerable<UIQuestion>
{
    public void CheckAnswer(int x);
    public bool IsGoodAnswer(int x);
    int Score { get; }
    int Length { get; }
}

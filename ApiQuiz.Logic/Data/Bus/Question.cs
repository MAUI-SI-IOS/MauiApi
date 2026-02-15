namespace ApiQuiz.Logic.Data.Bus;

using ApiQuiz.Logic.Data.ApiResponse;

using BusAnswer = Answer;
using UIQuestion = UI.Question;
using UIAnswer = UI.Answer;


public class Question
{
    string Value;
    BusAnswer[] possibleAnswers;
    public BusAnswer GoodAnswer { get; private set; }

    internal Question(RawQuestion raw)      // Can only be built from RawQuestion
    {
        GoodAnswer = new BusAnswer(raw.GoodAnswer, true);

        Random random = new Random();
        possibleAnswers = raw.BadAnswers
            .AsEnumerable()
            .Select(ans => new BusAnswer(ans, false))
            .Append(GoodAnswer)
            .OrderBy(_ => random.Next())
            .ToArray();

        Value = raw.Question;
    }

    public UIQuestion GetUIQuestion() {
        return new UIQuestion(
            Value, 
            possibleAnswers
                .Select((answer, i) => 
                    new UIAnswer(
                        i,
                        answer.Value
                    )
                ).ToArray());
    }
    public bool IsGoodAnswer(int x) => possibleAnswers[x].IsRightAnswer;

} 

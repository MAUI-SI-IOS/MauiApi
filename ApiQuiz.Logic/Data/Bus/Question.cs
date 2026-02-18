namespace ApiQuiz.Logic.Data.Bus;

using ApiQuiz.Logic.Data.ApiResponse;
using System;
using System.Linq;
using System.Net;

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
        // HTML-decode API values so entities like &quot; or &#039; become real quotes/apostrophes
        var decodedQuestion = WebUtility.HtmlDecode(raw.Question ?? string.Empty);
        var decodedGoodAnswer = WebUtility.HtmlDecode(raw.GoodAnswer ?? string.Empty);

        GoodAnswer = new BusAnswer(decodedGoodAnswer, true);

        Random random = new Random();
        possibleAnswers = raw.BadAnswers
            .AsEnumerable()
            .Select(ans => new BusAnswer(WebUtility.HtmlDecode(ans ?? string.Empty), false))
            .Append(GoodAnswer)
            .OrderBy(_ => random.Next())
            .ToArray();

        Value = decodedQuestion;
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

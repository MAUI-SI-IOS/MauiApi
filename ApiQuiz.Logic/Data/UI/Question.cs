namespace ApiQuiz.Logic.Data.UI;

using UIAnswer = Answer;
public record Question(
    string Value,
    UIAnswer[] PossibleAnswers
);


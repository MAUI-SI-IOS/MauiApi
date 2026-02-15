namespace ApiQuiz.Logic.GameService;

using ApiService;

public class QuizGameCreator(
    UrlBuilder builder
) : IGameCreator {

    private readonly Api _api = new(builder);

    public async Task<IGame> CreateGame()
    {
        var result = await _api.fetch();
        var questions = result.Select(r => r.IntoQuestion())
                                .ToArray();

        return new Quiz(questions);
    }
}

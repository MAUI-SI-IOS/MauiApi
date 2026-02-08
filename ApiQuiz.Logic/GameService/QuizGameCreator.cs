using ApiQuiz.GameService;
using ApiQuiz.Logic.ApiService;
using ApiQuiz.Logic.Data.bus;

namespace ApiQuiz.Logic.GameService
{
    public class QuizGameCreator : IGameCreator
    {
        Api _api;
        Question[] questions;

        public QuizGameCreator(UrlBuilder builder){
            //construire api
            _api = new Api(builder);
        }

        public async Task<IGame> CreateGame()
        {
            var result = await _api.fetch();
            this.questions = result?.Select(r => r.intoQuestion())
                                    .ToArray()
                                    ?? Array.Empty<Question>();

            return new Quiz(questions);
        }

 
    }
}

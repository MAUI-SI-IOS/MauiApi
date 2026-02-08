using ApiQuiz.Data;
using ApiQuiz.GameService;
using ApiQuiz.Logic.ApiService;
using ApiQuiz.Logic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiQuiz.Logic.GameService
{
    internal class QuizGameCreator : IGameCreator
    {
        Api _api;
        Question[] questions;

        public QuizGameCreator(UrlBuilder builder){
            _api = new Api(builder);
            LoadAsyncQuestion();
        }

        public IGame CreateGame()
        {
            return new Quiz(questions);
        }

        private async void LoadAsyncQuestion()
        {
            var result = await _api.fetch();
            this.questions = result?.Select(r => r.intoQuestion())
                                    .ToArray()
                                    ?? Array.Empty<Question>();
        }
    }
}

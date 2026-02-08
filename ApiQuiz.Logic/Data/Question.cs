using ApiQuiz.Logic.Data;
using ApiQuiz.Logic.Data.ApiResponse;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiQuiz.Data
{
    public class Question
    {
        string question;

        (string, bool)[] answers;

        internal Question(RawQuestion raw)      // Can only be built from RawQuestion
        {
            Random random = new Random();
            this.answers = raw.badAnswer.AsEnumerable()
                                        .Select(i => (i, false))
                                        .Append((raw.goodAnswer, true))
                                        .OrderBy(i => random.Next())
                                        .ToArray();

            this.question = raw.question;
        }

        public IEnumerable<(string,bool)> GetGoodAnswers() => answers.Where(a => a.Item2 == true);
        public UIQuestion GetUIQuestion() {
            return new UIQuestion(question, answers.Select(
                                                        (i, index) => (index, i.Item1)
                                                   )
                                                   .ToArray());
         }
        public bool IsGoodAnswer(int x) => answers[x].Item2;

        public Question GetData()
        {
            return this;
        }
    } 
}

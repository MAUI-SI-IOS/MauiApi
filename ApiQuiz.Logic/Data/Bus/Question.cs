using ApiQuiz.Logic.Data.ApiResponse;
using ApiQuiz.Logic.Data.Bus;
using ApiQuiz.Logic.Data.UI;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiQuiz.Logic.Data.bus
{
    public class Question
    {
        string question;
        Bus.Answer[] answers;

        internal Question(RawQuestion raw)      // Can only be built from RawQuestion
        {
            Random random = new Random();
            this.answers = raw.badAnswer.AsEnumerable()
                                        .Select(i => new Bus.Answer(i, false))
                                        .Append(new Bus.Answer(raw.goodAnswer, true))
                                        .OrderBy(i => random.Next())
                                        .ToArray();

            this.question = raw.question;
        }

        public IEnumerable<Bus.Answer> GetGoodAnswers() => answers.Where(a => a.isTrue == true);
        public UI.Question GetUIQuestion() {
            return new UI.Question(question, answers.Select((answer, i) => new UI.Answer(i, answer.str)).ToArray());
         }
        public bool IsGoodAnswer(int x) => answers[x].isTrue;

        public Question GetData()
        {
            return this;
        }
    } 
}

using ApiQuiz.Logic.Data;
using System;
using System.Collections.Generic;
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

        public IEnumerable<(string,bool)> GetAnswers() => answers;
        public (int, string)[] getAnswers() => answers.Select((i,index) => (index, i.Item1)).ToArray();
        public bool IsGoodAnswer(int x) => answers[x].Item2;
    } 
}

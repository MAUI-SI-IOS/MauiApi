using ApiQuiz.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiQuiz.Logic.Data
{
    public class RawQuestion
    {
        [JsonPropertyName("question")]
        public string question { get; set; }
        [JsonPropertyName("correct_answer")]
        public string goodAnswer { get; set; }
        [JsonPropertyName("incorrect_answers")]
        public List<string> badAnswer { get; set; }


        public override string ToString()
        {
            string output = $"{question},\nGood answer: {goodAnswer}\nBad answer:\n";

            foreach (var b in badAnswer)
            {
                output += b.ToString() + "\n";
            }
            output += "\n\n";
            return output;
        }

        public Question intoQuestion()
        {
            return new Question(this);
        }
    }
}

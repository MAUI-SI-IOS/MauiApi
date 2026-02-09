using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using ApiQuiz.Logic.Data.bus;

namespace ApiQuiz.Logic.Data.ApiResponse
{
    public class RawQuestion
    {
        [JsonPropertyName("question")] 
        public string question { get; set; } = string.Empty;

        [JsonPropertyName("correct_answer")] 
        public string goodAnswer { get; set; } = string.Empty;

        [JsonPropertyName("incorrect_answers")]
        public List<string> badAnswer { get; set; } = [];


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

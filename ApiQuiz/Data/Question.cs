using System;
using System.Collections.Generic;
using System.Text;

namespace ApiQuiz.Data
{


    public record QuestionResponse
    {
       public Question[] results { get; set; }
    }


    public class Question
    {
        public string question { get; set; }
        public string goodAnswer { get; set; }
        public string[] badAnswer { get; set; }
    }
}

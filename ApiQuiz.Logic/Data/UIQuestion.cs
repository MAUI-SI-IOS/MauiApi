using System;
using System.Collections.Generic;
using System.Text;

namespace ApiQuiz.Logic.Data
{
    public record UIQuestion(string question, (int, string)[] array);

}

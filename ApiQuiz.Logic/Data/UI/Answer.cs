using System;
using System.Collections.Generic;
using System.Text;

namespace ApiQuiz.Logic.Data.UI
{
    public record Answer(
        int Index,
        string Value
    ) {
        public override string ToString()
        {
            return $"{Index}, {Value}";
        }
    };
}

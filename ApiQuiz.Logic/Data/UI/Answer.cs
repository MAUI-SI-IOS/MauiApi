using System;
using System.Collections.Generic;
using System.Text;

namespace ApiQuiz.Logic.Data.UI
{
    public partial record Answer(int Index, string Str)
    {
        public override string ToString()
        {
            return $"{Index}, {Str}";
        }
    };
}

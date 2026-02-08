using System;
using System.Collections.Generic;
using System.Text;

namespace ApiQuiz.Logic.Data.UI
{
    public record Question(string Str, UI.Answer[] Array);

}

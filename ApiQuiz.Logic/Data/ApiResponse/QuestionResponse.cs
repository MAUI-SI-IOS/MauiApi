using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiQuiz.Logic.Data.ApiResponse
{
    public record QuestionResponse
    {
        public RawQuestion[] results { get; set; }
    }
  

}

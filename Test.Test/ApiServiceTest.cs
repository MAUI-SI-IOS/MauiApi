using ApiQuiz.ApiService;
using ApiQuiz.Data;


namespace Test.Test;

public class TestApi
{
    [Fact]
    public void FetchData()
    {
          UrlBuilder builder = new UrlBuilder()
                              .SetCategory(Category.History)  
                              .SetAmount(10);

          Api service = new Api(builder);

          var task = service.fetch();
          List<Question> questions = task.Result
                                         .ToList<Question>();
          
          Assert.True(10 == questions.Count);


    }
}

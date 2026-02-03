using ApiQuiz.ApiService;
using ApiQuiz.Data;
using ApiQuiz.Logic.Data;


namespace Test.Test;

public class TestApi
{
    [Fact]
    public void FetchData()
    {
          const int size = 11;

          UrlBuilder builder = new UrlBuilder()
                              .SetCategory(Category.History)  
                              .SetAmount(size);

          Api service = new Api(builder);

          var task = service.fetch();
          List<RawQuestion> questions = task.Result
                                         .ToList<RawQuestion>();
          
          Assert.True(size == questions.Count);

          //besoin de trouver un test pour assurer que le formatage est toujours bon 
          //visuellement tous parait bien
          foreach(RawQuestion q in questions)
          {
            Console.WriteLine(q.ToString());
          }   
    }



    [Fact]
    public void TestRandomness()
    {

    }
}

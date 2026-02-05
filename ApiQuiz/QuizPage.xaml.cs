using ApiQuiz.ViewModel;

namespace ApiQuiz;


public partial class QuizPage : ContentPage
{

    public string category { get; set; }
    public string amount { get; set; }
    public QuizPage(QuizViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}
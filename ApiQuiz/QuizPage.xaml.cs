using ApiQuiz.ViewModel;

namespace ApiQuiz;


public partial class QuizPage : ContentPage
{

    public string category { get; set; } = string.Empty;
    public string amount { get; set; } = string.Empty;
    public QuizPage(QuizViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}
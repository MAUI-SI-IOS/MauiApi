using ApiQuiz.ViewModel;

namespace ApiQuiz;


public partial class QuizPage : ContentPage
{
    public QuizPage(QuizViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is QuizViewModel vm)
        {
            await vm.LoadQuizAsync();
        }
    }
}
using ApiQuiz.Logic.ApiService;
using ApiQuiz.ViewModel;

namespace ApiQuiz
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;        
        }


        public void StartQuiz(object? sender, EventArgs args)
        {
            _ = Shell.Current.GoToAsync(nameof(QuizPage));
        }

    }
}

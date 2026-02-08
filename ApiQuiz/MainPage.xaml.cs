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


        public async void StartQuiz(object? sender, EventArgs args)
        {
            await Shell.Current.GoToAsync(nameof(QuizPage));
        }

    }
}

using ApiQuiz.Logic.ApiService;
using ApiQuiz.Logic.GameService;
using ApiQuiz.ViewModel;
using Microsoft.Extensions.Logging;

namespace ApiQuiz
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            //pour tuto ou jai vu ceci
            //https://www.youtube.com/watch?v=ddmZ6k1GIkM&list=PLdo4fOcmZ0oUBAdL2NwBpDs32zwGqb9DY&index=6&t=348s
            builder.Services.AddSingleton<UrlBuilder>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();


            builder.Services.AddTransient<IGameCreator, QuizGameCreator>();

            builder.Services.AddTransient<QuizPage>();
            builder.Services.AddTransient<QuizViewModel>();


            return builder.Build();
        }
    }
}

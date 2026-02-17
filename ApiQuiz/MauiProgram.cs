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

            // ils sont enregistres comme des singletons,
            // car ils sont souvent utiliser et ils ne sont pas reactif
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddScoped<UrlBuilder>();
            builder.Services.AddSingleton<Api>();
            // Nous reinitialisons l'objet afin d'avoir un nouveau quiz
            // tous les fois que ces objets sont demandes
            builder.Services.AddTransient<IGameCreator, QuizGameCreator>();
            builder.Services.AddTransient<QuizPage>();
            builder.Services.AddTransient<QuizViewModel>();

            return builder.Build();
        }
    }
}

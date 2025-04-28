using Microsoft.Extensions.Logging;
using ChadWare.Services;    
using ChadWare.ViewModels;
using ChadWare.Views.Pages;

namespace ChadWare
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

            // Register services
            builder.Services.AddSingleton<IDataService, LocalDataService>();

            // Register pages and viewmodels
            builder.Services.AddTransient<SignIn>();
            builder.Services.AddTransient<SignInViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

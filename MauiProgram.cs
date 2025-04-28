using Microsoft.Extensions.Logging;
using ChadWare.Services;
using ChadWare.Controllers;    
using ChadWare.Views.Pages;    // so CartPage is known

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

            // your registrations
            builder.Services.AddSingleton<IDataService, LocalDataService>();
            builder.Services.AddSingleton<CartController>();
            builder.Services.AddTransient<CartPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Build the MauiApp
            var mauiApp = builder.Build();

            // ← capture the IServiceProvider
            App.Services = mauiApp.Services;

            return mauiApp;
        }
    }
}

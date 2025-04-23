using Microsoft.Extensions.Logging;
using ChadWare.Services;
using Supabase;


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


            // 1) Supabase endpoint & key from your Dashboard → API settings
            var supabaseUrl = "https://zukkrgpezbltcktdrvdl.supabase.co";
            var supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Inp1a2tyZ3BlemJsdGNrdGRydmRsIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDUzNTM5MTYsImV4cCI6MjA2MDkyOTkxNn0.9Y0BythduNIpo_NSKgXNRF--FK6ZoyCGjPofy8u75g4";

            // 2) Create & initialize the client
            var supabaseClient = new Client(supabaseUrl, supabaseKey);
            // must await InitializeAsync before first use
            supabaseClient.InitializeAsync().GetAwaiter().GetResult();

            // 3) Register in DI
            builder.Services.AddSingleton<Client>(sp =>
            {
                var client = new Client(supabaseUrl, supabaseKey);
                client.InitializeAsync().GetAwaiter().GetResult();
                return client;
            });
            builder.Services.AddScoped<IDataService, SupabaseDataService>();


#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

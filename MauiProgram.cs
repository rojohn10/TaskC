using Microsoft.Extensions.Logging;
using TaskC.Mapping;
using TaskC.Services;
using TaskC.Validation;
using TaskC.ViewModels;
using TaskC.Views;

namespace TaskC
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

            // DI registrations
            builder.Services.AddSingleton<IncidentFormViewModel>();
            builder.Services.AddSingleton<IncidentFormPage>();

            builder.Services.AddHttpClient<IApiClient, ApiClient>(client =>
            {
                var baseUrl = GetBaseUrlForPlatform(DeviceInfo.Platform);
                client.BaseAddress = new Uri(baseUrl);
            });

            builder.Services.AddSingleton<IIncidentService, IncidentService>();
            builder.Services.AddSingleton<IIncidentMapper, SnakeCaseIncidentMapper>();
            builder.Services.AddSingleton<IFormValidator, IncidentFormValidator>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        //private static string GetBaseUrlForPlatform(DevicePlatform platform)
        //{
        //    return platform switch
        //    {
        //        var p when p == DevicePlatform.Android => "http://10.0.2.2:3001",
        //        var p when p == DevicePlatform.WinUI => "http://localhost:3001",
        //        var p when p == DevicePlatform.MacCatalyst => "http://localhost:3001",
        //        var p when p == DevicePlatform.iOS => "http://localhost:3001",
        //        _ => "http://localhost:3001"
        //    };
        //}

        private static string GetBaseUrlForPlatform(DevicePlatform platform) =>
            platform == DevicePlatform.Android
                ? "http://10.0.2.2:3001"
                : "http://localhost:3001";
    }
}

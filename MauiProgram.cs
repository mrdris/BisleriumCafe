using Microsoft.Extensions.Logging;

namespace BisleriumCafe
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
                   
                    fonts.AddFont("Font-Brands-Regular.otf", "FAB");
                    fonts.AddFont("Font-Free-Regular.otf", "FAR");
                    fonts.AddFont("Font-Free-Solid.otf", "FAS");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

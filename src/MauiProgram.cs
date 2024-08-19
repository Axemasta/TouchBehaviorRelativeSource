using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TouchBehaviorRelativeBinding.Fonts;
using TouchBehaviorRelativeBinding.Pages;
using TouchBehaviorRelativeBinding.ViewModels;

namespace TouchBehaviorRelativeBinding;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa-brands-400.ttf", FontConstants.FontAwesomeBrands);
                fonts.AddFont("fa-regular-400.ttf", FontConstants.FontAwesomeRegular);
                fonts.AddFont("fa-solid-900.ttf", FontConstants.FontAwesomeSolid);
            });

        builder.Services.AddTransientWithShellRoute<LandingPage, LandingViewModel>(nameof(LandingPage));
        builder.Services.AddTransientWithShellRoute<ReferencePage, ExampleViewModel>(nameof(ReferencePage));
        builder.Services.AddTransientWithShellRoute<RelativeSourcePage, ExampleViewModel>(nameof(RelativeSourcePage));

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
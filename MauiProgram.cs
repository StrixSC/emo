using System.Diagnostics;
using Emo.ModelView;
using Emo.Services;
using Microsoft.Extensions.Logging;

namespace Emo;

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
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddSingleton<EmoteViewModel>();
		builder.Services.AddTransient<EmoteWheelPage>();
		builder.Services.AddSingleton<RestService>();
#endif
		return builder.Build();
	}
}


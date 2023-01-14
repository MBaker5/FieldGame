using FieldGame.ViewModel;
using Microsoft.Extensions.Logging;

namespace FieldGame;

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
			}).UseMauiMaps();

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<PinViewModel>();
		builder.Services.AddSingleton<MainPage>();
		return builder.Build();
	}

}


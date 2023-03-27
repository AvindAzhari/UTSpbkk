using Microsoft.Extensions.Logging;
using UTSpbkk.Services;
using UTSpbkk.ViewModels;
using UTSpbkk.Views;

namespace UTSpbkk;

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
		// Services
		builder.Services.AddSingleton<IKontakService, KontakService>();

		//
		// Registration
		builder.Services.AddSingleton<KontakListPage>();
        builder.Services.AddSingleton<AddUpdateKontakDetail>();

        // View Models
        builder.Services.AddSingleton<KontakListPageViewModel>();
        builder.Services.AddSingleton<AddUpdateKontakDetailViewModel>();


        return builder.Build();
	}
}

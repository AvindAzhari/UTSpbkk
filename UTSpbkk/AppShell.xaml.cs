using UTSpbkk.Views;

namespace UTSpbkk;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddUpdateKontakDetail), typeof(AddUpdateKontakDetail));
	}
}

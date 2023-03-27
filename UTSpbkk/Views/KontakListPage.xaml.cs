using UTSpbkk.ViewModels;

namespace UTSpbkk.Views;

public partial class KontakListPage : ContentPage
{
	private KontakListPageViewModel _viewModel;
	public KontakListPage(KontakListPageViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
		base.OnAppearing();
        _viewModel.GetKontakListCommand.Execute(null);
    }
}
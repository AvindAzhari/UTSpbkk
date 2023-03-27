using UTSpbkk.ViewModels;

namespace UTSpbkk.Views;

public partial class AddUpdateKontakDetail : ContentPage
{
	public AddUpdateKontakDetail(AddUpdateKontakDetailViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}
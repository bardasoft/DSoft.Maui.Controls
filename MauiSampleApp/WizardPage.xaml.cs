namespace MauiSampleApp;

public partial class WizardPage : ContentPage
{

    private WizardPageViewModel _viewModel;

    public WizardPageViewModel ViewModel
    {
        get { return _viewModel; }
        set { _viewModel = value; BindingContext = _viewModel; }
    }

    public WizardPage()
	{
		InitializeComponent();

        ViewModel = new();
	}

    private async void OnCloseClicked(object? sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    //private async void GoBack(object sender, EventArgs e)
    //{
    //    await wzrControl.Back();
    //}

    //private async void GoForward(object sender, EventArgs e)
    //{
    //    await wzrControl.Forward();
    //}
}
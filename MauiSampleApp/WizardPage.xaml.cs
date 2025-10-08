namespace MauiSampleApp;

public partial class WizardPage : ContentPage
{
	public WizardPage()
	{
		InitializeComponent();
	}

    private async void OnCloseClicked(object? sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void GoBack(object sender, EventArgs e)
    {
        await wzrControl.Back();
    }

    private async void GoForward(object sender, EventArgs e)
    {
        await wzrControl.Forward();
    }
}
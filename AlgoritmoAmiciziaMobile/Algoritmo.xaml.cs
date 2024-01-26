namespace AlgoritmoAmiciziaMobile;

public partial class AlgoritmoStart : ContentPage
{
	public AlgoritmoStart()
	{
		InitializeComponent();
	}

    private async void OnYesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AlgoritmoStart());        
    }

    private async void OnNoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AlgoritmoStart());       
    }
    private async void OnEscClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AlgoritmoStart());
    }
}
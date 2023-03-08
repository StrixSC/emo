using Emo.Services;

namespace Emo;

public partial class MainPage : ContentPage
{
	int count = 0;
	RestService restService {  get; set; }

	public MainPage()
	{
		InitializeComponent();
		restService = new RestService();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		
	}
}


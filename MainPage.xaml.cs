using System.Diagnostics;
using Emo.Models;
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

	private async void OnCounterClicked(object sender, EventArgs e) 
	{
		List<Emote> emotes = await restService.FetchAllEmotesAsync();
		Debug.WriteLine(emotes.Count.ToString());
        for (int i = 0; i < emotes.Count; i++)
		{
            Emote emote = emotes[i];
			Debug.WriteLine(emote.code);
        }
	}
}


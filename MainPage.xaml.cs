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
		/*
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
		*/
		List<Emote> emotes = await restService.FetchAllEmotesAsync();
		Debug.WriteLine(emotes.Count.ToString());
        for (int i = 0; i < emotes.Count; i++)
		{
            Emote emote = emotes[i];
			Debug.WriteLine(emote.code);
        }
	}
}


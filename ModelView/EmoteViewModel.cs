using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emo.Models;
using Emo.Services;

namespace Emo.ModelView
{
    public class EmoteViewModel : BaseViewModel
    {
        public ObservableCollection<Emote> Emotes { get; } = new();
        RestService restService;
        public Command GetEmotesCommand { get; }

        public EmoteViewModel(RestService restService) 
        {
            Title = "Emotes";
            this.restService = restService;
            GetEmotesCommand = new Command(async () => await GetEmotesAsync());
        }

        public async Task GetEmotesAsync()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                var emotes = await restService.FetchAllEmotesAsync();
                if (Emotes.Count != 0)
                {
                    Emotes.Clear();
                }

                foreach (var emote in emotes)
                {
                    Emotes.Add(emote);
                }

            } catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get emote, error: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally { IsBusy = false; }
        }
    }
}

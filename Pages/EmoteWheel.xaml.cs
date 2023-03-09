using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Emo.Models;
using Emo.ModelView;
using Emo.Services;

namespace Emo;

public partial class EmoteWheelPage : ContentPage
{
    EmoteViewModel emoteViewModel;
    public EmoteWheelPage(EmoteViewModel emoteViewModel)
	{
        InitializeComponent();
        BindingContext = emoteViewModel;
        this.emoteViewModel = emoteViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        emoteViewModel.GetEmotesCommand.Execute(this);
    }
}


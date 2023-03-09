using Emo.Services;

namespace Emo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		WindowManager manager = new WindowManager();
        manager.ListenForKeyboardEvents();

        MainPage = new AppShell();
	}
}

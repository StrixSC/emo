using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emo.Services
{
    internal class WindowManager
    {
        KeyboardHandler Handler;
        IDisposable ShortcutSubscription;
        public WindowManager()
        {
            Handler = new KeyboardHandler();
        }

        public void ListenForKeyboardEvents() 
        {
            ShortcutSubscription = Handler.ShortcutPressedNotifier.Subscribe((ShortcutPressed) =>
            {
                Debug.WriteLine(ShortcutPressed.ToString());
                if (ShortcutPressed)
                {
                    OpenEmoteWheel();
                }
            });
        }

        ~WindowManager()
        {
            ShortcutSubscription.Dispose();
        }

        public async void OpenEmoteWheel()
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Window secondWindow = new Window(new EmoteWheelPage());
                Application.Current.OpenWindow(secondWindow);
            });
        }
    }
}

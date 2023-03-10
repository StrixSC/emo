using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emo.Services
{
    internal class WindowManager
    {
        KeyboardHandler Handler;
        RestService Rest;
        IDisposable ShortcutSubscription;
        public WindowManager()
        {
            Handler = new KeyboardHandler();
        }

        public void ListenForKeyboardEvents() 
        {
            ShortcutSubscription = Handler.ShortcutPressedNotifier
                .Where<bool>((Value) => Value == true)
                .Subscribe((ShortcutPressed) => Debug.WriteLine("ShortcutPressed"));
        }

        ~WindowManager()
        {
            ShortcutSubscription.Dispose();
        }
    }
}

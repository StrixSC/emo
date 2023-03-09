using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpHook.Native;
using SharpHook.Reactive;
using System.Reactive.Linq;
using SharpHook;

namespace Emo.Services
{
    internal class KeyboardHandler
    {
        private readonly IReactiveGlobalHook Hook;
        private HashSet<KeyCode> PressedKeys;
        private HashSet<KeyCode> RequiredKeys;

        public KeyboardHandler() {
            Hook = new SimpleReactiveGlobalHook();
            RequiredKeys = new HashSet<KeyCode>()
            {
                KeyCode.VcE,
                KeyCode.VcLeftAlt,
                KeyCode.VcLeftControl,
            };

            PressedKeys = new HashSet<KeyCode>();
            Hook.KeyPressed.Subscribe(HandleKeyPressedEvent);
            Hook.KeyReleased.Subscribe(HandleKeyReleasedEvent);
            Hook.RunAsync().Subscribe();
        }

        private void HandleKeyPressedEvent(KeyboardHookEventArgs Event)
        {
            if (Event == null)
            {
                return;
            }

            PressedKeys.Add(Event.Data.KeyCode);
            if (RequiredKeys.IsSubsetOf(PressedKeys))
            {
                Debug.WriteLine("Control + Alt + E pressed.");
            }
        }

        private void HandleKeyReleasedEvent(KeyboardHookEventArgs Event)
        {
            PressedKeys.Remove(Event.Data.KeyCode);
        }
    }
}

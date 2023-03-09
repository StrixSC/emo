using SharpHook.Native;
using SharpHook.Reactive;
using SharpHook;
using System.Reactive.Subjects;
using System.Reactive.Linq;

namespace Emo.Services
{
    internal class KeyboardHandler
    {
        private readonly IReactiveGlobalHook Hook;
        private HashSet<KeyCode> PressedKeys;
        private HashSet<KeyCode> RequiredKeys;
        private Boolean ShortcutPressed;
        public BehaviorSubject<bool> ShortcutPressedNotifier;

        public KeyboardHandler() {
            Hook = new SimpleReactiveGlobalHook();
            ShortcutPressed = false;
            // TODO: Change the required keys to be user selectable (User should be able to select a shortcut key).
            RequiredKeys = new HashSet<KeyCode>()
            {
                KeyCode.VcE,
                KeyCode.VcLeftAlt,
                KeyCode.VcLeftControl,
            };

            PressedKeys = new HashSet<KeyCode>();
            ShortcutPressedNotifier = new BehaviorSubject<bool>(false);
            Hook.KeyPressed.Subscribe(HandleKeyPressedEvent);
            Hook.KeyReleased.Subscribe(HandleKeyReleasedEvent);
            Hook.RunAsync().Subscribe();
        }

        ~KeyboardHandler()
        {
            ShortcutPressedNotifier.Dispose();
            Hook.Dispose();
        }

        private void HandleKeyPressedEvent(KeyboardHookEventArgs Event)
        {
            if (Event == null)
            {
                return;
            }

            PressedKeys.Add(Event.Data.KeyCode);
            if (RequiredKeys.IsSubsetOf(PressedKeys) && !ShortcutPressed)
            {
                ShortcutPressed = true;
                ShortcutPressedNotifier.OnNext(ShortcutPressed);
            }
        }

        private void HandleKeyReleasedEvent(KeyboardHookEventArgs Event)
        {
            PressedKeys.Remove(Event.Data.KeyCode);
            ShortcutPressed = false;
            ShortcutPressedNotifier.OnNext(ShortcutPressed);
        }
    }
}

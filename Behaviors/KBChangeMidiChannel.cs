using NeeqDMIs.Keyboard;
using NetytarWebController.Modules;
using RawInputProcessor;
using System;
using System.Windows.Input;

namespace NetytarWebController.Behaviors
{
    public class KBChangeMidiChannel : IKeyboardBehavior
    {
        private KeyPressState KeyPressState { get; set; } = KeyPressState.Up;
        public int ReceiveEvent(RawInputEventArgs e)
        {
            if (e.KeyPressState == KeyPressState.Down && KeyPressState != e.KeyPressState)
            {
                
                switch (e.Key)
                {
                    case Rack.KEYMIDIUP:
                        Rack.NetytarDriverBox.MidiDevice++;
                        break;
                    case Rack.KEYMIDIDOWN:
                        Rack.NetytarDriverBox.MidiDevice--;
                        break;
                }
            }
            KeyPressState = e.KeyPressState;
            return 0;
        }
    }
}

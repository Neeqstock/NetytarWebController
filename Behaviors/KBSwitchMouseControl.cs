using NeeqDMIs.Keyboard;
using NetytarWebController.Modules;
using RawInputProcessor;

namespace NetytarWebController.Behaviors
{
    public class KBSwitchMouseControl : IKeyboardBehavior
    {
        private KeyPressState KeyPressState { get; set; } = KeyPressState.Up;
        public int ReceiveEvent(RawInputEventArgs e)
        {
            if (e.KeyPressState == KeyPressState.Down && KeyPressState != e.KeyPressState)
            {
                
                if (e.Key == Rack.KEYLOCKMOUSE)
                {
                    Rack.NetytarDriverBox.ControlMouse = true;
                }
                else if (e.Key == Rack.KEYUNLOCKMOUSE)
                {
                    Rack.NetytarDriverBox.ControlMouse = false;
                }
            }
            KeyPressState = e.KeyPressState;
            return 0;
        }
    }
}
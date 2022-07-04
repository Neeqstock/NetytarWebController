using NeeqDMIs.Keyboard;
using NetytarWebDriver.Modules;
using RawInputProcessor;

namespace NetytarWebDriver.Behaviors
{
    public class KBChangeComPort : IKeyboardBehavior
    {
        private KeyPressState KeyPressState { get; set; } = KeyPressState.Up;
        public int ReceiveEvent(RawInputEventArgs e)
        {
            if(e.KeyPressState == KeyPressState.Down && KeyPressState != e.KeyPressState)
            {
                
                if (e.Key == Rack.KEYPORTPLUS)
                {
                    Rack.NetytarDriverBox.Port++;
                }
                else if (e.Key == Rack.KEYPORTMINUS)
                {
                    Rack.NetytarDriverBox.Port--;
                }
            }
            KeyPressState = e.KeyPressState;
            return 0;
        }
    }
}

using NeeqDMIs.ATmega;
using NetytarWebDriver.Modules;

namespace NetytarWebDriver.Behaviors
{
    public class SBReceiveSensorString : ISensorBehavior
    {
        public void ReceiveSensorRead(string v)
        {
            try
            {
                Rack.NetytarDriverBox.ReceiveBreathValue(int.Parse(v));
            }
            catch
            {

            }
            
        }
    }
}
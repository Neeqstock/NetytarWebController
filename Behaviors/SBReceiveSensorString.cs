using NeeqDMIs.ATmega;
using NetytarWebController.Modules;

namespace NetytarWebController.Behaviors
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
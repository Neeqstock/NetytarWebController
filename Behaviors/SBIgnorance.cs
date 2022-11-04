using NeeqDMIs.ATmega;
using NetytarWebController.Modules;

namespace NetytarWebController.Behaviors
{
    public class SBIgnorance : ISensorBehavior
    {
        private string cose = "";

        public void ReceiveSensorRead(string val)
        {
            cose = val;
            Rack.NetytarDriverBox.TestString = cose.Replace("$", "\n");
        }

        /*
         * Gyro max values: 32767, -32768
         */

    }
}

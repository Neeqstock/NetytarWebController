using NeeqDMIs.ATmega;
using NetytarWebDriver.Modules;

namespace NetytarWebDriver.Behaviors
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

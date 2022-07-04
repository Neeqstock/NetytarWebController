using NeeqDMIs.ATmega;
using NetytarWebDriver.Modules;
using System.Globalization;

namespace NetytarWebDriver.Behaviors
{
    public class SBbreathSensor : ISensorBehavior
    {
        private int v = 1;
        private int offThresh;
        private int onThresh;
        private float sensitivity;

        public SBbreathSensor(int offThresh, int onThresh, float sensitivity)
        {
            this.offThresh = offThresh;
            this.onThresh = onThresh;
            this.sensitivity = sensitivity;
        }

        public void ReceiveSensorRead(string val)
        {
            float b = 0;

            try
            {
                b = float.Parse(val, CultureInfo.InvariantCulture.NumberFormat);
            }
            catch
            {
            }

            v = (int)(b / 3);

            Rack.NetytarDriverBox.BreathValue = v;

            if (v > onThresh && Rack.NetytarDriverBox.NoteOn == false)
            {
                Rack.NetytarDriverBox.NoteOn = true;
            }

            if (v < offThresh)
            {
                Rack.NetytarDriverBox.NoteOn = false;
            }
        }
    }
}
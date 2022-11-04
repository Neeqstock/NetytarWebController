using NeeqDMIs.Eyetracking.Tobii;
using NeeqDMIs.Keyboard;
using System.Windows.Interop;

namespace NetytarWebDriver.Modules
{
    public class NetytarDriverBox
    {
        public NetytarDriverBox(MainWindow window)
        {
            KeyboardModule = new KeyboardModule(new WindowInteropHelper(window).Handle);
            TobiiModule = new TobiiModule();
        }
        public KeyboardModule KeyboardModule { get; set; }
        public TobiiModule TobiiModule { get; set; }
    }
}

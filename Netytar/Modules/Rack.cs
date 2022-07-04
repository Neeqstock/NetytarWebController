using System.Windows.Input;
using WindowsInput.Native;

namespace NetytarWebDriver.Modules
{
    public class Rack
    {
        public static NetytarDriverBox NetytarDriverBox { get; set; }

        public const int BAUDRATE = 9600;
        public const long BREATHMAX = 700;
        public const int MIDIDEVICEDEFAULT = 0;
        public const int BREATHONTHRESHOLD = 20;

        public const Key KEYLOCKMOUSE = Key.L;
        public const Key KEYUNLOCKMOUSE = Key.U;
        public const Key KEYMIDIUP = Key.PageUp;
        public const Key KEYMIDIDOWN = Key.PageDown;
        public const Key KEYPORTPLUS = Key.Add;
        public const Key KEYPORTMINUS = Key.Subtract;
        public const string STRINGOFF = "Off";
        public const string STRINGON = "On";
        public const VirtualKeyCode KEYPLAY = VirtualKeyCode.VK_P;
    }
}

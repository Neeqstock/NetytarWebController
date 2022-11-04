using NeeqDMIs.ATmega;
using NeeqDMIs.Eyetracking.Tobii;
using NeeqDMIs.Keyboard;
using NeeqDMIs.MIDI;
using NeeqDMIs.Utils;
using NetytarWebController.Behaviors;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using WindowsInput;

namespace NetytarWebController.Modules
{
    public class NetytarDriverBox
    {
        private bool controlMouse = false;
        private int breathValue = 0;
        private int midiDevice = Rack.MIDIDEVICEDEFAULT;
        private MainWindow window;
        private ValueMapperDouble BreathMapper;
        private bool noteOn;
        private InputSimulator inputSimulator = new InputSimulator();

        private int port = 0;

        public NetytarDriverBox(MainWindow window)
        {
            BreathMapper = new ValueMapperDouble(Rack.BREATHMAX, 127);

            this.window = window;

            MidiModule = new MidiModuleNAudio(Rack.MIDIDEVICEDEFAULT, 1);
            window.lbl_MidiDevice.Content = Rack.MIDIDEVICEDEFAULT.ToString();

            KeyboardModule = new KeyboardModule(new WindowInteropHelper(window).Handle, RawInputProcessor.RawInputCaptureMode.ForegroundAndBackground);
            KeyboardModule.KeyboardBehaviors.Add(new KBSwitchMouseControl());
            KeyboardModule.KeyboardBehaviors.Add(new KBChangeMidiChannel());
            KeyboardModule.KeyboardBehaviors.Add(new KBChangeComPort());

            NeeqBSModule = new SensorModule(Rack.BAUDRATE);
            NeeqBSModule.Behaviors.Add(new SBReceiveSensorString());
            NeeqBSModule.Behaviors.Add(new SBIgnorance());
            ProcessConnect();

            TobiiModule = new TobiiModule();
        }

        public int Port
        {
            get { return port; }
            set
            {
                port = value;
                ProcessConnect();
            }
        }

        private void ProcessConnect()
        {
            NeeqBSModule.Connect(port);
            window.lbl_ComPort.Content = port.ToString();
            switch (NeeqBSModule.IsConnectionOk)
            {
                case true:
                    window.lbl_ComPort.Foreground = new SolidColorBrush(Colors.Green);
                    break;

                case false:
                    window.lbl_ComPort.Foreground = new SolidColorBrush(Colors.Red);
                    break;
            }
        }

        public KeyboardModule KeyboardModule { get; set; }

        public TobiiModule TobiiModule { get; set; }

        public SensorModule NeeqBSModule { get; set; }

        public MidiModuleNAudio MidiModule { get; set; }

        public bool ControlMouse
        {
            get { return controlMouse; }
            set
            {
                controlMouse = value;
                TobiiModule.MouseEmulator.CursorVisible = !value;
                TobiiModule.MouseEmulator.EyetrackerToMouse = value;
                switch (controlMouse)
                {
                    case true:
                        window.lbl_GazeLock.Content = Rack.STRINGON;
                        break;

                    case false:
                        window.lbl_GazeLock.Content = Rack.STRINGOFF;
                        break;
                }
            }
        }

        public int BreathValue
        {
            get { return breathValue; }
            set
            {
                breathValue = value;
                MidiModule.SetPressure(BreathValue);
            }
        }

        public bool NoteOn
        {
            get { return noteOn; }
            set
            {
                if(value != noteOn)
                {
                    noteOn = value;
                    if (noteOn == true)
                    {
                        inputSimulator.Keyboard.KeyDown(Rack.KEYPLAY);
                    }
                    else
                    {
                        inputSimulator.Keyboard.KeyUp(Rack.KEYPLAY);
                    }
                }
            }
        }

        public int MidiDevice
        {
            get { return midiDevice; }
            set
            {
                midiDevice = value;
                window.lbl_MidiDevice.Content = midiDevice.ToString();
            }
        }
        
        public string TestString { get; internal set; }

        public void ReceiveBreathValue(int v)
        {
            BreathValue = (int)BreathMapper.Map(v);
            if (BreathValue > Rack.BREATHONTHRESHOLD)
            {
                NoteOn = true;
                
            }
            else
            {
                NoteOn = false;
            }
        }
    }
}
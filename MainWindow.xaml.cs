using NetytarWebController.Modules;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;

namespace NetytarWebController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Create a file for output named TestFile.txt.
        //Stream myFile;

        /* Create a new text writer using the output stream, and add it to
         * the trace listeners. */
        //TextWriterTraceListener myTextListener;


        public MainWindow()
        {
            InitializeComponent();
            Trace.TraceInformation("Your Information");
            Trace.TraceError("Your Error");
            Trace.TraceWarning("Your Warning");
            Trace.Listeners.Add(new TextWriterTraceListener("MyTextFile.log"));
            //Trace.AutoFlush = true;
            //myFile = File.Create("TestFile.txt");
            //myTextListener = new TextWriterTraceListener(myFile);
            //Trace.Listeners.Add(myTextListener);
        }

        private Timer dispatcher;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Rack.NetytarDriverBox = new NetytarDriverBox(this);

            dispatcher = new Timer();
            dispatcher.Interval = 10;
            dispatcher.Tick += Dispatcher_Tick;
            dispatcher.Start();
        }

        private void Dispatcher_Tick(object sender, System.EventArgs e)
        {
            lbl_BreathValue.Content = Rack.NetytarDriverBox.BreathValue.ToString();
            switch (Rack.NetytarDriverBox.NoteOn)
            {
                case true:
                    lbl_NoteOnOff.Content = Rack.STRINGON;
                    break;

                case false:
                    lbl_NoteOnOff.Content = Rack.STRINGOFF;
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            throw new System.Exception("Provabella");
        }
    }
}

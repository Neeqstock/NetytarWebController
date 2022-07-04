using NetytarWebDriver.Modules;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;

namespace NetytarWebDriver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

        }
    }
}

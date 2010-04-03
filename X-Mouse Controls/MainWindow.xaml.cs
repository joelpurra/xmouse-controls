using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Documents;

using System.Diagnostics;
using SystemParametersInfo;

namespace X_Mouse_Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            windowTrackingValues = new WindowTrackingValues();

            this.DataContext = windowTrackingValues;
        }

        private void GetValues()
        {
            // Defaults to be overwritten when reading system settings
            bool windowTrackingIsEnabled = false;
            bool windowRaisingIsEnabled = false;
            uint activeWindowTrkTimeout = (uint)WindowTrackingValues.DefaultDelay;

            // Values are read by passing a constant value and a reference to a corresponding datatype
            try
            {
                Helper.SystemParametersInfoGet((uint)SPI.SPI_GETACTIVEWINDOWTRACKING, 0, ref windowTrackingIsEnabled, 0);
            }
            catch
            {
                MessageBox.Show("Failed to read active window tracking value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            try
            {
                Helper.SystemParametersInfoGet((uint)SPI.SPI_GETACTIVEWNDTRKZORDER, 0, ref windowRaisingIsEnabled, 0);
            }
            catch
            {
                MessageBox.Show("Failed to read active window raising value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            try
            {
                Helper.SystemParametersInfoGet((uint)SPI.SPI_GETACTIVEWNDTRKTIMEOUT, 0, ref activeWindowTrkTimeout, 0);
            }
            catch
            {
                MessageBox.Show("Failed to read active window tracking delay value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            windowTrackingValues.IsTrackingEnabled = windowTrackingIsEnabled;
            windowTrackingValues.IsRaisingEnabled = windowRaisingIsEnabled;
            windowTrackingValues.Delay = activeWindowTrkTimeout;
        }

        private void SetValues()
        {
            // Saving values
            try
            {
                Helper.SystemParametersInfoSet((uint)SPI.SPI_SETACTIVEWINDOWTRACKING, 0, windowTrackingValues.IsTrackingEnabled, 1);
            }
            catch
            {
                MessageBox.Show("Failed to set active window tracking value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            try
            {
                Helper.SystemParametersInfoSet((uint)SPI.SPI_SETACTIVEWNDTRKZORDER, 0, windowTrackingValues.IsRaisingEnabled, 1);
            }
            catch
            {
                MessageBox.Show("Failed to set active window raising value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            try
            {
                Helper.SystemParametersInfoSet((uint)SPI.SPI_SETACTIVEWNDTRKTIMEOUT, 0, (uint)windowTrackingValues.Delay, 1);
            }
            catch
            {
                MessageBox.Show("Failed to set active window tracking delay value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // Not looking very nice, but it's a workaround for standalone applications
            // http://laurenlavoie.com/avalon/159
            Uri uri = ((Hyperlink)sender).NavigateUri;
            Process.Start(new ProcessStartInfo(uri.ToString()));
            e.Handled = true;
        }

        #region Events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetValues();
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            SetValues();
        }

        private void delayTextbox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            uint delay = (uint)WindowTrackingValues.DefaultDelay;

            if (!uint.TryParse(delayTextbox.Text, out delay))
            {
                delayTextbox.Text = delay.ToString();
            }
        }
        #endregion

        private readonly WindowTrackingValues windowTrackingValues;
    }
}

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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Defaults to be overwritten when reading system settings
            bool activateWindowTracking = false;
            bool activeWindowRaising = false;
            uint activeWindowTrkTimeout = 500;

            // Values are read by passing a constant value and a reference to a corresponding datatype
            try
            {
                Helper.SystemParametersInfoGet((uint)SPI.SPI_GETACTIVEWINDOWTRACKING, 0, ref activateWindowTracking, 0);
            }
            catch
            {
                MessageBox.Show("Failed to read active window tracking value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            try
            {
                Helper.SystemParametersInfoGet((uint)SPI.SPI_GETACTIVEWNDTRKZORDER, 0, ref activeWindowRaising, 0);
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
                MessageBox.Show("Failed to read active window tracking timeout value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // Updating the interface controls
            activeWindowTrackingCheckbox.IsChecked = activateWindowTracking;
            activeWindowRaisingCheckbox.IsChecked = activeWindowRaising;
            activeWindowTrkTimeoutSlider.Value = (double)activeWindowTrkTimeout;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // Parsing the interface controls
            bool activateWindowTracking = (activeWindowTrackingCheckbox.IsChecked == true);
            bool activeWindowRaising = (activeWindowRaisingCheckbox.IsChecked == true);
            uint activeWindowTrkTimeout = (uint)activeWindowTrkTimeoutSlider.Value;

            // Saving values
            try
            {
                Helper.SystemParametersInfoSet((uint)SPI.SPI_SETACTIVEWINDOWTRACKING, 0, activateWindowTracking, 1);
            }
            catch
            {
                MessageBox.Show("Failed to set active window tracking value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            try
            {
                Helper.SystemParametersInfoSet((uint)SPI.SPI_SETACTIVEWNDTRKZORDER, 0, activeWindowRaising, 1);
            }
            catch
            {
                MessageBox.Show("Failed to set active window raising value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            try
            {
                Helper.SystemParametersInfoSet((uint)SPI.SPI_SETACTIVEWNDTRKTIMEOUT, 0, activeWindowTrkTimeout, 1);
            }
            catch
            {
                MessageBox.Show("Failed to set active window tracking timeout value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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
    }
}

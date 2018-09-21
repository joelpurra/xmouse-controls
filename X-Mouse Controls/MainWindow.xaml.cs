namespace X_Mouse_Controls
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Interop;
    using System.Windows.Navigation;
    using SystemParametersInfo;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly WindowTrackingValues windowTrackingValues = new WindowTrackingValues();
        private bool pauseRefresh = false;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = windowTrackingValues;
        }

        private void GetValues()
        {
            // Defaults to be overwritten when reading system settings.
            bool windowTrackingIsEnabled = false;
            bool windowRaisingIsEnabled = false;
            uint activeWindowTrkTimeout = (uint)WindowTrackingValues.DefaultDelay;

            try
            {
                windowTrackingIsEnabled = Helpers.GetActiveWindowTracking();
            }
            catch
            {
                MessageBox.Show("Failed to read active window tracking value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            try
            {
                windowRaisingIsEnabled = Helpers.GetActiveWindowRaising();
            }
            catch
            {
                MessageBox.Show("Failed to read active window raising value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            try
            {
                activeWindowTrkTimeout = Helpers.GetActiveWindowDelay();
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
            try
            {
                Helpers.SetActiveWindowTracking(windowTrackingValues.IsTrackingEnabled);
            }
            catch
            {
                MessageBox.Show("Failed to set active window tracking value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            try
            {
                Helpers.SetActiveWindowRaising(windowTrackingValues.IsRaisingEnabled);
            }
            catch
            {
                MessageBox.Show("Failed to set active window raising value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            try
            {
                Helpers.SetActiveWindowDelay((uint)windowTrackingValues.Delay);
            }
            catch
            {
                MessageBox.Show("Failed to set active window tracking delay value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ApplyValues()
        {
            pauseRefresh = true;
            SetValues();
            pauseRefresh = false;
        }

        private void RefreshValues()
        {
            if (pauseRefresh != true)
            {
                GetValues();
            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // Not looking very nice, but it's a workaround for standalone applications.
            // https://laurenlavoie.com/avalon/159
            Uri uri = ((Hyperlink)sender).NavigateUri;
            Process.Start(new ProcessStartInfo(uri.ToString()));
            e.Handled = true;
        }

        #region Events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshValues();
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyValues();
        }

        private void delayTextbox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            uint delay = (uint)WindowTrackingValues.DefaultDelay;

            if (!uint.TryParse(delayTextbox.Text, out delay))
            {
                //delayTextbox.Text = delay.ToString();
                windowTrackingValues.Delay = delay;
            }
        }
        #endregion

        #region Windows Messaging
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case (int)WM.SETTINGCHANGE:
                    RefreshValues();
                    break;
            }

            return IntPtr.Zero;
        }
        #endregion
    }
}

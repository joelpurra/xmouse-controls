namespace X_Mouse_Controls
{
    using System;
    using System.ComponentModel;

    internal class WindowTrackingValues : INotifyPropertyChanged
    {
        public WindowTrackingValues()
            : this(false, false, DefaultDelay)
        {
        }

        public WindowTrackingValues(bool isTrackingEnabled, bool isRaisingEnabled, double delay)
        {
            IsTrackingEnabled = isTrackingEnabled;
            IsRaisingEnabled = isRaisingEnabled;
            Delay = delay;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static readonly double MinimumDelay = 0u;
        public static readonly double DefaultDelay = 500u;
        public static readonly double MaximumDelay = 2500u;

        private double _delay;
        private bool _isRaisingEnabled;
        private bool _isTrackingEnabled;

        public bool IsTrackingEnabled
        {
            get => _isTrackingEnabled;
            set
            {
                if (_isTrackingEnabled != value)
                {
                    _isTrackingEnabled = value;
                    OnPropertyChanged("IsTrackingEnabled");
                }
            }
        }

        public bool IsRaisingEnabled
        {
            get => _isRaisingEnabled;
            set
            {
                if (_isRaisingEnabled != value)
                {
                    _isRaisingEnabled = value;
                    OnPropertyChanged("IsRaisingEnabled");
                }
            }
        }

        public double Delay
        {
            get => _delay;
            set
            {
                double newDelay = GetDelayInRange(value);

                if (_delay != newDelay)
                {
                    _delay = newDelay;
                    OnPropertyChanged("Delay");
                }
            }
        }

        public static double GetDelayInRange(double delay)
        {
            return Math.Max(MinimumDelay, Math.Min(delay, MaximumDelay));
        }
    }
}

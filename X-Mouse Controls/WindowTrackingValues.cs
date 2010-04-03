using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X_Mouse_Controls
{
    public class WindowTrackingValues
    {
        public WindowTrackingValues()
            : this(false, false, DefaultDelay)
        {
        }

        public WindowTrackingValues(bool isTrackingEnabled, bool isRaisingEnabled, double delay)
        {
            this.IsTrackingEnabled = isTrackingEnabled;
            this.IsRaisingEnabled = isRaisingEnabled;
            this.Delay = delay;
        }

        public bool IsTrackingEnabled { get; set; }
        public bool IsRaisingEnabled { get; set; }

        private double delay;
        public double Delay
        {
            get
            {
                return delay;
            }
            set
            {
                delay = GetDelayInRange(value);
            }
        }

        public static double GetDelayInRange(double delay)
        {
            return Math.Max(MinimumDelay, Math.Min(delay, MaximumDelay));
        }

        public static readonly double MinimumDelay = 0u;
        public static readonly double DefaultDelay = 500u;
        public static readonly double MaximumDelay = 2500u;
    }
}

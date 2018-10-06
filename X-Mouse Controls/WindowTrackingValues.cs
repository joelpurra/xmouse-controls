// <copyright file="WindowTrackingValues.cs" company="Joel Purra">
// X-Mouse Controls by Joel Purra
// Copyright © 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018.
// All rights reserved. Released under GNU General Public License version 3.0 (GPL-3.0).
//
// - https://joelpurra.com/projects/X-Mouse_Controls/
// - https://github.com/joelpurra/xmouse-controls
// - https://joelpurra.com/
// - https://www.gnu.org/licenses/
// </copyright>

#pragma warning disable SA1600 // Elements must be documented
namespace XMouseControls
{
    using System;
    using System.ComponentModel;

    internal class WindowTrackingValues : INotifyPropertyChanged
    {
        public const double MinimumDelay = 0u;
        public const double DefaultDelay = 500u;
        public const double MaximumDelay = 2500u;

        private double delay;
        private bool isRaisingEnabled;
        private bool isTrackingEnabled;

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

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsTrackingEnabled
        {
            get => this.isTrackingEnabled;
            set
            {
                if (this.isTrackingEnabled != value)
                {
                    this.isTrackingEnabled = value;
                    this.OnPropertyChanged(nameof(this.IsTrackingEnabled));
                }
            }
        }

        public bool IsRaisingEnabled
        {
            get => this.isRaisingEnabled;
            set
            {
                if (this.isRaisingEnabled != value)
                {
                    this.isRaisingEnabled = value;
                    this.OnPropertyChanged(nameof(this.IsRaisingEnabled));
                }
            }
        }

        public double Delay
        {
            get => this.delay;
            set
            {
                double newDelay = GetDelayInRange(value);

                if (this.delay != newDelay)
                {
                    this.delay = newDelay;
                    this.OnPropertyChanged(nameof(this.Delay));
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static double GetDelayInRange(double delay)
        {
            return Math.Max(MinimumDelay, Math.Min(delay, MaximumDelay));
        }
    }
}

// <copyright file="Helpers.cs" company="Joel Purra">
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
namespace SystemParametersInfo
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    internal static class Helpers
    {
        private const uint UiParamNoOp = 0;
        private const uint SpifRead = (uint)SPIF.None;
        private const uint SpifWrite = (uint)(SPIF.SPIF_UPDATEINIFILE | SPIF.SPIF_SENDCHANGE);

        public static bool GetActiveWindowTracking()
        {
            bool windowTrackingIsEnabled = false;

            bool result = NativeMethods.SystemParametersInfo((uint)SPI.SPI_GETACTIVEWINDOWTRACKING, UiParamNoOp, ref windowTrackingIsEnabled, SpifRead);

            if (!result)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return windowTrackingIsEnabled;
        }

        public static bool GetActiveWindowRaising()
        {
            bool windowRaisingIsEnabled = false;

            bool result = NativeMethods.SystemParametersInfo((uint)SPI.SPI_GETACTIVEWNDTRKZORDER, UiParamNoOp, ref windowRaisingIsEnabled, SpifRead);

            if (!result)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return windowRaisingIsEnabled;
        }

        public static uint GetActiveWindowDelay()
        {
            uint activeWindowTrkTimeout = 0;

            bool result = NativeMethods.SystemParametersInfo((uint)SPI.SPI_GETACTIVEWNDTRKTIMEOUT, UiParamNoOp, ref activeWindowTrkTimeout, SpifRead);

            if (!result)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return activeWindowTrkTimeout;
        }

        public static void SetActiveWindowTracking(bool enabled)
        {
            bool result = NativeMethods.SystemParametersInfo((uint)SPI.SPI_SETACTIVEWINDOWTRACKING, UiParamNoOp, enabled.AsUIntPtr(), SpifWrite);

            if (!result)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        public static void SetActiveWindowRaising(bool enabled)
        {
            bool result = NativeMethods.SystemParametersInfo((uint)SPI.SPI_SETACTIVEWNDTRKZORDER, UiParamNoOp, enabled.AsUIntPtr(), SpifWrite);

            if (!result)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        public static void SetActiveWindowDelay(uint delay)
        {
            UIntPtr vparam = (UIntPtr)delay;

            bool result = NativeMethods.SystemParametersInfo((uint)SPI.SPI_SETACTIVEWNDTRKTIMEOUT, UiParamNoOp, vparam, SpifWrite);

            if (!result)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        private static UIntPtr AsUIntPtr(this bool value)
        {
            return new UIntPtr(value ? 1u : 0u);
        }
    }
}

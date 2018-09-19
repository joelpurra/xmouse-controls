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

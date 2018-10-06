namespace SystemParametersInfo
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Wrapper for the SystemParametersInfo in user32.dll.
    /// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-systemparametersinfoa
    /// https://www.pinvoke.net/default.aspx/user32.SystemParametersInfo
    /// </summary>
    internal class NativeMethods
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, UIntPtr pvParam, uint fWinIni);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref uint pvParam, uint fWinIni);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref bool pvParam, uint fWinIni);
    }
}

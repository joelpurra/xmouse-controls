using System;

using System.Runtime.InteropServices;

namespace SystemParametersInfo
{
    /// <summary>
    /// Wrapper for the SystemParametersInfo in user32.dll 
    /// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-systemparametersinfoa
    /// https://www.pinvoke.net/default.aspx/user32.SystemParametersInfo 
    /// </summary>
    public class Helper
    {
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        public static extern bool SystemParametersInfoGet(uint action, uint param, ref uint vparam, uint init);

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        public static extern bool SystemParametersInfoSet(uint action, uint param, uint vparam, uint init);

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        public static extern bool SystemParametersInfoGet(uint action, uint param, ref bool vparam, uint init);

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        public static extern bool SystemParametersInfoSet(uint action, uint param, bool vparam, uint init);

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        public static extern bool SystemParametersInfoGet(uint action, uint param, ref string vparam, uint init);

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        public static extern bool SystemParametersInfoSet(uint action, uint param, string vparam, uint init);
    }
}

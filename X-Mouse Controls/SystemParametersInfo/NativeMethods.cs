// <copyright file="NativeMethods.cs" company="Joel Purra">
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

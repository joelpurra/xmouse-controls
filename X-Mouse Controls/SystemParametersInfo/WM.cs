// <copyright file="WM.cs" company="Joel Purra">
// X-Mouse Controls by Joel Purra
// Copyright © 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018.
// All rights reserved. Released under GNU General Public License version 3.0 (GPL-3.0).
//
// - https://joelpurra.com/projects/X-Mouse_Controls/
// - https://github.com/joelpurra/xmouse-controls
// - https://joelpurra.com/
// - https://www.gnu.org/licenses/
// </copyright>

namespace SystemParametersInfo
{
    using System.ComponentModel;

    /// <summary>
    /// WM_* Constants and their definitions or descriptions and what can cause them to be sent.
    /// https://docs.microsoft.com/en-gb/windows/desktop/winmsg/about-messages-and-message-queues
    /// https://docs.microsoft.com/en-gb/windows/desktop/winmsg/about-messages-and-message-queues#system_defined
    /// https://www.pinvoke.net/default.aspx/Constants/WM.html
    /// </summary>
    [Description("WM_ Constants and their definitions or descriptions and what can cause them to be sent.")]
    internal enum WM : uint
    {
        /// <summary>
        /// An application sends the WM_WININICHANGE message to all top-level windows after making a change to the WIN.INI file. The SystemParametersInfo function sends this message after an application uses the function to change a setting in WIN.INI.
        /// Note  The WM_WININICHANGE message is provided only for compatibility with earlier versions of the system. Applications should use the WM_SETTINGCHANGE message.
        /// </summary>
        WININICHANGE = 0x001A,

        /// <summary>
        /// An application sends the WM_WININICHANGE message to all top-level windows after making a change to the WIN.INI file. The SystemParametersInfo function sends this message after an application uses the function to change a setting in WIN.INI.
        /// Note  The WM_WININICHANGE message is provided only for compatibility with earlier versions of the system. Applications should use the WM_SETTINGCHANGE message.
        /// </summary>
        SETTINGCHANGE = WININICHANGE,
    }
}

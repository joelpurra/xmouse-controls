// <copyright file="SPIF.cs" company="Joel Purra">
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
    /// SPIF_ Used in SystemParametersInfo as fWinIni.
    /// https://www.pinvoke.net/default.aspx/Enums/SPIF.html
    /// </summary>
    [Description("SPIF_ Used in SystemParametersInfo as fWinIni.")]
    internal enum SPIF : uint
    {
        /// <summary>
        /// Take no action.
        /// </summary>
        None = 0x00,

        /// <summary>
        /// Writes the new system-wide parameter setting to the user profile.
        /// </summary>
        SPIF_UPDATEINIFILE = 0x01,

        /// <summary>
        /// Broadcasts the WM_SETTINGCHANGE message after updating the user profile.
        /// </summary>
        SPIF_SENDCHANGE = 0x02,

        /// <summary>
        /// Same as SPIF_SENDCHANGE.
        /// </summary>
        SPIF_SENDWININICHANGE = 0x02
    }
}

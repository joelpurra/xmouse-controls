namespace SystemParametersInfo
{
    using System.ComponentModel;

    #region SPIF
    /// <summary>
    /// SPIF_ Used in SystemParametersInfo as fWinIni.
    /// https://www.pinvoke.net/default.aspx/Enums/SPIF.html
    /// </summary>
    [Description("SPIF_ Used in SystemParametersInfo as fWinIni.")]
    internal enum SPIF : uint
    {
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
    #endregion // SPIF
}

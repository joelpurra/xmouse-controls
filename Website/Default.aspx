<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server" xml:lang="sv" lang="sv">
    <title>joelpurra.se/Projects/X-Mouse Controls by Joel Purra</title>
    <link rel="stylesheet" href="Design/01/CSS/Main.css" type="text/css" />
</head>
<body>
    <div id="wrapper">
        <img src="Design/01/Images/X-Mouse-Controls-01.gif" id="logo" alt="X-Mouse Controls logotype, an active window on top of a greyed out window." />
        <h1>
            X-Mouse Controls</h1>
        <p>
            A tool to enable or disable active window tracking, raising and also the delay in
            milliseconds. This is known as x-mouse behavior.
        </p>
        <h2>
            What is x-mouse behavior?</h2>
        <p>
            When multiple programs are running on a Windows operating system, the default mode
            of operations is that you click one window after another to give them focus for
            keyboard inputs. With the x-mouse settings that click is not necessary - the only
            thing needed is to move your cursor over the window for it to become active.
        </p>
        <p>
            This behavior has been possible, but disabled, in different versions of Windows
            for years. It is usually enabled through Windows accesiblity settings or a wide
            variety of tools, most notably Tweak UI found in <a href="http://www.microsoft.com/windowsxp/downloads/powertoys/xppowertoys.mspx">
                Microsoft PowerToys</a>. However, Tweak UI does not run on Windows&nbsp;Vista/Windows&nbsp;Server&nbsp;2008/Windows&nbsp;7/later,
            which is why I created this tool.</p>
        <h2>
            Screenshots</h2>
        <p>
            <img src="Screenshots/x-mouse_controls_main_window_2010-04-03_1155_01.png" alt="Screenshot of the main window of X-Mouse Controls" /><br />
            The main window
        </p>
        <h2>
            Features</h2>
        <div id="features">
            <div class="feature">
                <h3>
                    Active window tracking</h3>
                <p>
                    Enable to give focus to windows by moving your cursor over them. Obeys the delay
                    described below.
                </p>
                <p>
                    If disabled (default) a click is required to activate a window.
                </p>
            </div>
            <div class="feature">
                <h3>
                    Active window raising</h3>
                <p>
                    Enable to automatically make the active window the topmost window.
                </p>
                <p>
                    If automatic window raising is disabled (default) it allows the user to type text
                    or give commands in one window without changing the order of the other windows.
                </p>
            </div>
            <div class="feature">
                <h3>
                    Active tracking delay</h3>
                <p>
                    The delay, in milliseconds, until the window focus changes. This program allows
                    settings from 0 milliseconds (instant focus) to 2500 milliseconds (very long delay).
                </p>
            </div>
            <div class="feature">
                <h3>
                    Apply</h3>
                <p>
                    Saves the settings and applies them to your system. The settings should come in
                    effect right away.
                </p>
            </div>
        </div>
        <h2>
            Notes</h2>
        <ul>
            <li>Some applications, especially those with a <a href="http://en.wikipedia.org/wiki/Multiple_document_interface">
                Multiple Document Interface</a>, may raise their own window even though the feature
                is disabled. See work-around below.</li>
            <li>Some menus do not like the x-mouse behavior and close before you are able to reach
                or click any menu alternative. See work-around below.</li>
            <li>One way to avoid window raising and menu problems is to click and hold your left
                mouse button on an empty (unresponsive) area, drag the cursor to where you want
                to focus and let go.</li>
            <li>Requires at least <a href="http://en.wikipedia.org/wiki/.NET_Framework_3.0#.NET_Framework_3.5">
                .NET Framework 3.5</a> due to the fact that this was a small test to try out <a href="http://en.wikipedia.org/wiki/Windows_Presentation_Foundation">
                    Windows Presentation Foundation.</a></li>
            <li>The releases do not require installation apart from unpacking. Please use <a
                href="http://www.7-zip.org/">7-Zip</a> to unpack .7z files.</li>
            <li>Developed for Windows&nbsp;Vista/Windows&nbsp;Server&nbsp;2008/Windows&nbsp;7/later.
                If you use a version of Windows released prior to Windows Vista, it is recommended
                to use Tweak UI, found in <a href="http://www.microsoft.com/windowsxp/downloads/powertoys/xppowertoys.mspx">
                    Microsoft PowerToys</a>.</li>
            <li>Please link back to this page, <a href="http://joelpurra.se/Projects/X-Mouse_Controls/">
                http://joelpurra.se/Projects/X-Mouse_Controls/</a> if you like and use this program.</li>
        </ul>
        <h2>
            Source code</h2>
        <p>
            I've release the full sourcecode, including this webpage and original graphics.
            It is free to use and modify - if I'm notified of all public releases that stem
            from this work.</p>
        <h2>
            History and downloads</h2>
        <dl>
            <dt>2010-03-13 00:00 1.0.1.0 <a href="Files/2010-04-03_1155/x-mouse_controls_2010-04-03_1155_release.7z">
                Release</a> <a href="Files/2010-04-03_1155/x-mouse_controls_2010-04-03_1155_debug.7z">
                    Debug</a> <a href="Files/2010-04-03_1155/x-mouse_controls_2010-04-03_1155_source.7z">
                        Source</a></dt>
            <dd>
                Allows for manual input of the delay, new web site links, using more bindings.<br />
            </dd>
            <dt>2007-12-27 16:19 1.0.0.1 <a href="Files/2007-12-27_1644/x-mouse_controls_2007-12-27_1644_release.7z">
                Release</a> <a href="Files/2007-12-27_1644/x-mouse_controls_2007-12-27_1644_debug.7z">
                    Debug</a> <a href="Files/2007-12-27_1644/x-mouse_controls_2007-12-27_1644_source.7z">
                        Source</a></dt>
            <dd>
                Disables the active window raising checkbox and delay slider when the active window
                tracking checkbox is not checked.<br />
            </dd>
            <dt>2007-12-27 14:04 1.0.0.0 <a href="Files/2007-12-27_1404/x-mouse_controls_2007-12-27_1404_release.7z">
                Release</a> <a href="Files/2007-12-27_1404/x-mouse_controls_2007-12-27_1404_debug.7z">
                    Debug</a> <a href="Files/2007-12-27_1404/x-mouse_controls_2007-12-27_1404_source.7z">
                        Source</a></dt>
            <dd>
                First version, initial release.<br />
            </dd>
        </dl>
        <h2>
            About the author</h2>
        <p>
            <a href="http://joelpurra.se/">Joel Purra</a> is a coder and webmaster, working
            mainly on webshops and sometimes on his hobby projects. His prefered programming
            languages are JScript for classic ASP and C# for .NET-development. He is available
            for consulting work.
        </p>
        <h2>
            Other stuff</h2>
        <h3>
            Search engine fodder</h3>
        <p class="minorImportance">
            The code relies on API calls to user32.dll, not direct edititing of the registry
            (as it's considered a bad thing). The following words are only here to help searching
            for this tool: HKEY_CURRENT_USER\Control Panel\Mouse\ActiveWindowTracking, HKEY_CURRENT_USER\Control
            Panel\Desktop\ActiveWindowTracking, HKEY_CURRENT_USER\Control Panel\Desktop\ActiveWndTrkTimeout,
            HKEY_CURRENT_USER\Control Panel\Desktop\UserPreferencesMask, REG_DWORD, REG_BINARY,
            TweakUI, xmouse.</p>
        <h3>
            Excerpt from <a href="http://members.aol.com/axcel216/newtip98.htm">AXCEL216's MAX Speeed
                Windows 98/98 SE + DOS 7.10 ©Tricks, Secrets, BUGs + FIXes</a></h3>
        <p class="minorImportance">
            X-Mouse settings do not "stick" [Thank you Joel Purra (e-mail removed)!]: TweakUI's
            Mouse tab -> "Activation follows mouse (X-Mouse)" box checked, and: TweakUI's General
            tab -> "X-Mouse AutoRaise" and "Mouse hot tracking effects" boxes checked. This
            can be fixed in some cases (reminiscent from the old XMouse MS Power Toy 95) by
            adding/changing these Win.ini entries under the [XMouse] section:
        </p>
        <pre>
[XMouse]
BringWindowToTop=1
ConsoleWindowsOnly=1
Delay=1
</pre>
        <p class="minorImportance">
            Edit Win.ini (located in your Windows folder) with Notepad or Sysedit. Change any
            of these lines from 1 to 0 or back, and then restart Windows to see if it works.
            See "ACTIVE WINDOW TRACKING" in REGISTRY.TXT (included) to learn how to properly
            activate/fix X-Mouse settings used by TweakUI.
        </p>
        <div id="footer">
            <a href="http://joelpurra.se/Projects/X-Mouse_Controls/">X-Mouse Controls</a>. Originally
            coded a late night in December of 2007 by Joel Purra, <a href="http://joelpurra.se/">
                http://joelpurra.se/</a>.
        </div>
    </div>
</body>
</html>

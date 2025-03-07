﻿using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;


namespace CookPopularCSharpToolkit.Windows.Interop
{
    internal class InteropValues
    {
        internal static class ExternDll
        {
            public const string
                User32 = "user32.dll",
                Gdi32 = "gdi32.dll",
                GdiPlus = "gdiplus.dll",
                Kernel32 = "kernel32.dll",
                Shell32 = "shell32.dll",
                MsImg = "msimg32.dll",
                NTdll = "ntdll.dll",
                Dwmapi = "dwmapi.dll";
        }

        internal delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);

        internal delegate IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [return: MarshalAs(UnmanagedType.Bool)]
        internal delegate bool EnumMonitorsDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);

        internal delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        internal const int
            BITSPIXEL = 12,
            PLANES = 14,
            BI_RGB = 0,
            DIB_RGB_COLORS = 0,
            E_FAIL = unchecked((int)0x80004005),
            NIF_MESSAGE = 0x00000001,
            NIF_ICON = 0x00000002,
            NIF_TIP = 0x00000004,
            NIF_INFO = 0x00000010,
            NIM_ADD = 0x00000000,
            NIM_MODIFY = 0x00000001,
            NIM_DELETE = 0x00000002,
            NIIF_NONE = 0x00000000,
            NIIF_INFO = 0x00000001,
            NIIF_WARNING = 0x00000002,
            NIIF_ERROR = 0x00000003,
            WM_ACTIVATE = 0x0006,
            WM_QUIT = 0x0012,
            WM_GETMINMAXINFO = 0x0024,
            WM_WINDOWPOSCHANGING = 0x0046,
            WM_WINDOWPOSCHANGED = 0x0047,
            WM_SETICON = 0x0080,
            WM_NCCREATE = 0x0081,
            WM_NCDESTROY = 0x0082,
            WM_NCHITTEST = 0x0084,
            WM_NCACTIVATE = 0x0086,
            WM_NCRBUTTONDOWN = 0x00A4,
            WM_NCRBUTTONUP = 0x00A5,
            WM_NCRBUTTONDBLCLK = 0x00A6,
            WM_NCUAHDRAWCAPTION = 0x00AE,
            WM_NCUAHDRAWFRAME = 0x00AF,
            WM_KEYDOWN = 0x0100,
            WM_KEYUP = 0x0101,
            WM_SYSKEYDOWN = 0x0104,
            WM_SYSKEYUP = 0x0105,
            WM_SYSCOMMAND = 0x112,
            WM_MOUSEMOVE = 0x0200,
            WM_LBUTTONUP = 0x0202,
            WM_LBUTTONDBLCLK = 0x0203,
            WM_RBUTTONUP = 0x0205,
            WM_CLIPBOARDUPDATE = 0x031D,
            WM_USER = 0x0400,
            WS_VISIBLE = 0x10000000,
            MF_BYCOMMAND = 0x00000000,
            MF_BYPOSITION = 0x400,
            MF_GRAYED = 0x00000001,
            MF_SEPARATOR = 0x800,
            TB_GETBUTTON = WM_USER + 23,
            TB_BUTTONCOUNT = WM_USER + 24,
            TB_GETITEMRECT = WM_USER + 29,
            VERTRES = 10,
            DESKTOPVERTRES = 117,
            LOGPIXELSX = 88,
            LOGPIXELSY = 90,
            SC_CLOSE = 0xF060,
            SC_SIZE = 0xF000,
            SC_MOVE = 0xF010,
            SC_MINIMIZE = 0xF020,
            SC_MAXIMIZE = 0xF030,
            SC_RESTORE = 0xF120,
            SRCCOPY = 0x00CC0020,
            MONITOR_DEFAULTTONEAREST = 0x00000002;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal class NOTIFYICONDATA
        {
            public int cbSize = Marshal.SizeOf(typeof(NOTIFYICONDATA));
            public IntPtr hWnd;
            public int uID;
            public int uFlags;
            public int uCallbackMessage;
            public IntPtr hIcon;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szTip = string.Empty;
            public int dwState = 0x01;
            public int dwStateMask = 0x01;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szInfo = string.Empty;
            public int uTimeoutOrVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szInfoTitle = string.Empty;
            public int dwInfoFlags;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct TBBUTTON
        {
            public int iBitmap;
            public int idCommand;
            public IntPtr fsStateStylePadding;
            public IntPtr dwData;
            public IntPtr iString;
        }

        [Flags]
        internal enum AllocationType
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }

        [Flags]
        internal enum MemoryProtection
        {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct TRAYDATA
        {
            public IntPtr hwnd;
            public uint uID;
            public uint uCallbackMessage;
            public uint bReserved0;
            public uint bReserved1;
            public IntPtr hIcon;
        }

        [Flags]
        internal enum FreeType
        {
            Decommit = 0x4000,
            Release = 0x8000,
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        internal enum HookType
        {
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MOUSEHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [Flags]
        internal enum ProcessAccess
        {
            AllAccess = CreateThread | DuplicateHandle | QueryInformation | SetInformation | Terminate | VMOperation | VMRead | VMWrite | Synchronize,
            CreateThread = 0x2,
            DuplicateHandle = 0x40,
            QueryInformation = 0x400,
            SetInformation = 0x200,
            Terminate = 0x1,
            VMOperation = 0x8,
            VMRead = 0x10,
            VMWrite = 0x20,
            Synchronize = 0x100000
        }

        [Serializable, StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        [DebuggerDisplay("X:{Left}, Y:{Top}, Width:{Width}, Height:{Height}")]
        internal struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public RECT(Rect rect)
            {
                Left = (int)rect.Left;
                Top = (int)rect.Top;
                Right = (int)rect.Right;
                Bottom = (int)rect.Bottom;
            }

            public Point Position => new Point(Left, Top);
            public Size Size => new Size(Width, Height);

            public int Height
            {
                get => Bottom - Top;
                set => Bottom = Top + value;
            }

            public int Width
            {
                get => Right - Left;
                set => Right = Left + value;
            }
        }

        internal struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        internal enum GWL
        {
            STYLE = -16,
            EXSTYLE = -20
        }

        internal enum GWLP
        {
            WNDPROC = -4,
            HINSTANCE = -6,
            HWNDPARENT = -8,
            USERDATA = -21,
            ID = -12
        }

        internal struct BITMAPINFOHEADER
        {
            internal uint biSize;
            internal int biWidth;
            internal int biHeight;
            internal ushort biPlanes;
            internal ushort biBitCount;
            internal uint biCompression;
            internal uint biSizeImage;
            internal int biXPelsPerMeter;
            internal int biYPelsPerMeter;
            internal uint biClrUsed;
            internal uint biClrImportant;
        }

        [Flags]
        internal enum RedrawWindowFlags : uint
        {
            Invalidate = 1u,
            InternalPaint = 2u,
            Erase = 4u,
            Validate = 8u,
            NoInternalPaint = 16u,
            NoErase = 32u,
            NoChildren = 64u,
            AllChildren = 128u,
            UpdateNow = 256u,
            EraseNow = 512u,
            Frame = 1024u,
            NoFrame = 2048u
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public uint flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class WINDOWPLACEMENT
        {
            public int length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));
            public int flags;
            public int showCmd;
            public POINT ptMinPosition;
            public POINT ptMaxPosition;
            public RECT rcNormalPosition;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        internal struct SIZE
        {
            [ComAliasName("Microsoft.VisualStudio.OLE.Interop.LONG")]
            public int cx;
            [ComAliasName("Microsoft.VisualStudio.OLE.Interop.LONG")]
            public int cy;
        }

        internal struct MONITORINFO
        {
            public uint cbSize;
            public RECT rcMonitor;
            public RECT rcWork;
            public uint dwFlags;
        }

        internal enum WM
        {
            NULL = 0x0000,
            CREATE = 0x0001,
            DESTROY = 0x0002,
            MOVE = 0x0003,
            SIZE = 0x0005,
            ACTIVATE = 0x0006,
            SETFOCUS = 0x0007,
            KILLFOCUS = 0x0008,
            ENABLE = 0x000A,
            SETREDRAW = 0x000B,
            SETTEXT = 0x000C,
            GETTEXT = 0x000D,
            GETTEXTLENGTH = 0x000E,
            PAINT = 0x000F,
            CLOSE = 0x0010,
            QUERYENDSESSION = 0x0011,
            QUIT = 0x0012,
            QUERYOPEN = 0x0013,
            ERASEBKGND = 0x0014,
            SYSCOLORCHANGE = 0x0015,
            SHOWWINDOW = 0x0018,
            ACTIVATEAPP = 0x001C,
            SETCURSOR = 0x0020,
            MOUSEACTIVATE = 0x0021,
            CHILDACTIVATE = 0x0022,
            QUEUESYNC = 0x0023,
            GETMINMAXINFO = 0x0024,

            WINDOWPOSCHANGING = 0x0046,
            WINDOWPOSCHANGED = 0x0047,

            CONTEXTMENU = 0x007B,
            STYLECHANGING = 0x007C,
            STYLECHANGED = 0x007D,
            DISPLAYCHANGE = 0x007E,
            GETICON = 0x007F,
            SETICON = 0x0080,
            NCCREATE = 0x0081,
            NCDESTROY = 0x0082,
            NCCALCSIZE = 0x0083,
            NCHITTEST = 0x0084,
            NCPAINT = 0x0085,
            NCACTIVATE = 0x0086,
            GETDLGCODE = 0x0087,
            SYNCPAINT = 0x0088,
            NCMOUSEMOVE = 0x00A0,
            NCLBUTTONDOWN = 0x00A1,
            NCLBUTTONUP = 0x00A2,
            NCLBUTTONDBLCLK = 0x00A3,
            NCRBUTTONDOWN = 0x00A4,
            NCRBUTTONUP = 0x00A5,
            NCRBUTTONDBLCLK = 0x00A6,
            NCMBUTTONDOWN = 0x00A7,
            NCMBUTTONUP = 0x00A8,
            NCMBUTTONDBLCLK = 0x00A9,

            SYSKEYDOWN = 0x0104,
            SYSKEYUP = 0x0105,
            SYSCHAR = 0x0106,
            SYSDEADCHAR = 0x0107,
            COMMAND = 0x0111,
            SYSCOMMAND = 0x0112,

            MOUSEMOVE = 0x0200,
            LBUTTONDOWN = 0x0201,
            LBUTTONUP = 0x0202,
            LBUTTONDBLCLK = 0x0203,
            RBUTTONDOWN = 0x0204,
            RBUTTONUP = 0x0205,
            RBUTTONDBLCLK = 0x0206,
            MBUTTONDOWN = 0x0207,
            MBUTTONUP = 0x0208,
            MBUTTONDBLCLK = 0x0209,
            MOUSEWHEEL = 0x020A,
            XBUTTONDOWN = 0x020B,
            XBUTTONUP = 0x020C,
            XBUTTONDBLCLK = 0x020D,
            MOUSEHWHEEL = 0x020E,


            CAPTURECHANGED = 0x0215,

            ENTERSIZEMOVE = 0x0231,
            EXITSIZEMOVE = 0x0232,

            IME_SETCONTEXT = 0x0281,
            IME_NOTIFY = 0x0282,
            IME_CONTROL = 0x0283,
            IME_COMPOSITIONFULL = 0x0284,
            IME_SELECT = 0x0285,
            IME_CHAR = 0x0286,
            IME_REQUEST = 0x0288,
            IME_KEYDOWN = 0x0290,
            IME_KEYUP = 0x0291,

            NCMOUSELEAVE = 0x02A2,

            DESTROYCLIPBOARD = 0x0307,
            DRAWCLIPBOARD = 0x0308,
            PAINTCLIPBOARD = 0x0309,
            VSCROLLCLIPBOARD = 0x030A,
            SIZECLIPBOARD = 0x030B,

            ASKCBFORMATNAME = 0x030C,
            CHANGECBCHAIN = 0x030D,
            HSCROLLCLIPBOARD = 0x030E,
            QUERYNEWPALETTE = 0x030F,
            PALETTEISCHANGING = 0x0310,
            PALETTECHANGED = 0x0311,
            HOTKEY = 0x0312,
            PRINT = 0x0317,
            PRINTCLIENT = 0x0318,
            APPCOMMAND = 0x0319,
            THEMECHANGED = 0x031A,

            DWMCOMPOSITIONCHANGED = 0x031E,
            DWMNCRENDERINGCHANGED = 0x031F,
            DWMCOLORIZATIONCOLORCHANGED = 0x0320,
            DWMWINDOWMAXIMIZEDCHANGE = 0x0321,

            #region Windows 7
            DWMSENDICONICTHUMBNAIL = 0x0323,
            DWMSENDICONICLIVEPREVIEWBITMAP = 0x0326,
            #endregion

            USER = 0x0400,

            // This is the hard-coded message value used by WinForms for Shell_NotifyIcon.
            // It's relatively safe to reuse.
            TRAYMOUSEMESSAGE = 0x800, //WM_USER + 1024
            APP = 0x8000,
        }

        internal enum SM
        {
            CXSCREEN = 0,
            CYSCREEN = 1,
            CXVSCROLL = 2,
            CYHSCROLL = 3,
            CYCAPTION = 4,
            CXBORDER = 5,
            CYBORDER = 6,
            CXFIXEDFRAME = 7,
            CYFIXEDFRAME = 8,
            CYVTHUMB = 9,
            CXHTHUMB = 10,
            CXICON = 11,
            CYICON = 12,
            CXCURSOR = 13,
            CYCURSOR = 14,
            CYMENU = 15,
            CXFULLSCREEN = 16,
            CYFULLSCREEN = 17,
            CYKANJIWINDOW = 18,
            MOUSEPRESENT = 19,
            CYVSCROLL = 20,
            CXHSCROLL = 21,
            DEBUG = 22,
            SWAPBUTTON = 23,
            CXMIN = 28,
            CYMIN = 29,
            CXSIZE = 30,
            CYSIZE = 31,
            CXFRAME = 32,
            CXSIZEFRAME = CXFRAME,
            CYFRAME = 33,
            CYSIZEFRAME = CYFRAME,
            CXMINTRACK = 34,
            CYMINTRACK = 35,
            CXDOUBLECLK = 36,
            CYDOUBLECLK = 37,
            CXICONSPACING = 38,
            CYICONSPACING = 39,
            MENUDROPALIGNMENT = 40,
            PENWINDOWS = 41,
            DBCSENABLED = 42,
            CMOUSEBUTTONS = 43,
            SECURE = 44,
            CXEDGE = 45,
            CYEDGE = 46,
            CXMINSPACING = 47,
            CYMINSPACING = 48,
            CXSMICON = 49,
            CYSMICON = 50,
            CYSMCAPTION = 51,
            CXSMSIZE = 52,
            CYSMSIZE = 53,
            CXMENUSIZE = 54,
            CYMENUSIZE = 55,
            ARRANGE = 56,
            CXMINIMIZED = 57,
            CYMINIMIZED = 58,
            CXMAXTRACK = 59,
            CYMAXTRACK = 60,
            CXMAXIMIZED = 61,
            CYMAXIMIZED = 62,
            NETWORK = 63,
            CLEANBOOT = 67,
            CXDRAG = 68,
            CYDRAG = 69,
            SHOWSOUNDS = 70,
            CXMENUCHECK = 71,
            CYMENUCHECK = 72,
            SLOWMACHINE = 73,
            MIDEASTENABLED = 74,
            MOUSEWHEELPRESENT = 75,
            XVIRTUALSCREEN = 76,
            YVIRTUALSCREEN = 77,
            CXVIRTUALSCREEN = 78,
            CYVIRTUALSCREEN = 79,
            CMONITORS = 80,
            SAMEDISPLAYFORMAT = 81,
            IMMENABLED = 82,
            CXFOCUSBORDER = 83,
            CYFOCUSBORDER = 84,
            TABLETPC = 86,
            MEDIACENTER = 87,
            CXPADDEDBORDER = 92,
            REMOTESESSION = 0x1000,
            REMOTECONTROL = 0x2001
        }

        internal enum CacheSlot
        {
            DpiX,

            FocusBorderWidth,
            FocusBorderHeight,
            HighContrast,
            MouseVanish,

            DropShadow,
            FlatMenu,
            WorkAreaInternal,
            WorkArea,

            IconMetrics,

            KeyboardCues,
            KeyboardDelay,
            KeyboardPreference,
            KeyboardSpeed,
            SnapToDefaultButton,
            WheelScrollLines,
            MouseHoverTime,
            MouseHoverHeight,
            MouseHoverWidth,

            MenuDropAlignment,
            MenuFade,
            MenuShowDelay,

            ComboBoxAnimation,
            ClientAreaAnimation,
            CursorShadow,
            GradientCaptions,
            HotTracking,
            ListBoxSmoothScrolling,
            MenuAnimation,
            SelectionFade,
            StylusHotTracking,
            ToolTipAnimation,
            ToolTipFade,
            UIEffects,

            MinimizeAnimation,
            Border,
            CaretWidth,
            ForegroundFlashCount,
            DragFullWindows,
            NonClientMetrics,

            ThinHorizontalBorderHeight,
            ThinVerticalBorderWidth,
            CursorWidth,
            CursorHeight,
            ThickHorizontalBorderHeight,
            ThickVerticalBorderWidth,
            MinimumHorizontalDragDistance,
            MinimumVerticalDragDistance,
            FixedFrameHorizontalBorderHeight,
            FixedFrameVerticalBorderWidth,
            FocusHorizontalBorderHeight,
            FocusVerticalBorderWidth,
            FullPrimaryScreenWidth,
            FullPrimaryScreenHeight,
            HorizontalScrollBarButtonWidth,
            HorizontalScrollBarHeight,
            HorizontalScrollBarThumbWidth,
            IconWidth,
            IconHeight,
            IconGridWidth,
            IconGridHeight,
            MaximizedPrimaryScreenWidth,
            MaximizedPrimaryScreenHeight,
            MaximumWindowTrackWidth,
            MaximumWindowTrackHeight,
            MenuCheckmarkWidth,
            MenuCheckmarkHeight,
            MenuButtonWidth,
            MenuButtonHeight,
            MinimumWindowWidth,
            MinimumWindowHeight,
            MinimizedWindowWidth,
            MinimizedWindowHeight,
            MinimizedGridWidth,
            MinimizedGridHeight,
            MinimumWindowTrackWidth,
            MinimumWindowTrackHeight,
            PrimaryScreenWidth,
            PrimaryScreenHeight,
            WindowCaptionButtonWidth,
            WindowCaptionButtonHeight,
            ResizeFrameHorizontalBorderHeight,
            ResizeFrameVerticalBorderWidth,
            SmallIconWidth,
            SmallIconHeight,
            SmallWindowCaptionButtonWidth,
            SmallWindowCaptionButtonHeight,
            VirtualScreenWidth,
            VirtualScreenHeight,
            VerticalScrollBarWidth,
            VerticalScrollBarButtonHeight,
            WindowCaptionHeight,
            KanjiWindowHeight,
            MenuBarHeight,
            VerticalScrollBarThumbHeight,
            IsImmEnabled,
            IsMediaCenter,
            IsMenuDropRightAligned,
            IsMiddleEastEnabled,
            IsMousePresent,
            IsMouseWheelPresent,
            IsPenWindows,
            IsRemotelyControlled,
            IsRemoteSession,
            ShowSounds,
            IsSlowMachine,
            SwapButtons,
            IsTabletPC,
            VirtualScreenLeft,
            VirtualScreenTop,

            PowerLineStatus,

            IsGlassEnabled,
            UxThemeName,
            UxThemeColor,
            WindowCornerRadius,
            WindowGlassColor,
            WindowGlassBrush,
            WindowNonClientFrameThickness,
            WindowResizeBorderThickness,

            NumSlots
        }

        internal static class Win32Constant
        {
            internal const int MAX_PATH = 260;
            internal const int INFOTIPSIZE = 1024;
            internal const int TRUE = 1;
            internal const int FALSE = 0;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct WNDCLASS
        {
            public uint style;
            public Delegate lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszMenuName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszClassName;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal class WNDCLASS4ICON
        {
            public int style;
            public WndProc lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public string lpszMenuName;
            public string lpszClassName;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        internal struct BITMAPINFO
        {
            public int biSize;

            public int biWidth;

            public int biHeight;

            public short biPlanes;

            public short biBitCount;

            public int biCompression;

            public int biSizeImage;

            public int biXPelsPerMeter;

            public int biYPelsPerMeter;

            public int biClrUsed;

            public int biClrImportant;

            public BITMAPINFO(int width, int height, short bpp)
            {
                biSize = SizeOf();
                biWidth = width;
                biHeight = height;
                biPlanes = 1;
                biBitCount = bpp;
                biCompression = 0;
                biSizeImage = 0;
                biXPelsPerMeter = 0;
                biYPelsPerMeter = 0;
                biClrUsed = 0;
                biClrImportant = 0;
            }

            [SecuritySafeCritical]
            private static int SizeOf()
            {
                return Marshal.SizeOf(typeof(BITMAPINFO));
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class ICONINFO
        {
            public bool fIcon = false;
            public int xHotspot = 0;
            public int yHotspot = 0;
            public BitmapHandle? hbmMask = null;
            public BitmapHandle? hbmColor = null;
        }

        internal enum WINDOWCOMPOSITIONATTRIB
        {
            WCA_ACCENT_POLICY = 19
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct WINCOMPATTRDATA
        {
            public WINDOWCOMPOSITIONATTRIB Attribute;
            public IntPtr Data;
            public int DataSize;
        }

        internal enum ACCENTSTATE
        {
            ACCENT_DISABLED = 0,
            ACCENT_ENABLE_GRADIENT = 1,
            ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
            ACCENT_ENABLE_BLURBEHIND = 3,
            ACCENT_ENABLE_ACRYLICBLURBEHIND = 4,
            ACCENT_INVALID_STATE = 5
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct ACCENTPOLICY
        {
            public ACCENTSTATE AccentState;
            public int AccentFlags;
            public uint GradientColor;
            public int AnimationId;
        }

        [ComImport, Guid("0000000C-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IStream
        {
            int Read([In] IntPtr buf, [In] int len);

            int Write([In] IntPtr buf, [In] int len);

            [return: MarshalAs(UnmanagedType.I8)]
            long Seek([In, MarshalAs(UnmanagedType.I8)] long dlibMove, [In] int dwOrigin);

            void SetSize([In, MarshalAs(UnmanagedType.I8)] long libNewSize);

            [return: MarshalAs(UnmanagedType.I8)]
            long CopyTo([In, MarshalAs(UnmanagedType.Interface)] IStream pstm, [In, MarshalAs(UnmanagedType.I8)] long cb, [Out, MarshalAs(UnmanagedType.LPArray)] long[] pcbRead);

            void Commit([In] int grfCommitFlags);

            void Revert();

            void LockRegion([In, MarshalAs(UnmanagedType.I8)] long libOffset, [In, MarshalAs(UnmanagedType.I8)] long cb, [In] int dwLockType);

            void UnlockRegion([In, MarshalAs(UnmanagedType.I8)] long libOffset, [In, MarshalAs(UnmanagedType.I8)] long cb, [In] int dwLockType);

            void Stat([In] IntPtr pStatstg, [In] int grfStatFlag);

            [return: MarshalAs(UnmanagedType.Interface)]
            IStream Clone();
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        internal class StreamConsts
        {
            public const int LOCK_WRITE = 0x1;
            public const int LOCK_EXCLUSIVE = 0x2;
            public const int LOCK_ONLYONCE = 0x4;
            public const int STATFLAG_DEFAULT = 0x0;
            public const int STATFLAG_NONAME = 0x1;
            public const int STATFLAG_NOOPEN = 0x2;
            public const int STGC_DEFAULT = 0x0;
            public const int STGC_OVERWRITE = 0x1;
            public const int STGC_ONLYIFCURRENT = 0x2;
            public const int STGC_DANGEROUSLYCOMMITMERELYTODISKCACHE = 0x4;
            public const int STREAM_SEEK_SET = 0x0;
            public const int STREAM_SEEK_CUR = 0x1;
            public const int STREAM_SEEK_END = 0x2;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        internal class ImageCodecInfoPrivate
        {
            [MarshalAs(UnmanagedType.Struct)]
            public Guid Clsid;
            [MarshalAs(UnmanagedType.Struct)]
            public Guid FormatID;

            public IntPtr CodecName = IntPtr.Zero;
            public IntPtr DllName = IntPtr.Zero;
            public IntPtr FormatDescription = IntPtr.Zero;
            public IntPtr FilenameExtension = IntPtr.Zero;
            public IntPtr MimeType = IntPtr.Zero;

            public int Flags;
            public int Version;
            public int SigCount;
            public int SigSize;

            public IntPtr SigPattern = IntPtr.Zero;
            public IntPtr SigMask = IntPtr.Zero;
        }

        internal class ComStreamFromDataStream : IStream
        {
            protected Stream DataStream;

            // to support seeking ahead of the stream length...
            private long _virtualPosition = -1;

            internal ComStreamFromDataStream(Stream dataStream)
            {
                this.DataStream = dataStream ?? throw new ArgumentNullException(nameof(dataStream));
            }

            private void ActualizeVirtualPosition()
            {
                if (_virtualPosition == -1) return;

                if (_virtualPosition > DataStream.Length)
                    DataStream.SetLength(_virtualPosition);

                DataStream.Position = _virtualPosition;

                _virtualPosition = -1;
            }

            public virtual IStream Clone()
            {
                NotImplemented();
                return null;
            }

            public virtual void Commit(int grfCommitFlags)
            {
                DataStream.Flush();
                ActualizeVirtualPosition();
            }

            public virtual long CopyTo(IStream pstm, long cb, long[] pcbRead)
            {
                const int bufsize = 4096; // one page
                var buffer = Marshal.AllocHGlobal(bufsize);
                if (buffer == IntPtr.Zero) throw new OutOfMemoryException();
                long written = 0;

                try
                {
                    while (written < cb)
                    {
                        var toRead = bufsize;
                        if (written + toRead > cb) toRead = (int)(cb - written);
                        var read = Read(buffer, toRead);
                        if (read == 0) break;
                        if (pstm.Write(buffer, read) != read)
                        {
                            throw EFail("Wrote an incorrect number of bytes");
                        }
                        written += read;
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(buffer);
                }
                if (pcbRead != null && pcbRead.Length > 0)
                {
                    pcbRead[0] = written;
                }

                return written;
            }

            public virtual Stream GetDataStream() => DataStream;

            public virtual void LockRegion(long libOffset, long cb, int dwLockType)
            {
            }

            protected static ExternalException EFail(string msg) => throw new ExternalException(msg, E_FAIL);

            protected static void NotImplemented() => throw new NotImplementedException();

            public virtual int Read(IntPtr buf, int length)
            {
                var buffer = new byte[length];
                var count = Read(buffer, length);
                Marshal.Copy(buffer, 0, buf, length);
                return count;
            }

            public virtual int Read(byte[] buffer, int length)
            {
                ActualizeVirtualPosition();
                return DataStream.Read(buffer, 0, length);
            }

            public virtual void Revert() => NotImplemented();

            public virtual long Seek(long offset, int origin)
            {
                var pos = _virtualPosition;
                if (_virtualPosition == -1)
                {
                    pos = DataStream.Position;
                }
                var len = DataStream.Length;

                switch (origin)
                {
                    case StreamConsts.STREAM_SEEK_SET:
                        if (offset <= len)
                        {
                            DataStream.Position = offset;
                            _virtualPosition = -1;
                        }
                        else
                        {
                            _virtualPosition = offset;
                        }
                        break;
                    case StreamConsts.STREAM_SEEK_END:
                        if (offset <= 0)
                        {
                            DataStream.Position = len + offset;
                            _virtualPosition = -1;
                        }
                        else
                        {
                            _virtualPosition = len + offset;
                        }
                        break;
                    case StreamConsts.STREAM_SEEK_CUR:
                        if (offset + pos <= len)
                        {
                            DataStream.Position = pos + offset;
                            _virtualPosition = -1;
                        }
                        else
                        {
                            _virtualPosition = offset + pos;
                        }
                        break;
                }

                return _virtualPosition != -1 ? _virtualPosition : DataStream.Position;
            }

            public virtual void SetSize(long value) => DataStream.SetLength(value);

            public virtual void Stat(IntPtr pstatstg, int grfStatFlag) => NotImplemented();

            public virtual void UnlockRegion(long libOffset, long cb, int dwLockType)
            {
            }

            public virtual int Write(IntPtr buf, int length)
            {
                var buffer = new byte[length];
                Marshal.Copy(buf, buffer, 0, length);
                return Write(buffer, length);
            }

            public virtual int Write(byte[] buffer, int length)
            {
                ActualizeVirtualPosition();
                DataStream.Write(buffer, 0, length);
                return length;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct APPBARDATA
        {
            public int cbSize;
            public IntPtr hWnd;
            public uint uCallbackMessage;
            public uint uEdge;
            public RECT rc;
            public int lParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct RTL_OSVERSIONINFOEX
        {
            internal uint dwOSVersionInfoSize;
            internal uint dwMajorVersion;
            internal uint dwMinorVersion;
            internal uint dwBuildNumber;
            internal uint dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            internal string szCSDVersion;
        }

        [Flags]
        [SuppressMessage("Design", "CA1069:不应复制枚举值", Justification = "<挂起>")]
        public enum WindowPositionFlags
        {
            /// <summary>
            ///     If the calling thread and the thread that owns the window are attached to different input queues, the system posts
            ///     the request to the thread that owns the window. This prevents the calling thread from blocking its execution while
            ///     other threads process the request.
            /// </summary>
            SWP_ASYNCWINDOWPOS = 0x4000,

            /// <summary>
            ///     Prevents generation of the WM_SYNCPAINT message.
            /// </summary>
            SWP_DEFERERASE = 0x2000,

            /// <summary>
            ///     Draws a frame (defined in the window's class description) around the window.
            /// </summary>
            SWP_DRAWFRAME = 0x0020,

            /// <summary>
            ///     Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to the window, even if
            ///     the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE is sent only when the window's
            ///     size is being changed.
            /// </summary>
            SWP_FRAMECHANGED = 0x0020,

            /// <summary>
            ///     Hides the window.
            /// </summary>
            SWP_HIDEWINDOW = 0x0080,

            /// <summary>
            ///     Does not activate the window. If this flag is not set, the window is activated and moved to the top of either the
            ///     topmost or non-topmost group (depending on the setting of the hWndInsertAfter parameter).
            /// </summary>
            SWP_NOACTIVATE = 0x0010,

            /// <summary>
            ///     Discards the entire contents of the client area. If this flag is not specified, the valid contents of the client
            ///     area are saved and copied back into the client area after the window is sized or repositioned.
            /// </summary>
            SWP_NOCOPYBITS = 0x0100,

            /// <summary>
            ///     Retains the current position (ignores X and Y parameters).
            /// </summary>
            SWP_NOMOVE = 0x0002,

            /// <summary>
            ///     Does not change the owner window's position in the Z order.
            /// </summary>
            SWP_NOOWNERZORDER = 0x0200,

            /// <summary>
            ///     Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to the client area,
            ///     the nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a
            ///     result of the window being moved. When this flag is set, the application must explicitly invalidate or redraw any
            ///     parts of the window and parent window that need redrawing.
            /// </summary>
            SWP_NOREDRAW = 0x0008,

            /// <summary>
            ///     Same as the SWP_NOOWNERZORDER flag.
            /// </summary>
            SWP_NOREPOSITION = 0x0200,

            /// <summary>
            ///     Prevents the window from receiving the WM_WINDOWPOSCHANGING message.
            /// </summary>
            SWP_NOSENDCHANGING = 0x0400,

            /// <summary>
            ///     Retains the current size (ignores the cx and cy parameters).
            /// </summary>
            SWP_NOSIZE = 0x0001,

            /// <summary>
            ///     Retains the current Z order (ignores the hWndInsertAfter parameter).
            /// </summary>
            SWP_NOZORDER = 0x0004,

            /// <summary>
            ///     Displays the window.
            /// </summary>
            SWP_SHOWWINDOW = 0x0040,

            TOPMOST = SWP_NOACTIVATE | SWP_NOOWNERZORDER | SWP_NOSIZE | SWP_NOMOVE | SWP_NOREDRAW | SWP_NOSENDCHANGING,
        }

        // The enum flag for DwmSetWindowAttribute's second parameter, which tells the function what attribute to set.
        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }

        // The DWM_WINDOW_CORNER_PREFERENCE enum for DwmSetWindowAttribute's third parameter, which tells the function
        // what value of the enum to set.
        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0, //让系统决定是否对窗口采用圆角设置
            DWMWCP_DONOTROUND = 1, //绝不对窗口采用圆角设置
            DWMWCP_ROUND = 2, //适当时采用圆角设置
            DWMWCP_ROUNDSMALL = 3  //适当时可采用半径较小的圆角设置
        }

        internal enum FlashType : uint
        {
            /// <summary>
            /// 停止闪烁。
            /// </summary>
            FLASHW_STOP = 0,

            /// <summary>
            /// 只闪烁标题。
            /// </summary>
            FALSHW_CAPTION = 1,

            /// <summary>
            /// 只闪烁任务栏。
            /// </summary>
            FLASHW_TRAY = 2,

            /// <summary>
            /// 标题和任务栏同时闪烁。
            /// </summary>
            FLASHW_ALL = 3,

            /// <summary>
            /// 
            /// </summary>
            FLASHW_PARAM1 = 4,

            /// <summary>
            /// 
            /// </summary>
            FLASHW_PARAM2 = 12,

            /// <summary>
            /// 无条件闪烁任务栏直到发送停止标志或者窗口被激活，如果未激活，停止时高亮。
            /// </summary>
            FLASHW_TIMER = FLASHW_TRAY | FLASHW_PARAM1,

            /// <summary>
            /// 未激活时闪烁任务栏直到发送停止标志或者窗体被激活，停止后高亮。
            /// </summary>
            FLASHW_TIMERNOFG = FLASHW_TRAY | FLASHW_PARAM2,
        }

        /// <summary>
        /// 包含系统应在指定时间内闪烁窗口次数和闪烁状态的信息
        /// </summary>
        internal struct FLASHWINFO
        {
            /// <summary>
            /// 结构大小
            /// </summary>
            public uint cbSize;

            /// <summary>
            /// 要闪烁或停止的窗口句柄
            /// </summary>
            public IntPtr hwnd;

            /// <summary>
            /// 闪烁的类型
            /// </summary>
            public uint dwFlags;

            /// <summary>
            /// 闪烁窗口的次数
            /// </summary>
            public uint uCount;

            /// <summary>
            /// 窗口闪烁的频度，毫秒为单位；若该值为0，则为默认图标的闪烁频度
            /// </summary>
            public uint dwTimeout;
        }

        /// <summary>
        /// 扩展的窗口风格
        /// 这是 long 类型的，如果想要使用 int 类型请使用 <see cref="InteropValues.WindowExStyles"/> 类
        /// </summary>
        /// 代码：[Extended Window Styles (Windows)](https://msdn.microsoft.com/en-us/library/windows/desktop/ff700543(v=vs.85).aspx )
        /// code from [Extended Window Styles (Windows)](https://msdn.microsoft.com/en-us/library/windows/desktop/ff700543(v=vs.85).aspx )
        [Flags]
        public enum ExtendedWindowStyles : long
        {
            /// <summary>
            /// The window accepts drag-drop files
            /// </summary>
            WS_EX_ACCEPTFILES = 0x00000010L,

            /// <summary>
            /// Forces a top-level window onto the taskbar when the window is visible
            /// </summary>
            WS_EX_APPWINDOW = 0x00040000L,

            /// <summary>
            /// The window has a border with a sunken edge.
            /// </summary>
            WS_EX_CLIENTEDGE = 0x00000200L,

            /// <summary>
            /// Paints all descendants of a window in bottom-to-top painting order using double-buffering. For more information, see Remarks. This cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC.Windows 2000:  This style is not supported.
            /// </summary>
            WS_EX_COMPOSITED = 0x02000000L,

            /// <summary>
            /// The title bar of the window includes a question mark. When the user clicks the question mark, the cursor changes to a question mark with a pointer. If the user then clicks a child window, the child receives a WM_HELP message. The child window should pass the message to the parent window procedure, which should call the WinHelp function using the HELP_WM_HELP command. The Help application displays a pop-up window that typically contains help for the child window.WS_EX_CONTEXTHELP cannot be used with the WS_MAXIMIZEBOX or WS_MINIMIZEBOX styles.
            /// </summary>
            WS_EX_CONTEXTHELP = 0x00000400L,

            /// <summary>
            /// The window itself contains child windows that should take part in dialog box navigation. If this style is specified, the dialog manager recurses into children of this window when performing navigation operations such as handling the TAB key, an arrow key, or a keyboard mnemonic.
            /// </summary>
            WS_EX_CONTROLPARENT = 0x00010000L,

            /// <summary>
            /// The window has a double border; the window can, optionally, be created with a title bar by specifying the WS_CAPTION style in the dwStyle parameter.
            /// </summary>
            WS_EX_DLGMODALFRAME = 0x00000001L,

            /// <summary>
            /// The window is a layered window. This style cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC.Windows 8:  The WS_EX_LAYERED style is supported for top-level windows and child windows. Previous Windows versions support WS_EX_LAYERED only for top-level windows.
            /// </summary>
            WS_EX_LAYERED = 0x00080000,

            /// <summary>
            /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the horizontal origin of the window is on the right edge. Increasing horizontal values advance to the left.
            /// </summary>
            WS_EX_LAYOUTRTL = 0x00400000L,

            /// <summary>
            /// The window has generic left-aligned properties. This is the default.
            /// </summary>
            WS_EX_LEFT = 0x00000000L,

            /// <summary>
            /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the vertical scroll bar (if present) is to the left of the client area. For other languages, the style is ignored.
            /// </summary>
            WS_EX_LEFTSCROLLBAR = 0x00004000L,

            /// <summary>
            /// The window text is displayed using left-to-right reading-order properties. This is the default.
            /// </summary>
            WS_EX_LTRREADING = 0x00000000L,

            /// <summary>
            /// The window is a MDI child window.
            /// </summary>
            WS_EX_MDICHILD = 0x00000040L,

            /// <summary>
            /// A top-level window created with this style does not become the foreground window when the user clicks it. The system does not bring this window to the foreground when the user minimizes or closes the foreground window.To activate the window, use the SetActiveWindow or SetForegroundWindow function.The window does not appear on the taskbar by default. To force the window to appear on the taskbar, use the WS_EX_APPWINDOW style.
            /// </summary>
            WS_EX_NOACTIVATE = 0x08000000L,

            /// <summary>
            /// The window does not pass its window layout to its child windows.
            /// </summary>
            WS_EX_NOINHERITLAYOUT = 0x00100000L,

            /// <summary>
            /// The child window created with this style does not send the WM_PARENTNOTIFY message to its parent window when it is created or destroyed.
            /// </summary>
            WS_EX_NOPARENTNOTIFY = 0x00000004L,

            /// <summary>
            /// The window does not render to a redirection surface. This is for windows that do not have visible content or that use mechanisms other than surfaces to provide their visual.
            /// </summary>
            WS_EX_NOREDIRECTIONBITMAP = 0x00200000L,

            /// <summary>
            /// The window is an overlapped window.
            /// </summary>
            WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE),

            /// <summary>
            /// The window is palette window, which is a modeless dialog box that presents an array of commands.
            /// </summary>
            WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST),

            /// <summary>
            /// The window has generic "right-aligned" properties. This depends on the window class. This style has an effect only if the shell language is Hebrew, Arabic, or another language that supports reading-order alignment; otherwise, the style is ignored.Using the WS_EX_RIGHT style for static or edit controls has the same effect as using the SS_RIGHT or ES_RIGHT style, respectively. Using this style with button controls has the same effect as using BS_RIGHT and BS_RIGHTBUTTON styles.
            /// </summary>
            WS_EX_RIGHT = 0x00001000L,

            /// <summary>
            /// The vertical scroll bar (if present) is to the right of the client area. This is the default.
            /// </summary>
            WS_EX_RIGHTSCROLLBAR = 0x00000000L,

            /// <summary>
            /// If the shell language is Hebrew, Arabic, or another language that supports reading-order alignment, the window text is displayed using right-to-left reading-order properties. For other languages, the style is ignored.
            /// </summary>
            WS_EX_RTLREADING = 0x00002000L,

            /// <summary>
            /// The window has a three-dimensional border style intended to be used for items that do not accept user input.
            /// </summary>
            WS_EX_STATICEDGE = 0x00020000L,

            /// <summary>
            /// The window is intended to be used as a floating toolbar. A tool window has a title bar that is shorter than a normal title bar, and the window title is drawn using a smaller font. A tool window does not appear in the taskbar or in the dialog that appears when the user presses ALT+TAB. If a tool window has a system menu, its icon is not displayed on the title bar. However, you can display the system menu by right-clicking or by typing ALT+SPACE.
            /// </summary>
            WS_EX_TOOLWINDOW = 0x00000080L,

            /// <summary>
            /// The window should be placed above all non-topmost windows and should stay above them, even when the window is deactivated. To add or remove this style, use the SetWindowPos function.
            /// </summary>
            WS_EX_TOPMOST = 0x00000008L,

            /// <summary>
            /// The window should not be painted until siblings beneath the window (that were created by the same thread) have been painted. The window appears transparent because the bits of underlying sibling windows have already been painted.To achieve transparency without these restrictions, use the SetWindowRgn function.
            /// </summary>
            WS_EX_TRANSPARENT = 0x00000020L,

            /// <summary>
            /// The window has a border with a raised edge
            /// </summary>
            WS_EX_WINDOWEDGE = 0x00000100L
        }


#pragma warning disable CS0419 // cref 特性中有不明确的引用
        /// <summary>
        /// 用于在 <see cref="InteropMethods.GetWindowLong"/> 的 int index 传入
        /// </summary>
        /// 代码：[GetWindowLong function (Windows)](https://msdn.microsoft.com/en-us/library/windows/desktop/ms633584(v=vs.85).aspx )
        public enum GetWindowLongFields
#pragma warning restore CS0419 // cref 特性中有不明确的引用
        {
            /// <summary>
            /// 设定一个新的扩展风格
            /// Retrieves the extended window styles
            /// </summary>
            GWL_EXSTYLE = -20,

            /// <summary>
            /// 设置一个新的应用程序实例句柄
            /// Retrieves a handle to the application instance
            /// </summary>
            GWL_HINSTANCE = -6,

            /// <summary>
            /// 改变子窗口的父窗口
            /// Retrieves a handle to the parent window, if any
            /// </summary>
            GWL_HWNDPARENT = -8,

            /// <summary>
            ///  设置一个新的窗口标识符
            /// Retrieves the identifier of the window
            /// </summary>
            GWL_ID = -12,

            /// <summary>
            /// 设定一个新的窗口风格
            /// Retrieves the window styles
            /// </summary>
            GWL_STYLE = -16,

            /// <summary>
            /// 设置与窗口有关的32位值。每个窗口均有一个由创建该窗口的应用程序使用的32位值
            /// Retrieves the user data associated with the window. This data is intended for use by the application that created the window. Its value is initially zero
            /// </summary>
            GWL_USERDATA = -21,

            /// <summary>
            /// 为窗口设定一个新的处理函数
            /// Retrieves the address of the window procedure, or a handle representing the address of the window procedure. You must use the CallWindowProc function to call the window procedure
            /// </summary>
            GWL_WNDPROC = -4,
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ACC.PTAutomated.Helpers
{
    /// <summary>
    /// Some online reference:
    /// https://dzone.com/articles/sending-keys-other-apps
    /// </summary>
    public class Core
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);



        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;


        [Flags]
        public enum MouseEventFlags
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }

        public struct INPUT
        {
            public int type;
            //public InputBatch u;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        public void DoRightClick(uint x, uint y)
        {

            //Call the imported function with the cursor's current position
            mouse_event((uint)MouseEventFlags.RightDown, x, y, (uint)0, (uint)0);
            mouse_event((uint)MouseEventFlags.RightUp, x, y, (uint)0, (uint)0);
        }

        public void DoLeftClick(uint x, uint y)
        {

            //Call the imported function with the cursor's current position
            mouse_event((uint)MouseEventFlags.LeftDown, x, y, (uint)0, (uint)0);
            mouse_event((uint)MouseEventFlags.LeftUp, x, y, (uint)0, (uint)0);
        }

        public void MoveMouse(uint x, uint y)
        {
            mouse_event((uint)MouseEventFlags.Move, x, y, 0, 0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace XG.Com.UI
{
    public class GlobalKeyboardHook : IDisposable
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        private readonly LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;
        private Keys[] _targetKeys;
        private int _currentKeyIndex;
        private bool[] _keyStates;

        public event EventHandler KeysPressed;

        public GlobalKeyboardHook(Keys[] targetKeys)
        {
            _proc = HookCallback;
            _targetKeys = targetKeys;
            _currentKeyIndex = 0;
            _keyStates = new bool[targetKeys.Length];
        }

        public void HookKeyboard()
        {
            _hookID = SetHook(_proc);
        }

        public void UnhookKeyboard()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if ((Keys)vkCode == _targetKeys[_currentKeyIndex])
                {
                    _keyStates[_currentKeyIndex] = true;
                    _currentKeyIndex++;
                    if (_currentKeyIndex == _targetKeys.Length)
                    {
                        bool allKeysPressed = true;
                        foreach (bool state in _keyStates)
                        {
                            if (!state)
                            {
                                allKeysPressed = false;
                                break;
                            }
                        }
                        if (allKeysPressed)
                        {
                            KeysPressed?.Invoke(this, EventArgs.Empty);
                        }
                        Array.Clear(_keyStates, 0, _keyStates.Length);
                        _currentKeyIndex = 0;
                    }
                }
                else
                {
                    Array.Clear(_keyStates, 0, _keyStates.Length);
                    _currentKeyIndex = 0;
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        public void Dispose()
        {
            UnhookKeyboard();
        }

        delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }

}
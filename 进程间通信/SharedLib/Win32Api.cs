using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace SharedLib
{
    /// Win32Api静态类
    /// <summary>
    /// Win32Api静态类
    /// </summary>
    public static class Win32Api
    {
        public const int WM_COPYDATA = 0x004A;//复制消息


        /// 注册热键
        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <param name="fsModifiers"></param>
        /// <param name="vk"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool RegisterHotKey(
            IntPtr hWnd,
            int id,
            uint fsModifiers,
            Keys vk
            );

        /// 取消注册热键
        /// <summary>
        /// 取消注册热键
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,
            int id
            );

        /// 获取指定Handle的控件的位置（相对于屏幕左上角）及大小
        /// <summary>
        /// 获取指定Handle的控件的位置（相对于屏幕左上角）及大小
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="rect"></param>
        [DllImport("user32.dll")]
        public static extern void GetWindowRect(
            IntPtr hWnd,
            out Rectangle rect
            );

        /// 向指定句柄的窗体发送消息
        /// <summary>
        /// 向指定句柄的窗体发送消息
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(
            IntPtr hWnd,
            uint Msg,
            uint wParam,
            ref MyModel lParam);

        /// 根据指定的窗口类名或名称查找窗体句柄
        /// <summary>
        /// 根据指定的窗口类名或名称查找窗体句柄
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    }
}

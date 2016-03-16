using PcKeyboardHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCSafeLoginApp
{
    public partial class FrmMain : Form
    {
        KeyboardHook hook = null;

        [DllImport("user32.dll")]

        public static extern int FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.dll")]

        public static extern Int32 SendMessage(

        int hWnd, // handle to destination window
        int Msg, // message
        int wParam, // first message parameter
        int lParam); // second message parameter

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.TopMost = true;

#if RELEASE
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
#endif

            this.Top = 0;
            this.Left = 0;

            #region 隐藏模式 运行  任务管理器

            Process p = new Process();

            p.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System);

            p.StartInfo.FileName = "taskmgr.exe";

            p.StartInfo.CreateNoWindow = true;

            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.Start();

            #endregion

            hook = new KeyboardHook();
            hook.KeyMaskStart();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hook != null)
            {
                hook.KeyMaskStop();
            }

            const int WM_CLOSE = 0x0010;
            int taskManager = FindWindow("#32770", "Windows Task Manager");
            SendMessage(taskManager, WM_CLOSE, 0, 0);

        }
    }
}

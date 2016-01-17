using SharedLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinProDemoA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("请输入要发送的内容");
                return;
            }

            IntPtr sendFormHandle = Win32Api.FindWindow(null, "WinProDemoB");
            if (sendFormHandle == IntPtr.Zero)
            {
                MessageBox.Show("没有找到WinProDemoB窗体！");
                return;
            }

            MyModel model = new MyModel();
            model.DataHandle = this.Handle;
            model.CbData = Encoding.Default.GetBytes(textBox1.Text).Length + 1;
            model.LpData = textBox1.Text;
            Win32Api.SendMessage(sendFormHandle, Win32Api.WM_COPYDATA, 0, ref model);

        }
    }
}

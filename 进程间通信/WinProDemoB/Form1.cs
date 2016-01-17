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

namespace WinProDemoB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Win32Api.WM_COPYDATA:
                    Type tp = typeof(MyModel);
                    MyModel model = (MyModel)m.GetLParam(tp);
                    textBox1.Text = model.LpData;
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}

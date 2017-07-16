using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            timer1.Enabled = true;

            this.RefreshDateTime();

            // ウィンドウの位置・サイズを復元
            Bounds = Properties.Settings.Default.Bounds;
            WindowState = Properties.Settings.Default.WindowState;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ウィンドウの位置・サイズを保存
            if (WindowState == FormWindowState.Normal)
                Properties.Settings.Default.Bounds = Bounds;
            else
                Properties.Settings.Default.Bounds = RestoreBounds;

            Properties.Settings.Default.WindowState = WindowState;

            Properties.Settings.Default.Save();
        }

        #region タイマーで実行する関数（時計の更新）
        private void RefreshDateTime()
        {
            DateTime dt = DateTime.Now;

            CultureInfo ci = new CultureInfo("en-US");

            string date = dt.ToString("yyyy/MM/dd (ddd)", ci);
            string time = dt.ToString("HH : mm : ss");

            DateLabel.Text = date;
            TimeLabel.Text = time;
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.RefreshDateTime();
        }

    }
}

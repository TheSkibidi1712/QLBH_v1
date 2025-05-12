using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_PolyCafe
{
    public partial class frmWelcome : Form
    {
        public frmWelcome()
        {
            InitializeComponent();
            //Cấu hình kiểu cho thanh progress bar
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            //Thực hiện thao tác load chờ 3 giây
            Task.Delay(3000).ContinueWith(t =>
            {
                Invoke(new Action(() =>
                {
                    frmLogin login = new frmLogin();
                    login.ShowDialog();
                    this.Hide();
                }));
            });
        }

        private void frmWelcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Ngăn chặn người dùng tắt ứng dụng
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }
    }
}

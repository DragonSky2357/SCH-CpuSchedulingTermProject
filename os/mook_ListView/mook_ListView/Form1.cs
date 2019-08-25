using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace mook_ListView
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDc);

        [DllImport("User32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        string strPID, strArriveTime, strServiceTime,
            strPriority, strQuantumTime,strEmpty;

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.lvView.Items.Clear();
        }

        private void btnResion_Click(object sender, EventArgs e)
        {
            FileStream InputFileDataTxt = new FileStream("data.txt", FileMode.Append, FileAccess.Write);
            this.pbStatus.Value = 0;

            using (var tw = new StreamWriter(InputFileDataTxt))
            {
                tw.WriteLine(strQuantumTime);

                foreach (ListViewItem item in lvView.Items)
                {
                    
                    tw.WriteLine(item.SubItems[1].Text+' '+ item.SubItems[2].Text+' '+
                        item.SubItems[3].Text + ' '+ item.SubItems[4].Text);
                }
            }

            Timer = new System.Windows.Forms.Timer();
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();
            
            if (lvView.Items.Count!=0)
            {
                MessageBox.Show("데이터가 등록 되었습니다.", "등록확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.ExitThread();
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("데이터가 비어있습니다. 다시 입력하세요", "데이터 재입력", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            this.pbStatus.Value = 0;
            Timer.Stop();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (pbStatus.Value > 100)
            {
                Timer.Stop();
                this.Timer.Enabled = false;
                return;
            }
            this.pbStatus.Value = 100;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.LightBlue;
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (TextCheck() == true)
            {
                strPID = this.txtPID.Text;
                strArriveTime = this.txtArriveTime.Text;
                strServiceTime = this.txtServiceTime.Text;
                strPriority = this.txtPriority.Text;
                strQuantumTime = this.txtQuantumTime.Text;

                this.txtPID.Text = "";
                this.txtArriveTime.Text = "";
                this.txtServiceTime.Text = "";
                this.txtPriority.Text = "";
                this.txtQuantumTime.Text = "";

            }
            else
            {
                MessageBox.Show("모든 데이터를 입력하세요", "데이터 재입력", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                

            ListViewItem lvi = new ListViewItem(new string[] {strEmpty,strPID,strArriveTime,strServiceTime,
                strPriority});
            this.lvView.Items.Add(lvi);
        }

        private bool TextCheck()
        {
            if (this.txtPID.Text != "" && this.txtArriveTime.Text!=""&& 
                this.txtServiceTime.Text != "" && this.txtPriority.Text != "" && this.txtQuantumTime.Text!="")
                return true;
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            const int WM_NCPAINT = 0x85;
            if (m.Msg == WM_NCPAINT)
            {
                IntPtr hdc = GetWindowDC(m.HWnd);
                if ((int)hdc != 0)
                {
                    Graphics g = Graphics.FromHdc(hdc);
                    g.FillRectangle(Brushes.Green, new Rectangle(0, 0, 4800, 30));
                    g.Flush();
                    ReleaseDC(m.HWnd, hdc);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chart
{
    public partial class Form1 : Form
    {
        int num = 3;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series["s1"].Points.AddXY(0, 0, 5+ num);
            chart1.Series["s3"].Points.AddXY(0, 8+num, 10 + num);
            chart1.Series["s2"].Points.AddXY(0, 3+num, 6 + num);
            chart1.Series["s4"].Points.AddXY(0, 2 + num, 7 + num);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form2 : Form
    {
        double[] hk;
        public Form2(double[] hk)
        {
            InitializeComponent();
            this.hk = hk;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            for (int i = 1; i < 6; i++)
            {
                chart1.Series[0].Points.AddXY(i, hk[i-1]);
            }
        }


    }
}

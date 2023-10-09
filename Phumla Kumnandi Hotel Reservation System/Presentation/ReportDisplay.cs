using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Presentation
{
    public partial class ReportDisplay : Form
    {
        public ReportDisplay(String report)
        {
            InitializeComponent();
            label1.Text = report;
        }

        private void ReportDisplay_Load(object sender, EventArgs e)
        {

        }
    }
}

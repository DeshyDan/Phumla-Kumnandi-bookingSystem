using Phumla_Kumnandi_Hotel_Reservation_System.Business;
using Phumla_Kumnandi_Hotel_Reservation_System.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Presentation
{
    public partial class BookingsForm : Form
    {
        public bool listFormClosed;
        public BookingsForm()
        {
            InitializeComponent();
        }

        private void homeNavLabel_Click(object sender, EventArgs e)
        {

        }

        private void Filter_Click(object sender, EventArgs e)
        {
 
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    
     
     
        private void BookingsForm_Load(object sender, EventArgs e)
        {
            
        }

        private void BookingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            listFormClosed = true;
        }
    }
    
}

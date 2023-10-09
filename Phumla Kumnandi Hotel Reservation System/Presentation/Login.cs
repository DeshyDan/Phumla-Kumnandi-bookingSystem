using Phumla_Kumnandi_Hotel_Reservation_System.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kumnandi_Hotel_Reservation_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void userNameInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = userNameInput.Text;
            string password = passwordInput.Text;

            if (username == "Jane" && password == "receptionist")
            {
                // Open the MDIParent form
                MDIParent mdiParentForm = new MDIParent();
                mdiParentForm.Show();
                this.Hide();
            }
            else if (username == "admin" && password == "root")
            {
                // Open the report form
                ReportForm reportForm = new ReportForm();
                reportForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
    }
}

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
using Phumla_Kumnandi_Hotel_Reservation_System.Business;
using Phumla_Kumnandi_Hotel_Reservation_System.Data;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Presentation
{
    public partial class GuestForm : Form
    {
        private BindingList<Guest> guest;
        public GuestForm()
        {
            InitializeComponent();
            guest=new BindingList<Guest>();
            GuestDB db = new GuestDB();
            dataGridView1.DataSource= guest;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
          


        }

        private void Guest_Load(object sender, EventArgs e)
        {
            PopulateGuest();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

     

        private void Filter_Click(object sender, EventArgs e)
        {
            try
            {
                string guestID = searchBox.Text;
                GuestController guestcontroller = new GuestController();
                Guest aGuest = guestcontroller.Find(guestID);

                if (string.IsNullOrEmpty(guestID))
                {
                    MessageBox.Show("Please enter a GuestID to searc", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (aGuest == null)
                {
                    MessageBox.Show("Guest does not exist in our system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(guestID, aGuest.Title, aGuest.IdNumber, aGuest.FirstName, aGuest.LastName, aGuest.Email, aGuest.Telephone, aGuest.Address);

                }


            }
            catch (FormatException)
            {
                MessageBox.Show("Please make sure all fields are correctly flled in before proceeding", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        private void PopulateGuest()
        {
            try
            {
                GuestController guestcontroller = new GuestController();
                Collection<Guest> allGuests = guestcontroller.AllGuest;
                dataGridView1.Rows.Clear();

                foreach(Guest guest in allGuests)
                {
                    dataGridView1.Rows.Add(
                        guest.Title
                        , guest.IdNumber
                        , guest.FirstName
                        , guest.LastName
                        , guest.Email
                        , guest.Telephone
                        , guest.Address
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error occured while listing all guests{ex.Message}","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

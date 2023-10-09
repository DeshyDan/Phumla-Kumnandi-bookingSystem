using Phumla_Kumnandi_Hotel_Reservation_System.Business;
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
    public partial class bookingFunctions : Form
    {
        private Booking booking;
        public bookingFunctions(Booking booking)
        {
            InitializeComponent();
            this.booking = booking;
        }

        private void bookingFunctions_Load(object sender, EventArgs e)
        {

        }

      

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteBooking deleteBooking = new DeleteBooking(booking);
            deleteBooking.ShowDialog();
        }

        private void bookingFunctions_Click(object sender, EventArgs e)
        {

        }

        private void payButton_Click(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditBooking editBooking = new EditBooking(booking);
            editBooking.ShowDialog();
        }
    }
}

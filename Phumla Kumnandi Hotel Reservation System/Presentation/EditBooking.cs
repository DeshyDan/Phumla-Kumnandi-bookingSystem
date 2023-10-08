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
    public partial class EditBooking : Form
    {
        private Booking booking; 
        private BookingController bookingController;
        public EditBooking(Booking booking , BookingController bookingController)
        {
            InitializeComponent();
             this.booking = booking;
            this.bookingController = bookingController;
            nameLabel.Text = booking.GuestId;
            bookingIdLabel.Text = booking.Id.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }
    }
}

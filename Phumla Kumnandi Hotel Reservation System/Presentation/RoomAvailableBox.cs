using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phumla_Kumnandi_Hotel_Reservation_System.Business;
namespace Phumla_Kumnandi_Hotel_Reservation_System.Presentation
{
    public partial class RoomAvailableBox : Form
    {
        private Booking booking;
        public RoomAvailableBox(Booking booking)
        {
            InitializeComponent();
            this.booking = booking;
            bookingPriceLabel.Text = booking.totalAmount.ToString();
        }

        

        private void RoomAvailableBox_Load(object sender, EventArgs e)
        {

        }

        private void createBookingButton_Click(object sender, EventArgs e)
        {
            CreateGuest createGuest = new CreateGuest(booking, new GuestController());
            createGuest.ShowDialog();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

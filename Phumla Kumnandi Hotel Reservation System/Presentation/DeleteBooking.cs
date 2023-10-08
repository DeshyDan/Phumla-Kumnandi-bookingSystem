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
    public partial class DeleteBooking : Form
    {
        private Booking booking;
        private BookingController bookingController;
        public DeleteBooking(Booking booking, BookingController bookingController)
        {
            InitializeComponent();
            this.booking = booking;
            this.bookingController = bookingController;
            nameLabel.Text = booking.GuestId;
            bookingDateLabel.Text = booking.CheckInDate.ToString("yyyy-MM-dd") + " to " + booking.CheckOutDate.ToString("yyyy-MM-dd");
            totalPriceLabel.Text = booking.TotalAmount.ToString();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bookingController.DataMaintenance(booking, Data.DB.DBOperation.Delete);
            this.Close();
        }
    }
}

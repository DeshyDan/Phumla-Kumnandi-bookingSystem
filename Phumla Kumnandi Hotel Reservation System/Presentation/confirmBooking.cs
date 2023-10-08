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
    public partial class ConfirmBooking : Form
    {

        private Booking booking;
        public ConfirmBooking(Booking booking, Guest guest)
        {
            InitializeComponent();
            this.booking = booking;
            firstNameInput.Text = guest.FirstName; 
            LastNameInput.Text = guest.LastName;
            checkInDateTimePicker.Value = booking.checkInDate; 
            checkOutDateTimePicker.Value = booking.checkOutDate;
            numberOfGuestPicker.Value = booking.NumberOfGuests;
            firstNameInput.Enabled = false; 
            LastNameInput.Enabled = false;
            checkInDateTimePicker.Enabled = false;
            checkOutDateTimePicker.Enabled = false;
            numberOfGuestPicker.Enabled = false;

        }
        private void PopulateObject()
        {
            booking.SpecialRequest = specialRequestInput.Text;
        }
      

       
        private void confirmbutton_Click(object sender, EventArgs e)
        {
            PopulateObject();
            this.Close();


        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

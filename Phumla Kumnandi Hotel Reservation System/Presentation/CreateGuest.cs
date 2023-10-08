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
    public partial class CreateGuest : Form
    {
        private Booking booking;
        private Guest guest;
        private GuestController guestController;
        public CreateGuest(Booking booking, GuestController guestController)
        {
            InitializeComponent();
            this.booking = booking;
            this.guestController = guestController;
        }

        private void PopulateObject()
        {
            guest = new Guest();
            guest.Title = titlePicker.Text;
            guest.FirstName = firstNameInput.Text;  
            guest.LastName = LastNameInput.Text;
            guest.Email = emailInput.Text;
            guest.Telephone = telephoneInput.Text;
            guest.IdNumber = idNumberInput.Text;
            guest.Address = addressInput.Text;

            guest = guestController.findGuest(guest);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            PopulateObject();
            guestController.FinalizeChanges(guest);
            confirmBooking confirmBooking = new confirmBooking();
            confirmBooking.ShowDialog();
            this.Close();
        }
    }
}

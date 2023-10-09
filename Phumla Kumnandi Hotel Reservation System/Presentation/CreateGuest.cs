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
using Phumla_Kumnandi_Hotel_Reservation_System.Data;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Presentation
{
    public partial class CreateGuest : Form
    {
        private Booking booking;
        private Guest guest = new Guest();
        private GuestController guestController;
        private BookingController bookingController;
        public CreateGuest(Booking booking)
        {
            InitializeComponent();
            this.booking = booking;
            this.guestController = MDIParent.GetGuestController();
            this.bookingController = MDIParent.GetBookingController();


        }

        private void PopulateObject()
        {

            guest.Title = titlePicker.Text;
            guest.FirstName = firstNameInput.Text;
            guest.LastName = LastNameInput.Text;
            guest.Email = emailInput.Text;
            guest.Telephone = telephoneInput.Text;
            guest.IdNumber = idNumberInput.Text;
            guest.Address = addressInput.Text;


            guest = guestController.findGuest(guest);

        }
        #region buttons

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            CheckFormFields();


        }
        #endregion
        #region input Validators
        private bool IsValidEmail(string email)
        {

            return email.Contains("@") && email.Contains(".");
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10 && long.TryParse(phoneNumber, out _);
        }

        private bool IsValidIdNumber(string idNumber)
        {
            return idNumber.Length == 13 && long.TryParse(idNumber, out _);
        }

        private string GetMissingFieldsMessage()
        {
            string missingFields = "";

            if (string.IsNullOrEmpty(titlePicker.Text))
            {
                missingFields += "Title is missing.\n";
            }

            if (string.IsNullOrEmpty(firstNameInput.Text))
            {
                missingFields += "First Name is missing.\n";
            }

            if (string.IsNullOrEmpty(LastNameInput.Text))
            {
                missingFields += "Last Name is missing.\n";
            }

            if (!IsValidEmail(emailInput.Text))
            {
                missingFields += "Invalid Email.\n";
            }

            if (!IsValidPhoneNumber(telephoneInput.Text))
            {
                missingFields += "Invalid Telephone Number (must be 10 digits).\n";
            }

            if (!IsValidIdNumber(idNumberInput.Text))
            {
                missingFields += "Invalid ID Number (must be 13 digits).\n";
            }

            if (string.IsNullOrEmpty(addressInput.Text))
            {
                missingFields += "Address is missing.\n";
            }

            return missingFields;
        }
        #endregion
        private void CheckFormFields()
        {
            string missingFieldsMessage = GetMissingFieldsMessage();

            if (string.IsNullOrEmpty(missingFieldsMessage))
            {

                PopulateObject();
                if (!(guestController.FindIndex(guest) == -1))
                {
                    guestController.DataMaintenacne(guest, DB.DBOperation.Add);
                    guestController.FinalizeChanges(guest);
                }


                this.Close();

                booking.GuestId = guest.IdNumber;
                ConfirmBooking confirmBooking = new ConfirmBooking(guest, booking);
                confirmBooking.ShowDialog();
            }
            else
            {
                MessageBox.Show("The following fields are missing or invalid:\n\n" + missingFieldsMessage);
            }
        }



    }
}

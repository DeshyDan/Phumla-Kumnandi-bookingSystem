using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;
using Phumla_Kumnandi_Hotel_Reservation_System.Business;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Presentation
{
    public partial class ConfirmBooking : Form
    {
        #region instance variables

        private Booking booking;
        private Guest guest;
        private BookingController bookingController;

        #endregion
        #region constructor
        public ConfirmBooking(Guest guest, Booking booking)
        {
            InitializeComponent();
            this.booking = booking;
            this.guest = guest;
            firstNameInput.Text = guest.FirstName;
            LastNameInput.Text = guest.LastName;
            checkInDateTimePicker.Value = booking.CheckInDate;
            checkOutDateTimePicker.Value = booking.CheckOutDate;
            numberOfGuestPicker.Value = booking.NumberOfGuests;
            firstNameInput.Enabled = false;
            LastNameInput.Enabled = false;
            checkInDateTimePicker.Enabled = false;
            checkOutDateTimePicker.Enabled = false;
            numberOfGuestPicker.Enabled = false;

            this.bookingController = MDIParent.GetBookingController();

        }
        #endregion
        private void PopulateObject()
        {
            if (specialRequestInput.Text == String.Empty)
            {
                booking.SpecialRequest = "none";
            }
            else
            {
                booking.SpecialRequest = specialRequestInput.Text;

            }
            booking.Id = GenerateUniqueId();
        }

        #region Utility function
        private const string AllowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private Random random = new Random();
        private string GenerateUniqueId()
        {
            // Get the current timestamp in milliseconds
            long timestamp = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;

            // Generate a random part of the ID
            StringBuilder randomPart = new StringBuilder();
            for (int i = 0; i < 10; i++) // You can adjust the length as needed
            {
                int index = random.Next(AllowedChars.Length);
                randomPart.Append(AllowedChars[index]);
            }

            // Combine the timestamp and random part to create a unique ID
            string uniqueId = $"{timestamp}{randomPart.ToString().PadRight(15)}";

            // Ensure the ID is exactly 25 characters long
            uniqueId = uniqueId.Substring(0, 25);

            return uniqueId;
        }
        #endregion
        private void confirmbutton_Click(object sender, EventArgs e)
        {
            PopulateObject();
            bookingController.DataMaintenance(booking, Data.DB.DBOperation.Add);
            bookingController.FinalizeChanges(booking);
           
            MessageBox.Show("Booking has been sucessfully made");
            this.Close();
            EmailGuest();


        }
        private void EmailGuest()
        {
            string senderEmail = "phumla056@gmail.com";
            string senderPassword = "rhni jiwt mrvi ewln";

            // Recipient's email address
            string recipientEmail = guest.Email;4

            // Create a new MailMessage
            // Create a new MailMessage
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(senderEmail);
            mail.To.Add(recipientEmail);
            mail.Subject = "Hello, World!";
            mail.Body = $"Dear {guest.Title}  {guest.LastName},\n\n" +
                    $"We are thrilled to confirm your booking with us for the upcoming stay on {booking.CheckInDate} to at Phumla Kumnandi Hotel. We look forward to welcoming you and ensuring that your stay is comfortable and enjoyable.\n\n" +
                    "Booking Details:\n" +
                    $"- Check-in Date: {booking.CheckInDate} \n" +
                    $"- Check-out Date: {booking.CheckOutDate} \n\n" +
                    $"To secure your reservation, we kindly request a deposit payment within the next 14 days. The deposit amount is {booking.TotalAmount} and can be paid through the following methods:\n\n" +
                    "Bank Transfer Details:\n" +
                    "Bank Name: Phumla Bank\n" +
                    "Account Holder: Phumla Kumnandi Hotels\n" +
                    "Account Number:123654 12365 98\n" +
                    "IBAN: 456\n" +
                    "SWIFT/BIC Code: 123\n\n" +
                    $"Please include your reservation reference number, {booking.Id}, in the payment reference to ensure that we correctly associate the deposit with your booking.\n\n" +

                    "Once we receive your deposit payment, we will send you a confirmation email along with any additional details you may need for your stay.\n\n" +
                    "Thank you for choosing Phumla Hotels. We are excited to host you, and we are confident that your stay with us will be a memorable one. If you have any special requests or preferences, please let us know in advance so that we can make arrangements to enhance your experience.\n\n" +
                    "We appreciate your trust in us and look forward to providing you with exceptional service.\n\n" +
                    "Warm regards,\n" +
                    "Receptionist\n" +
      
                    "Phumla Kumndandi Hotels\n" +
                    "phumla@co.za\n" +
                    "123456789";

            // Create a new SmtpClient
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;

            try
            {
                // Send the email
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

            }
            finally
            {
                // Clean up resources
                mail.Dispose();
                smtpClient.Dispose();
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void specialRequestInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

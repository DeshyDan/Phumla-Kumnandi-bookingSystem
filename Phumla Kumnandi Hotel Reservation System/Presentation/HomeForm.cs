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
    public partial class HomeForm : Form
    {
        
        #region data members
        private Guest guest;
        private Booking booking;
        private GuestController guestController;
        private BookingController bookingController;
        public bool listFormClosed;



        #endregion
        public HomeForm()
        {
            InitializeComponent();
            this.dataLanel.Text = DateTime.Now.Date.ToString("dddd, MMMM dd, yyyy");
            this.notAvailableLabel.Visible = false;
          
        }
        #region utility methods

        private void ClearAll()
        {
            checkInDateTimePicker.Text = string.Empty;
            checkOutDateTimePicker.Text = string.Empty;
            numberOfGuestPicker.Text = string.Empty;


        }
        private void PopulateObject()
        {
            booking = new Booking();
            booking.CheckInDate = checkInDateTimePicker.Value;
            booking.CheckOutDate = checkOutDateTimePicker.Value;
            booking.NumberOfGuests = (int)numberOfGuestPicker.Value + 1;
            booking.NumberOfRooms = calcNumberOfRooms(booking.NumberOfGuests);
            booking.TotalAmount = booking.NumberOfRooms * calcBookingPrice(booking);
            booking.BookingStatusId = 0;
            booking.Deposit = 0;
        }
        public int calcNumberOfRooms(int numberOfGuests)
        {

            int guestsPerRoom = 2;
            int numberOfRooms = (int)Math.Ceiling((double)numberOfGuests / guestsPerRoom);
            return numberOfRooms;
        }

        private int calcBookingPrice(Booking booking)
        {
            int totalDays = (booking.CheckOutDate - booking.CheckInDate).Days;
            DateTime currentDate = booking.CheckInDate;
            int totalPrice = 0;

            while (totalDays > 0)
            {
                int daysInCurrentRange = 0;
                int pricePerNight = 0;


                if (currentDate.Day >= 1 && currentDate.Day <= 7)
                {
                    daysInCurrentRange = Math.Min(7, totalDays);
                    pricePerNight = 550;
                }
                else if (currentDate.Day >= 8 && currentDate.Day <= 15)
                {
                    daysInCurrentRange = Math.Min(8, totalDays);
                    pricePerNight = 750;
                }
                else
                {
                    daysInCurrentRange = totalDays;
                    pricePerNight = 995;
                }

                totalPrice += daysInCurrentRange * pricePerNight;
                currentDate = currentDate.AddDays(daysInCurrentRange);
                totalDays -= daysInCurrentRange;
            }

            return totalPrice;
        }


        #endregion




        private void checkAvailabilityButton_Click(object sender, EventArgs e)
        {
            PopulateObject();
            RoomAvailableBox roomAvailableBox = new RoomAvailableBox(booking);
            roomAvailableBox.ShowDialog();

        }

        private void bookingNavLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookingsForm bookingsForm = new BookingsForm();
            bookingsForm.ShowDialog();
            
        }

        private void guestNavLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            GuestForm guestForm = new GuestForm();
            guestForm.ShowDialog();
        }

        private void roomNavLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoomsForm roomForms = new RoomsForm();
            roomForms.ShowDialog();

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

        }

        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            listFormClosed = true;
        }
    }
}

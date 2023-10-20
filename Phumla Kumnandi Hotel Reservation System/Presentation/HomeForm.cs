using Phumla_Kumnandi_Hotel_Reservation_System.Business;
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
        private Collection<Booking> bookings;



        #endregion
        public HomeForm()
        {
            InitializeComponent();
            this.dataLanel.Text = DateTime.Now.Date.ToString("dddd, MMMM dd, yyyy");
            this.notAvailableLabel.Visible = false;
            this.guestController = MDIParent.GetGuestController();
            this.bookingController = MDIParent.GetBookingController();
            bookings = bookingController.AllBookings;
            setOverview();
        }
        #region utility methods
        private void setOverview()
        {
            checkInLabel.Text = checkIn().ToString();
            checkOutLabel.Text = checkOut().ToString();
            availableRoomLabel.Text = numberOFAvalRooms().ToString();
            occupiedRoomLabel.Text = occupied().ToString();
        }
        private void ClearAll()
        {
            checkInDateTimePicker.Text = string.Empty;
            checkOutDateTimePicker.Text = string.Empty;
            numberOfGuestPicker.Text = string.Empty;


        }
        private void PopulateObject()
        {
            notAvailableLabel.Visible = false;
            booking = new Booking();
            booking.CheckInDate = checkInDateTimePicker.Value;
            booking.CheckOutDate = checkOutDateTimePicker.Value;
            booking.NumberOfGuests = (int)numberOfGuestPicker.Value ;
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

        #region overview function
        private int checkIn()
        {
            int numberOfBookings = 0;
            DateTime currentDate = DateTime.Now.Date;

            foreach (var booking in bookings)
            {
                if (currentDate >= booking.CheckInDate.Date && currentDate < booking.CheckOutDate.Date)
                {
                    numberOfBookings++;
                }
            }
            return numberOfBookings;

        }
        private int checkOut()
        {
            DateTime currentDate = DateTime.Now.Date;

            // Loop through the bookings and count the ones checking out on the current date
            int numberOfCheckouts = 0;
            foreach (var booking in bookings)
            {
                if (currentDate == booking.CheckOutDate.Date)
                {
                    numberOfCheckouts++;
                }
            }
            return numberOfCheckouts;
        }
        private int numberOFAvalRooms()
        {
            int maxRooms = 5;

            
            DateTime currentDate = DateTime.Now.Date;

            
            int availableRooms = maxRooms;
            foreach (var booking in bookings)
            {
                if (currentDate >= booking.CheckInDate.Date && currentDate < booking.CheckOutDate.Date)
                {
                    availableRooms--;
                }
            }
            return availableRooms;
        }
        private int occupied()
        {
           

            DateTime currentDate = DateTime.Now.Date;

            int occupiedRooms = 0;
            foreach (var booking in bookings)
            {
                if (currentDate >= booking.CheckInDate.Date && currentDate < booking.CheckOutDate.Date)
                {
                    occupiedRooms++;
                }
            }

            return occupiedRooms;
        }
        #endregion


        private void checkAvailabilityButton_Click(object sender, EventArgs e)
        {
            PopulateObject();
            List<Booking> existingBookings = GetExistingBookings();
            if (IsBookingValid(booking, existingBookings))
            {
                RoomAvailableBox roomAvailableBox = new RoomAvailableBox(booking);
                roomAvailableBox.ShowDialog();
            }
            else
            {
                notAvailableLabel.Visible = true;
            }
            setOverview();


        }

        #region validating booking
        private List<Booking> GetExistingBookings()
        {
            List<Booking> existingBookings = new List<Booking>();
            foreach (Booking abooking in bookings)
            {
                existingBookings.Add(abooking);
            }
            return existingBookings;
        }





        static bool IsBookingValid(Booking incomingBooking, List<Booking> existingBookings)
        {
            int availableRooms = 5;

            foreach (var existingBooking in existingBookings)
            {
                if (incomingBooking.CheckInDate < existingBooking.CheckOutDate &&
                    incomingBooking.CheckOutDate > existingBooking.CheckInDate)
                {

                    availableRooms -= existingBooking.NumberOfRooms;
                }
            }


            int numberOfDays = (int)(incomingBooking.CheckOutDate - incomingBooking.CheckInDate).TotalDays;


            return incomingBooking.NumberOfRooms <= availableRooms && numberOfDays > 0;
        }
        #endregion
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

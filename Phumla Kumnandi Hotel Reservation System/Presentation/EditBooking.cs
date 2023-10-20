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
    public partial class EditBooking : Form
    {
        private Booking booking; 
        private BookingController bookingController;
        private Collection<Booking> bookings;
        public EditBooking(Booking booking )
        {
            InitializeComponent();
             this.booking = booking;
            this.bookingController = MDIParent.GetBookingController();
            this.bookings = bookingController.AllBookings;
            nameLabel.Text = booking.GuestId;
            bookingIdLabel.Text = booking.Id.ToString();
            specialRequestInput.Text = booking.SpecialRequest;
            numberOfGuestPicker.Value = booking.NumberOfGuests;
            checkInDateTimePicker.Value = booking.CheckInDate;
            checkOutDateTimePicker.Value = booking.CheckOutDate;

        }
        private void PopulateObject()
        {
            booking.CheckInDate = checkInDateTimePicker.Value;
            booking.CheckOutDate = checkOutDateTimePicker.Value;
            booking.NumberOfGuests = (int)numberOfGuestPicker.Value ;
            booking.NumberOfRooms = calcNumberOfRooms(booking.NumberOfGuests);
            booking.TotalAmount = booking.NumberOfRooms * calcBookingPrice(booking);
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


        private void saveButton_Click(object sender, EventArgs e)
        {
            PopulateObject();
            List<Booking> existingBookings = GetExistingBookings();
            if (IsBookingValid(booking, existingBookings))
            {
                bookingController.DataMaintenance(booking, Data.DB.DBOperation.Edit);
                bookingController.FinalizeChanges(booking);
                this.Close();
            }
            else
            {
                MessageBox.Show("Booking cannot be made on those dates");
            }
           
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





        public bool IsBookingValid(Booking incomingBooking, List<Booking> existingBookings)
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
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}

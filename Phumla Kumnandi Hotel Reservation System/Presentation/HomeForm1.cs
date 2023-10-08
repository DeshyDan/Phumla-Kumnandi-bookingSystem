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
    public partial class HomeForm1 : Form
    {

        #region data members
        private Guest guest;
        private Booking booking; 
        private GuestController guestController;
        private BookingController bookingController;



        #endregion
        public HomeForm1()
        {
            InitializeComponent();
        }
        #region utility methods

        private void ClearAll()
        {
            checkInDateTimePicker.Text= string.Empty;
            checkOutDateTimePicker.Text= string.Empty;
            numberOfGuestPicker.Text= string.Empty;

            
        }
        private void PopulateObject()
        {
            booking = new Booking();
            booking.CheckInDate = checkInDateTimePicker.Value;
            booking.CheckOutDate = checkOutDateTimePicker.Value;
            booking.NumberOfGuests = (int)numberOfGuestPicker.Value;

            
            booking.TotalAmount = calcBookingPrice(booking); 

        }
        private int calcBookingPrice(Booking booking)
        {
            int totalDays = (booking.CheckOutDate - booking.CheckInDate).Days;
            int priceRange1Days = Math.Min(7, totalDays);

            int priceRange2Days = Math.Min(8, totalDays - priceRange1Days);
            int priceRange3Days = totalDays - priceRange1Days - priceRange2Days;
            double range1Price = priceRange1Days * 550;
            double range2Price = priceRange2Days * 750;
            double range3Price = priceRange3Days * 995;
            return (int)(range1Price + range2Price + range3Price);
        }

        #endregion

        private void notAvailableLabel_Click(object sender, EventArgs e)
        {

        }

        private void checkAvailabilityButton_Click(object sender, EventArgs e)
        {

        }
    }
}

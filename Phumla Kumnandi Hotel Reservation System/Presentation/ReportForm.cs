using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Phumla_Kumnandi_Hotel_Reservation_System.bookingSystemDataSetTableAdapters;
using Phumla_Kumnandi_Hotel_Reservation_System.Business;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Presentation
{
    public partial class ReportForm : Form
    {
        private GuestController guestController;
        private BookingController bookingController;
        private Collection<Guest> guests;
        private Collection<Booking> bookings;
        public ReportForm()
        {
            InitializeComponent();
            guestController = MDIParent.GetGuestController();
            bookingController = MDIParent.GetBookingController();
            guests = guestController.AllGuests;
            bookings = bookingController.AllBookings;
        }

        private void checkAvailabilityButton_Click(object sender, EventArgs e)
        {
            String reportType = reportTypePicker.SelectedItem.ToString();
            DateTime startDate = startDateTimePicker.Value;
            DateTime endDate = endDateTimePicker.Value;
            List<Booking> selectedBookings = new List<Booking>();
            // Filter bookings for the selected month
            foreach (var booking in bookings)
            {
                if (booking.CheckInDate <= endDate && booking.CheckOutDate >= startDate)
                {
                    selectedBookings.Add(booking);
                }
            }

            if (reportType == "Sales Report")
            {



                int totalBookings = selectedBookings.Count;
                int totalRevenue = selectedBookings.Sum(b => b.TotalAmount);
                double averageBookingValue = totalRevenue / (double)totalBookings;
                double occupancyRate = CalculateOccupancyRate(selectedBookings);
                double averageLengthOfStay = CalculateAverageLengthOfStay(selectedBookings);
                string report = $"Sales Report for {startDate.ToString("MMMM yyyy")} - {endDate.ToString("MMMM yyyy")}\n";
                report += $"Report generated on {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n\n";
                report += "++++++++++++++++++\n";
                report += "Summary:\n";
                report += $"Total Bookings: {totalBookings}\n";
                report += $"Total Revenue: R{totalRevenue}\n";
                report += $"Average Booking Value: R{averageBookingValue:F2}\n";
                report += $"Occupancy Rate: {occupancyRate:F2}%\n\n";
                report += "++++++++++++++++++\n";
                report += "Sales Performance Metrics:\n";
                report += $"Total Revenue: R{totalRevenue}\n";
                report += $"Total Bookings: {totalBookings}\n\n";
                report += "++++++++++++++++++\n";
                report += "Property Analysis:\n";
                report += $"Occupancy Rate: {occupancyRate:F2}%\n";
                report += $"Average Length of Stay: {averageLengthOfStay:F2} days";

                ReportDisplay reportDisplay = new ReportDisplay(report);
                reportDisplay.Show();
            }
            else
            {
                //
                int totalRevenue = selectedBookings.Sum(b => b.TotalAmount);
                int totalBookings = selectedBookings.Count;
                double occupancyRate = CalculateOccupancyRate(selectedBookings);
                double averageDailyRate = CalculateAverageDailyRate(selectedBookings);
                double revPAR = (averageDailyRate * occupancyRate) / 100.0;
                double averageLengthOfStay = CalculateAverageLengthOfStay(selectedBookings);
                double averageBookingValue = totalRevenue / (double)totalBookings;
                string report = $"Occupancy Report for {startDate.ToString("MMMM yyyy")} - {endDate.ToString("MMMM yyyy")}\n";
                report += $"Report generated on {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n\n";
                report += "++++++++++++++++++\n";
                report += "Summary:\n";
                report += $"Occupancy Rate: {occupancyRate:F2}%\n";
                report += $"Total Rooms: 5 \n";
                report += $"Total Bookings: {totalBookings}\n";
                report += $"Average Length of Stay: {averageLengthOfStay:F2} days\n";
                report += $"Average Daily Rate (ADR): R{averageDailyRate:F2}\n";
                report += $"Revenue Per Available Room (RevPAR): R{revPAR:F2}\n";
                ReportDisplay reportDisplay = new ReportDisplay(report);
                reportDisplay.Show();
            }

        }

        private int GetTotalRooms()
        {

            return 5;
        }

        private int GetOccupiedRooms(List<Booking> selectedBookings)
        {

            return selectedBookings.Count;
        }

        private double CalculateAverageDailyRate(List<Booking> selectedBookings)
        {

            return 730.0;
        }
        private double CalculateOccupancyRate(List<Booking> selectedBookings)
        {

            int totalNights = selectedBookings.Sum(b => (b.CheckOutDate - b.CheckInDate).Days);
            int occupiedNights = selectedBookings.Count;
            return (occupiedNights / (double)totalNights) * 100.0;
        }

        private double CalculateAverageLengthOfStay(List<Booking> selectedBookings)
        {

            int totalNights = selectedBookings.Sum(b => (b.CheckOutDate - b.CheckInDate).Days);
            int totalBookings = selectedBookings.Count;
            return totalBookings > 0 ? (totalNights / (double)totalBookings) : 0.0;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}

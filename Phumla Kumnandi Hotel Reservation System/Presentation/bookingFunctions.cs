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
    public partial class BookingFunctions : Form
    {
        private Booking booking;
        private BookingController bookingController;    
        public BookingFunctions(Booking booking)
        {
            InitializeComponent();
            this.booking = booking;
            bookingController = MDIParent.GetBookingController();
        }

        private void bookingFunctions_Load(object sender, EventArgs e)
        {

        }

      

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteBooking deleteBooking = new DeleteBooking(booking);
            deleteBooking.ShowDialog();
            this.Close();
        }

        private void bookingFunctions_Click(object sender, EventArgs e)
        {

        }

        private void payButton_Click(object sender, EventArgs e)
        {
            int newDeposit = booking.Deposit + 200;

           
            if (newDeposit <= booking.TotalAmount)
            {
                
                booking.Deposit = newDeposit;
               
            }
            else
            {
                booking.Deposit = booking.TotalAmount;
                MessageBox.Show("Depost has fully been paid");
            }
            bookingController.DataMaintenance(booking, Data.DB.DBOperation.Edit);
            bookingController.FinalizeChanges(booking);
            this.Close();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditBooking editBooking = new EditBooking(booking);
            editBooking.ShowDialog();
            this.Close();
        }
    }
}

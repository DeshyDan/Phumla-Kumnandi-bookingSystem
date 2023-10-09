using Phumla_Kumnandi_Hotel_Reservation_System.Business;
using Phumla_Kumnandi_Hotel_Reservation_System.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;




namespace Phumla_Kumnandi_Hotel_Reservation_System.Presentation
{
    public partial class BookingsForm : Form
    {

        #region Enum 
        public enum FormState
        {
            View = 0,
            Add = 1,
            Edit = 2,
            Delete = 3
        }


        #endregion
        #region instance variables
        public bool listFormClosed;
        private Collection<Booking> bookings;
        private Collection<Guest> guests;
        private BookingController bookingController;
        private GuestController guestController;
        private FormState state;
        private Booking booking;
        #endregion


        #region Constructor
        public BookingsForm()
        {
            InitializeComponent();
            this.guestController = MDIParent.GetGuestController();
            this.bookingController = MDIParent.GetBookingController();

            state = FormState.View;
        }
      
        #endregion 

        private void Filter_Click(object sender, EventArgs e)
        {

        }



        private void BookingsForm_Load(object sender, EventArgs e)
        {
            bookingListView.View = View.Details;
        }

        private void BookingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            listFormClosed = true;
        }

        private void BookingsForm_Activated(object sender, EventArgs e)
        {
            bookingListView.View = View.Details;
            setUpBookingListView();
        }

        #region setting up the list view
        public void setUpBookingListView()
        {
            ListViewItem bookingDetails;
            bookingListView.Clear();
            bookings = bookingController.AllBookings;
            bookingListView.Columns.Insert(0, "Booking ID", 100, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(1, "Check In Date", 120, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(2, "Check Out Date", 120, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(3, "No. Of Guest", 120, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(4, "Total Amount", 120, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(5, "Deposit Paid", 120, HorizontalAlignment.Left);
         

            foreach (Booking abooking in bookings)
            {
                bookingDetails = new ListViewItem(abooking.Id.ToString());

                bookingDetails.SubItems.Add(abooking.CheckInDate.ToString());
                bookingDetails.SubItems.Add(abooking.CheckOutDate.ToString());
                bookingDetails.SubItems.Add(abooking.NumberOfGuests.ToString());
                bookingDetails.SubItems.Add(abooking.TotalAmount.ToString());
                bookingDetails.SubItems.Add(abooking.Deposit.ToString());
             
                bookingListView.Items.Add(bookingDetails);
            }
            bookingListView.Refresh();
            bookingListView.GridLines = true;

        }
      
        #endregion

        private void bookingListView_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            if (bookingListView.SelectedItems.Count >0)
            {
               
                booking = bookingController.Find(bookingListView.SelectedItems[0].Text);
                
               BookingFunctions bookingFunctions = new BookingFunctions(booking);
                bookingFunctions.ShowDialog(); 
              

            }
            
            setUpBookingListView();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void bookingListView_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }

}

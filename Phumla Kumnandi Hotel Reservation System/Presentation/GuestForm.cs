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
using Phumla_Kumnandi_Hotel_Reservation_System.bookingSystemDataSetTableAdapters;
using Phumla_Kumnandi_Hotel_Reservation_System.Business;
using Phumla_Kumnandi_Hotel_Reservation_System.Data;
using static Phumla_Kumnandi_Hotel_Reservation_System.Presentation.BookingsForm;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Presentation
{
    public partial class GuestForm : Form
    {
        #region instance variables
        public bool listFormClosed;
        private Collection<Booking> bookings;
        private Collection<Guest> guests;
        private BookingController bookingController;
        private GuestController guestController;
        private FormState state;
        private Booking booking;
        private Guest guest;

        #endregion

        public GuestForm()
        {
            InitializeComponent();
            this.guestController = MDIParent.GetGuestController();
            this.bookingController = MDIParent.GetBookingController();

        }

    
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {



        }

        private void Guest_Load(object sender, EventArgs e)
        {
            guestListView.View = View.Details;
        }


     




#region settign up he list view
        public void setUpGuestListView()
        {
            ListViewItem guestDetails;
            guestListView.Clear();
            bookings = bookingController.AllBookings;
            guests = guestController.AllGuests;
            guestListView.Columns.Insert(0, "Id Number", 120, HorizontalAlignment.Left);
    
            guestListView.Columns.Insert(1, "First Name", 120, HorizontalAlignment.Left);
        
            guestListView.Columns.Insert(2, "Email", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(3, "Telephone", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(4, "Address", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(5, "Credit", 120, HorizontalAlignment.Left);


            foreach (Guest guest in guests)
            {
                guestDetails = new ListViewItem(guest.IdNumber.ToString());
              
                guestDetails.SubItems.Add(guest.FirstName.ToString());
              
                guestDetails.SubItems.Add(guest.Email.ToString());
                guestDetails.SubItems.Add(guest.Telephone.ToString());
                guestDetails.SubItems.Add(guest.Address.ToString());
                guestDetails.SubItems.Add(CalculateUnpaidAmountForGuest(guest.IdNumber , bookings).ToString());
                guestListView.Items.Add(guestDetails);
            }
            guestListView.Refresh();
            guestListView.GridLines = true;

        }

        #endregion
        #region calculate credit
        private int CalculateUnpaidAmountForGuest(string guestId, Collection<Booking> bookings)
        {
            int totalUnpaidAmount = 0;

            foreach (var booking in bookings)
            {
                if (booking.GuestId == guestId)
                {
                    int unpaidAmount = booking.TotalAmount - booking.Deposit;
                    totalUnpaidAmount += unpaidAmount;
                }
            }

            return totalUnpaidAmount;
        }
        #endregion
        private void GuestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            listFormClosed = true;
        }

        private void guestListView_ItemActivate(object sender, EventArgs e)
        {

        }

        private void GuestForm_Activated(object sender, EventArgs e)
        {
            guestListView.View = View.Details;
            setUpGuestListView();
        }

      

        private void guestListView_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = searchInput.Text.Trim().ToLower(); // Convert to lowercase for case-insensitive search

            // Check if the input is empty
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            // Clear the ListView
            guestListView.Items.Clear();

            // Filter guests based on search criteria
            foreach (Guest guest in guests)
            {
                if (guest.FirstName.ToLower().Contains(searchTerm) ||
                    guest.Email.ToLower().Contains(searchTerm) ||
                    guest.Telephone.ToLower().Contains(searchTerm))
                {
                    ListViewItem guestDetails = new ListViewItem(guest.IdNumber.ToString());
                    guestDetails.SubItems.Add(guest.FirstName.ToString());
                    guestDetails.SubItems.Add(guest.Email.ToString());
                    guestDetails.SubItems.Add(guest.Telephone.ToString());
                    guestDetails.SubItems.Add(guest.Address.ToString());
                    guestDetails.SubItems.Add(CalculateUnpaidAmountForGuest(guest.IdNumber, bookings).ToString());
                    guestListView.Items.Add(guestDetails);
                }
            }
        }

        private void searchInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            setUpGuestListView();
        }
    }
}

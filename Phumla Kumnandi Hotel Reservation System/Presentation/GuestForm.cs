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
using Phumla_Kumnandi_Hotel_Reservation_System.bookingSystemTestDataSetTableAdapters;
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
            guestListView.Columns.Insert(1, "Title", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(2, "First Name", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(3, "LastName", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(4, "email", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(5, "telephone", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(6, "address", 120, HorizontalAlignment.Left);
         

            foreach (Guest guest in guests)
            {
                guestDetails = new ListViewItem(guest.IdNumber.ToString());
                guestDetails.SubItems.Add(guest.Title.ToString());
                guestDetails.SubItems.Add(guest.FirstName.ToString());
                guestDetails.SubItems.Add(guest.LastName.ToString());
                guestDetails.SubItems.Add(guest.Email.ToString());
                guestDetails.SubItems.Add(guest.Telephone.ToString());
                guestDetails.SubItems.Add(guest.Address.ToString());

                guestListView.Items.Add(guestDetails);
            }
            guestListView.Refresh();
            guestListView.GridLines = true;

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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phumla_Kumnandi_Hotel_Reservation_System.Business;
namespace Phumla_Kumnandi_Hotel_Reservation_System.Presentation
{
    public partial class MDIParent : Form
    {
        #region instance variables
        private int childFormNumber = 0;
        private BookingsForm bookingsForm;
        private RoomsForm roomsForm;
        private GuestForm guestForm;
        private HomeForm homeForm;

        private BookingController bookingController;
        private GuestController guestController;

        #endregion

        #region Singletons for controllers
        private static GuestController guestControllerInstance;
        public static GuestController GetGuestController()
        {
            if (guestControllerInstance == null)
            {
                guestControllerInstance = new GuestController();
            }
            return guestControllerInstance;
        }
        private static BookingController bookingControllerInstance;

        public static BookingController GetBookingController()
        {
            if (bookingControllerInstance == null)
            {
                bookingControllerInstance = new BookingController();
            }
            return bookingControllerInstance;
        }


        #endregion
        public MDIParent()
        {
            InitializeComponent();
            bookingController = GetBookingController();
            guestController = GetGuestController();

          
            CreateHomeForm();

            homeForm.Show();
        }

        private void MDIParent_Load(object sender, EventArgs e)
        {

        }
        #region Nav bar elements
        private void homeNavLabel_Click(object sender, EventArgs e)
        {
            if (homeForm == null)
            {
                CreateHomeForm();
            }
            if (homeForm.listFormClosed)
            {
                CreateHomeForm();
            }
            homeForm.Show();
        }


        #endregion
        #region close other mdi childs

        private void closeMDIS()
        {
            foreach (Form mdiChild in this.MdiChildren)
            {
                mdiChild.Close();
            }

        }
        #endregion
        #region Creating the new child forms
        private void CreateHomeForm()
        {
            closeMDIS();
            homeForm = new HomeForm();
            homeForm.MdiParent = this;


            homeForm.Location = new Point(300, 0);
        }
        private void CreateBookingForm()
        {
            closeMDIS();
            bookingsForm = new BookingsForm();
            bookingsForm.MdiParent = this;
            bookingsForm.Location = new Point(300, 0);
        }
        private void CreateRoomsForm()
        {
            closeMDIS();
            roomsForm = new RoomsForm();
            roomsForm.MdiParent = this;
            roomsForm.Location = new Point(300, 0);

        }
        private void CreateGuestForm()
        {
            closeMDIS();
            guestForm = new GuestForm();
            guestForm.MdiParent = this;
            guestForm.Location = new Point(300, 0);
        }
        #endregion

        private void logoutButton_Click(object sender, EventArgs e)
        {

        }

        private void bookingNavLabel_Click(object sender, EventArgs e)
        {

            if (bookingsForm == null)
            {
                CreateBookingForm();
            }
            if (bookingsForm.listFormClosed)
            {
                CreateBookingForm();
            }
            bookingsForm.setUpBookingListView();
            bookingsForm.Show();
        }

        private void guestNavLabel_Click(object sender, EventArgs e)
        {
            if (guestForm == null)
            {
                CreateGuestForm();
            }
            if (guestForm.listFormClosed)
            {
                CreateGuestForm();
            }
            guestForm.setUpGuestListView();

            guestForm.Show();
        }

        private void roomNavLabel_Click(object sender, EventArgs e)
        {
            if (roomsForm == null)
            {
                CreateRoomsForm();
            }

            if (roomsForm.listFormClosed)
            {
                CreateRoomsForm();
            }
            roomsForm.Show();
        }
    }
}

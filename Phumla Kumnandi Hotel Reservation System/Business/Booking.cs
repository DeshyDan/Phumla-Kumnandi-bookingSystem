using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Phumla_Kumnandi_Hotel_Reservation_System.Business
{
    public class Booking
    {
        public enum BookingStatus
        {
            Pending = 0,
            Confirmed = 1,
            Cancelled = 2
        }
        #region DataMembers
        public int BookingID;
        public BookingStatus Status;
        public string Checkin;
        public string Checkout;
        public int GuestID;
        public static int count = 0;
        public int RoomId;
        public string Description;
        public int NoOfGuests;
        public int Deposit;
        public decimal TotalAmount;
        #endregion
        #region Constructor
        public Booking(int bookingId, int guestId, int roomID, string checkin, string checkout, string description, int noOfGuests, int deposit, decimal totalAmount)
        {
            this.BookingID = bookingId;
            this.Checkin = checkin;
            this.Checkout = checkout;
            this.GuestID = guestId;
            this.RoomId = roomID;
            this.Description = description;
            this.NoOfGuests = noOfGuests;
            this.Deposit = deposit;
            this.TotalAmount = totalAmount;
        }
        #endregion region
        #region Methods
        public int bookingID
        {
            get { return BookingID; }
            set { BookingID = value; }

        }
        public string checkin
        {
            get { return Checkin; }
            set { Checkin = value; }
        }
        public string checkout
        {
            get { return Checkout; }
            set { Checkout = value; }
        }
        public string description
        {
            get { return Description; }
            set { Description = value; }
        }
        public int noOfGuests
        {
            get { return NoOfGuests; }
            set { NoOfGuests = value; }
        }
        public int deposit
        {
            get { return Deposit; }
            set { Deposit = value; }
        }
        decimal totalAmount
        {
            get { return TotalAmount; }
            set { TotalAmount = value; }
        }
        #endregion
        #region Booking Generator
        public int GetBookingID()
        {
            return this.bookingID;
        }
        #endregion
    }
}
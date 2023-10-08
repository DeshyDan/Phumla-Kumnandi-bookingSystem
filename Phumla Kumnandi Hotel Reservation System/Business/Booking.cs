using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
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

        private int id;
        private BookingStatus status;
        private DateTime checkInDate;
        private DateTime checkOutDate;
        private string guestId;
        private int numberOfRoom;
        private string specialRequest;
        private int noOfGuests;
        private int deposit;
        private int totalAmount;

        #endregion

        #region Constructor
        public Booking(int bookingId, string guestId, int roomID, DateTime checkin, DateTime checkout, string description, int noOfGuests, int deposit, int totalAmount)
        {

            this.id = bookingId;
            this.checkInDate = checkin;
            this.checkOutDate = checkout;
            this.guestId = guestId;
            this.numberOfRoom = roomID;
            this.specialRequest = description;
            this.noOfGuests = noOfGuests;
            this.deposit = deposit;
            this.totalAmount = totalAmount;
            this.status = BookingStatus.Pending;
        }
        public Booking()
        {


        }
        #endregion region
        #region Methods
        public int Id
        {
            get { return id; }
            set { id = value; }

        }
        public string GuestId
        {
            get { return guestId; }
            set { guestId = value; }
        }
        public DateTime CheckInDate
        {
            get { return checkInDate; }
            set { checkInDate = value; }
        }
        public DateTime CheckOutDate
        {
            get { return checkOutDate; }
            set { checkOutDate = value; }
        }


        public string SpecialRequest
        {
            get { return specialRequest; }
            set { specialRequest = value; }
        }
        public int NumberOfGuests
        {
            get { return noOfGuests; }
            set { noOfGuests = value; }

        }
        public int Deposit
        {
            get { return deposit; }
            set { deposit = value; }
        }
        public int TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }
        public int NumberOfRooms
        {
            get { return numberOfRoom; }
            set { numberOfRoom = value; }
        }

        public int BookingStatusId
        {
            get { return (int)status; }
            set
            {
                switch (value)
                {
                    case 0:
                        status = BookingStatus.Pending;
                        break;
                    case 1:
                        status = BookingStatus.Confirmed;
                        break;
                    case 2:
                        status = BookingStatus.Cancelled;
                        break;
                }

            }
        }
        #endregion

    }
}
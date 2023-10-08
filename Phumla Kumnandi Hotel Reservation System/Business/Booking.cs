using System;
using System.Collections.Generic;
using System.Linq;
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

        public int id;
        public BookingStatus status;
        public DateTime checkInDate;
        public DateTime checkOutDate;
        public int guestId;
        public int numberOfRoom;
        public string specialRequest;
        public int noOfGuests;
        public int deposit;
        public int totalAmount;

        #endregion

        #region Constructor
        public Booking(int bookingId, int guestId, int roomID, DateTime checkin, DateTime checkout, string description, int noOfGuests, int deposit, int totalAmount)
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
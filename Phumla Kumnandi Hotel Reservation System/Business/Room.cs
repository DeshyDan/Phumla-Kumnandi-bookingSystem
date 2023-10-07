using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Business
{
    public class Room
    {
        #region Data Members
     
        public int RoomNumber;
        public string RoomType;
        public decimal RoomRate;
        public string RoomOfferings;
        public bool RoomAvailibility=false;
        #endregion
        #region Property Methods
        public int roomNumber
        {
            get { return roomNumber; } set {  roomNumber = value; }
        }
        public string roomType
        {
            get { return roomType; } set { roomType = value; }

        }
        private decimal roomRate
        {
            get { return roomRate; }    
            set { roomRate = value; }
        }
        public string roomOffering
        {
            get { return roomOffering; } set { roomOffering = value; }

        }
        public string roomOfferings
        {
            get { return roomOfferings; }
            set { roomOfferings = value; }
        }
        public bool roomAvailibility
        {
            get { return roomAvailibility; }
            set { roomAvailibility = value; }
        }
        #endregion
        #region Constructor
        public Room(int roomNumber, string roomType, decimal roomRate, string roomOfferings)
        {
            this.RoomNumber = roomNumber;
            this.RoomType = roomType;
            this.RoomRate = roomRate;
            this.RoomOfferings = roomOfferings;


        }
        #endregion
        #region Utility Methods
        public void checkIn()
        {
            RoomAvailibility = true;
        }
        public void checkOut()
        {
            RoomAvailibility = false;
        }
        #endregion
    }
}

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
        private int id;
        private int roomNumber;
        private string roomDescription;
        public int rate;
 
        public bool RoomAvailibility;
        #endregion
       
        #region Constructor
        public Room(int id, int roomNumber, string roomDescription, int rate)
        {
            Id = id;
            RoomNumber = roomNumber;
            RoomDescription = roomDescription;
            Rate = rate;
            RoomAvailibility = true;
        }

        public Room()
        {
            RoomAvailibility = true;
        }

        #endregion
        #region Utility Methods
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string RoomDescription { get; set; }
        public int Rate { get; set; }
        public bool RoomAvailability { get; set; }


        public void CheckOut()
        {
            RoomAvailibility = true;
        }
        public void CheckIn()
        {
            RoomAvailibility = false;
        }
        #endregion
    }
}

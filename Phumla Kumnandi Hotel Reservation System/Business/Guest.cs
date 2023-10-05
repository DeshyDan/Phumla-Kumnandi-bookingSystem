using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Business
{

    public class Guest
    {
        #region DataMembers
        private int _GuestId;
        private string _IdNumber;
        private string _FirstName;
        private string _LastName;
        private int _Telephone;
        private string _Email;
        private string _Title;
        private string _Address;
        private int _RoomAccount;
        #endregion
        #region methods

        public string IdNumber
        {
            get { return _IdNumber; }
            set { _IdNumber = value; }
        }
        public int GuestId
        {
            get { return _GuestId; }
            set { _GuestId = value; }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }

        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public int Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public int RoomAccount
        {
            get { return _RoomAccount; }
            set { _RoomAccount = value; }
        }
        #endregion
        #region constructor
        public Guest(int guestID, string idNumber, string firstName, string lastName, int telephone, string email, string title, string address)
        {
            GuestId = guestID;
            IdNumber = idNumber;
            FirstName = firstName;
            LastName = lastName;
            Telephone = telephone;
            Email = email;
            Title = title;
            Address = address;


        }
        public Guest()
        {
            
        }
        #endregion

    }
}

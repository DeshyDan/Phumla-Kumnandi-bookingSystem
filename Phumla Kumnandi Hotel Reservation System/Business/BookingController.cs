
using Phumla_Kumnandi_Hotel_Reservation_System.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Business
{

    
        public class BookingController
        {
            #region Data Members
            BookingDB bookingDB;
            Collection<Booking> bookings;
        #endregion
            #region Properties
        public Collection<Booking> AllBookings
        {
            get { return bookings; }

        }
        #endregion

        #region Constructor
        public BookingController()
        {
            bookingDB = new BookingDB();
            bookings = bookingDB.AllBookings;

        }
        #endregion
        #region Database Communication
        public void DataMaintenance(Booking aBooking, DB.DBOperation operation)
        {
            int index = 0;
            bookingDB.DataSetChange(aBooking, operation);

            switch (operation)
            {
                case DB.DBOperation.Add:
                    bookings.Add(aBooking);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aBooking);
                    bookings.RemoveAt(index);
                    bookings.Insert(index, aBooking);

                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aBooking);
                    bookings.RemoveAt(index);
                    break;

            }
        }
        public bool FinalizeChanges(Booking aBooking,DB.DBOperation operation)
        {
            return bookingDB.UpdateDataSource(aBooking);
        }
        #endregion
        #region Search Method
        public Booking Find(string ID)
        {
            int index = 0;
            bool found = (bookings[index].BookingID == Convert.ToInt32(ID));
            int count = bookings.Count;
            while (!(found) && (index < bookings.Count - 1))
            {

                index = index + 1;
               
                found = (bookings[index].BookingID == Convert.ToInt32(ID));
            }
            return bookings[index];
        }
        public int FindIndex(Booking aBooking)
        {
            int counter = 0;
            bool found = false;
            found = (aBooking.BookingID == bookings[counter].BookingID);
            while (!(found) && counter < bookings.Count - 1)
            {

                counter++;
                found = (aBooking.BookingID == bookings[counter].BookingID);


            }
            if (found)
            {
                return counter;
            }
            else
            {
                return -1;
            }
        }

        #endregion

    }
}

    
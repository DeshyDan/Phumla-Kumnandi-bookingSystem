
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
            Collection<BookingController> bookings;
        #endregion
            #region Properties
        public Collection<Business.BookingController> AllBookings
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
                    index = FindIndex(aBooking.ToString());
                    bookings.RemoveAt(index);
                    bookings.Insert(index, aBooking);

                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aBooking.ToString());
                    bookings.RemoveAt(index);
                    break;

            }
        }
        public bool FinalizeChanges(DB.DBOperation operation)
        {
            return bookingDB.UpdateDataSource(operation);
        }
        #endregion
        #region Search Method
        public Business.BookingController Find(string ID)
        {
            int index = 0;
            bool found = false;
            int count = bookings.Count;
            while (!(found) && (index < bookings.Count - 1))
            {
                    if(bookings[index].BookingID==ID)
                    {
                        found= true;
                        return bookings[index];
                    }
                     index++;
                

            }
        }
        public int FindIndex(string id)
        {
            int counter = 0;
            bool found = false;
            while (!(found) && counter < bookings.Count - 1)
            {
                


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

    
using Phumla_Kumnandi_Hotel_Reservation_System.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Business
{
    public class GuestController
    {
        #region Data Members
        GuestDB guestDB;
        Collection<Guest> guests;
        #endregion
        #region properties
        public Collection<Guest> AllGuest
        {
            get { return guests; }

        }
        #endregion
        #region Constructor
        public GuestController()
        {
            guestDB = new GuestDB();
            guests = guestDB.AllGuests;


        }
        #endregion
        #region Database Communication
        public void DataMaintenance(Guest aGuest, DB.DBOperation operation)
        {
            Debug.WriteLine("Inside DataMaintence");
            int index = 0;
            guestDB.DataSetChange(aGuest, operation);

            switch (operation)
            {
                case DB.DBOperation.Add:
                    Debug.WriteLine("operation is Added");
                    guests.Add(aGuest);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aGuest);
                    guests[index] = aGuest;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aGuest);
                    guests[index] = aGuest;
                    break;

            }
        }
        #endregion
        #region     Database Commuincation
        public void DataMaintenacne(Guest aGuest, DB.DBOperation operation)
        {
            Debug.WriteLine("Inside Data Maintenance");
            int index = 0;
            guestDB.DataSetChange(aGuest, operation);

            switch (operation)
            {
                case DB.DBOperation.Add:
                    Debug.WriteLine("operation is added");
                    guests.Add(aGuest);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aGuest);
                    guests[index] = aGuest;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aGuest);
                    guests.RemoveAt(index);
                    break;

            }
        }
        public Guest findGuest(Guest guestToFind)
        {
            foreach (Guest existingGuest in guests)
            {
                if (existingGuest.Email == guestToFind.Email)
                {
                
                    return existingGuest;
                }
            }

         
            return guestToFind;
        }
        public bool FinalizeChanges(Guest guest)
        {
            Debug.WriteLine("Inside FinalizeChange");
            return guestDB.UpdateDataSource(guest);

        }
        #endregion
        #region Searching through a collection
      /*  public Collection<Guest> FindByGuest(Collection<Guest> aGuest)
        {
            Collection<Guest> matches = new Collection<Guest>();
            foreach (Guest guest in aGuest)
            {
                if (guest.IdNumber.Equals(Guest(), StringComparison.OrdinalIgnoreCase))
                {
                    matches.Add(guest);
                }
            }
            return matches;
        }*/
        public Guest Find(String ID)
        {
            int index = 0;
            bool found = (guests[index].Id.Equals(ID));
            int count = guests.Count;
            while (!(found) && (index < guests.Count - 1))
            {
                index = index + 1;
                found = (guests[index].Id.Equals(ID));
            }
            return guests[index];

        }
        public int FindIndex(Guest aGuest)
        {
            int counter = 0;
            bool found = false;
            found = (aGuest.Id.Equals(aGuest.Id));
            while (!(found) && counter < guests.Count - 1)
            {
                counter++;
                found = (aGuest.Id == aGuest.Id);

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
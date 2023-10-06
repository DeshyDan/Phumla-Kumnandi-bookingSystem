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
        Collection<Guest> guest;
        #endregion
        #region properties
        public Collection<Guest> AllGuest
        {
            get { return guest; }

        }
        #endregion
        #region Constructor
        public GuestController()
        {
            guestDB = new GuestDB();
            guest = guestDB.AllGuests;


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
                    guest.Add(aGuest);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aGuest);
                    guest[index] = aGuest;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aGuest);
                    guest[index] = aGuest;
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
                    guest.Add(aGuest);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aGuest);
                    guest[index] = aGuest;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aGuest);
                    guest.RemoveAt(index);
                    break;

            }
        }
        public bool FinlizeChanges(Guest guest, DB.DBOperation operation)
        {
            Debug.WriteLine("Inside FinalizeChange");
            return guestDB.UpdateDataSource(guest, operation);

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
            bool found = (guest[index].Id.Equals(ID));
            int count = guest.Count;
            while (!(found) && (index < guest.Count - 1))
            {
                index = index + 1;
                found = (guest[index].Id.Equals(ID));
            }
            return guest[index];

        }
        public int FindIndex(Guest aGuest)
        {
            int counter = 0;
            bool found = false;
            found = (aGuest.Id.Equals(aGuest.Id));
            while (!(found) && counter < guest.Count - 1)
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
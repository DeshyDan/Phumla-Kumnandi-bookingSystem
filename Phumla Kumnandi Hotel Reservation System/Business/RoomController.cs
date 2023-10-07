using Phumla_Kumnandi_Hotel_Reservation_System.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Business
{
    public class RoomController
    {
        #region Data Members
        private RoomDB roomDB;
        private Collection<Room> rooms;
        #endregion

        #region Properties
        public Collection<Room> AllRooms
        {
            get { return rooms; }
        }
        #endregion

        #region Constructor
        public RoomController()
        {
            roomDB = new RoomDB();
            rooms = roomDB.AllRooms;
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(Room aRoom, DB.DBOperation operation)
        {
            int index = 0;
            roomDB.DataSetChange(aRoom, operation);

            switch (operation)
            {
                case DB.DBOperation.Add:
                    rooms.Add(aRoom);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aRoom);
                    rooms.RemoveAt(index);
                    rooms.Insert(index, aRoom);
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aRoom);
                    rooms.RemoveAt(index);
                    break;
            }
        }

        public bool FinalizeChanges(Room aRoom, DB.DBOperation operation)
        {
            return roomDB.UpdateDataSource(aRoom);
        }
        #endregion

        #region Search Method
        public Room Find(int roomNumber)
        {
            int index = 0;
            bool found = (rooms[index].RoomNumber == roomNumber);

            while (!found && index < rooms.Count - 1)
            {
                index = index + 1;
                found = (rooms[index].RoomNumber == roomNumber);
            }

            return found ? rooms[index] : null;
        }

        public int FindIndex(Room aRoom)
        {
            int counter = 0;
            bool found = false;
            found = (aRoom.RoomNumber == rooms[counter].RoomNumber);
            while (!found && counter < rooms.Count - 1)
            {
                counter++;
                found = (aRoom.RoomNumber == rooms[counter].RoomNumber);
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

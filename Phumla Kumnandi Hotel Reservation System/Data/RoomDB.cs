using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Data
{
    public  class RoomDB :DB
    {

        #region instance variables 
        private string guestTable = "room";
        private string sqlLocal1 = "SELECT * FROM room";
        private Collection<Room> rooms;

        #endregion


        #region constructor
        public RoomDB() : base()
        {
            rooms = new Collection<Room>();
            FillDataSet(sqlLocal1, guestTable);
            AddToCollection(guestTable);
        }
        #endregion
        #region Utility Methods
        public DataSet GetDataSet()
        {
            return dataSet;
        }

        private void AddToCollection(string table)
        {
            DataRow myRow = null;
            Room room;

            foreach (DataRow row in dataSet.Tables[table].Rows)
            {
                myRow = row;

                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    room = new Room();
                    room.Id = Convert.ToString(myRow["id"]).TrimEnd();
                   
                    rooms.Add(room);

                }
            }
        }

        private void FillRow(DataRow row, Room room, DB.DBOperation operation)
        {
            if (operation == DB.DBOperation.Add)
            {

                row["id"] = room.Id;
             

            }
            row["roomTypeId"] = room.roomTypeId;
            row["roomStatusId"] = room.RoomStatusId;
            row["promotionId"] = room.PromotionId;
            row["roomNumber"] = room.RoomNumber;
            row["rate"] = room.Rate;
           
        }
        private int FindRow(Room room, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow row in dataSet.Tables[table].Rows)
            {
                myRow = row;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    if (room.Id == Convert.ToString(dataSet.Tables[table].Rows[rowIndex]["id"]))
                    {
                        returnValue = rowIndex;
                    }
                }
                rowIndex++;
            }

            return returnValue;
        }
        #endregion
        #region CRUD operataions
        public void DataSetChange(Room room, DB.DBOperation operation)
        {

            DataRow row = null;
            string dataTable = guestTable;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    row = dataSet.Tables[dataTable].NewRow();
                    FillRow(row, room, operation);
                    dataSet.Tables[dataTable].Rows.Add(row);
                    break;
                case DB.DBOperation.Edit:
                    row = dataSet.Tables[dataTable].Rows[FindRow(room, dataTable)];
                    FillRow(row, room, operation);
                    break;
                case DB.DBOperation.Delete:
                    int rowIndexToDelete = FindRow(room, dataTable);
                    if (rowIndexToDelete != -1)
                    {
                        dataSet.Tables[dataTable].Rows.RemoveAt(rowIndexToDelete);
                    }
                    break;

            }
        }

        #endregion

        #region build parameters, create commands and update database
        private void insert(Room room)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@id", SqlDbType.Int, 50, "id");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@roomTypeId", SqlDbType.NChar, 13, "roomTypeId");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("roomStatusId", SqlDbType.NChar, 13, "roomStatusId");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@promotionId", SqlDbType.NVarChar, 50, "promotionId");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@roomNumber", SqlDbType.NVarChar, 50, "roomNumber");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@rate", SqlDbType.NVarChar, 255, "rate");
            dataAdapter.InsertCommand.Parameters.Add(param);

        }


      

      

        public bool UpdateDataSource(Room room)
        {
            bool sucess = true;
         


            UpdateDataSource(sqlLocal1, guestTable);

            return sucess;
        }
        #endregion


        #region getters and setters
        public Collection<Room> AllRooms
        {
            get
            {
                return rooms;
            }
        }
        #endregion
    }
}

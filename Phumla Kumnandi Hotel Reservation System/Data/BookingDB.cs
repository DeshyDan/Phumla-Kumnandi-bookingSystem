using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phumla_Kumnandi_Hotel_Reservation_System.Business;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Data
{
    public class BookingDB:DB
    {

        #region data members
        private string bookingTable = "bookings";
        private string sqlLocal1 = "SELECT * FROM bookings";
        private Collection<Booking> bookings;
        #endregion

        #region constructor 
        public BookingDB(): base()
        {
            bookings = new Collection<Booking> ();
            FillDataSet(sqlLocal1, bookingTable);
            AddToCollection(bookingTable); 

        }

        #endregion


        #region Utility methods
        public DataSet GetDataSet()
        {
            return dataSet;
        }

        private void AddToCollection(string table)
        {
            DataRow myRow = null;
            Booking booking; 
            foreach(DataRow row in dataSet.Tables[table].Rows)
            {
                myRow = row; 
                if(!(myRow.RowState == DataRowState.Deleted))
                {
                    booking = new Booking();
                    booking.Id = Convert.ToInt32(myRow["id"]);
                    booking.RoomId = Convert.ToInt32(myRow["roomId"]);
                    booking.BookingStatusId = Convert.ToString(myRow["bookingStatusId"]).TrimEnd();
                    booking.ArrivalDate = Convert.ToString(myRow["arrivalDate"]).TrimEnd();
                    booking.TotalAmount = Convert.ToString(myRow["totalAmount"]).TrimEnd();
                    booking.Deposit = Convert.ToString(myRow["deposit"]).TrimEnd();
                    booking.NumberOfGuest = Convert.ToString(myRow["numberOfGuest"]).TrimEnd();
                    booking.SpecialRequest = Convert.ToString(myRow["specialRequest"]).TrimEnd();
                }
                bookings.Add(booking);
            }
           
        }

        private void FillRow(DataRow row, Booking booking, DB.DBOperation operation)
        {
            if (operation == DB.DBOperation.Add)
            {

                row["id"] = booking.Id;
                row["idNumber"] = booking.IdNumber;

            }
            row["title"] = booking.Title;
            row["firstName"] = booking.FirstName;
            row["LastName"] = booking.LastName;
            row["email"] = booking.Email;
            row["telephone"] = booking.Telephone;
            row["address"] = booking.Address;
        }
        private int FindRow(Booking booking, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow row in dataSet.Tables[table].Rows)
            {
                myRow = row;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    if (booking.Id == Convert.ToString(dataSet.Tables[table].Rows[rowIndex]["id"]))
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
        public void DataSetChange(Booking booking, DB.DBOperation operation)
        {

            DataRow row = null;
            string dataTable =bookingTable;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    row = dataSet.Tables[dataTable].NewRow();
                    FillRow(row, booking, operation);
                    dataSet.Tables[dataTable].Rows.Add(row);
                    break;
                case DB.DBOperation.Edit:
                    row = dataSet.Tables[dataTable].Rows[FindRow(booking, dataTable)];
                    FillRow(row, booking, operation);
                    break;
                case DB.DBOperation.Delete:
                    int rowIndexToDelete = FindRow(booking, dataTable);
                    if (rowIndexToDelete != -1)
                    {
                        dataSet.Tables[dataTable].Rows.RemoveAt(rowIndexToDelete);
                    }
                    break;

            }
        }

        #endregion
        #region build parameters, create commands and update database
        private void insert(Booking booking)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@id", SqlDbType.Int, 50, "id");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@roomId", SqlDbType.NChar, 13, "roomId");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@bookingStatusId", SqlDbType.NChar, 13, "bookingStatusId");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@arrivalDate", SqlDbType.NVarChar, 50, "arrivalDate");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@totalAmount", SqlDbType.NVarChar, 50, "totalAmount");
            dataAdapter.InsertCommand.Parameters.Add(param);


            param = new SqlParameter("@deposit", SqlDbType.NVarChar, 50, "deposit");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@numberOfGuests", SqlDbType.NVarChar, 50, "numberOfGuests");
            dataAdapter.InsertCommand.Parameters.Add(param);


            param = new SqlParameter("@specialRequest", SqlDbType.NVarChar, 50, "specialRequest");
            dataAdapter.InsertCommand.Parameters.Add(param);

        }


            private void update(Guest guest)
        {
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@originalId", SqlDbType.Int, 50, "id");
            param.SourceVersion = DataRowVersion.Original;
            dataAdapter.UpdateCommand.Parameters.Add(param);


            param = new SqlParameter("@roomId", SqlDbType.NChar, 13, "roomId");
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@bookingStatusId", SqlDbType.NChar, 13, "bookingStatusId");
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@arrivalDate", SqlDbType.NVarChar, 50, "arrivalDate");
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@totalAmount", SqlDbType.NVarChar, 50, "totalAmount");
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param); ;


            param = new SqlParameter("@deposit", SqlDbType.NVarChar, 50, "deposit");
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@numberOfGuests", SqlDbType.NVarChar, 50, "numberOfGuests");
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);


            param = new SqlParameter("@specialRequest", SqlDbType.NVarChar, 50, "specialRequest");
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);
        }

        private void Insert(Booking booking)
        {
            dataAdapter.InsertCommand = new SqlCommand(
                "INSERT INTO booking(roomId, guestId, bookingStatusId, arrivalDate, totalAmount, deposit, numberOfGuest, specialRequest) values(@roomId, @guestId, @bookingStatusId, @arrivalDate, @totalAmount, @deposit, @numberOfGuest, @specialRequest)"
                );

            insert(booking);
        }

        public bool UpdateDataSource(Booking booking)
        {
            bool sucess = true;
            insert(booking);
            update(booking);


            UpdateDataSource(sqlLocal1, bookingTable);

            return sucess;
        }
        #endregion
        #region getters and setters
        public Collection<Booking> AllBookings
        {
            get
            {
                return bookings;
            }
        }
     


        #endregion

    }
}
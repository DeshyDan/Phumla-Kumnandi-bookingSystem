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
    public class BookingDB : DB
    {

        #region data members
        private string bookingTable = "bookings";
        private string sqlLocal1 = "SELECT * FROM bookings";
        private Collection<Booking> bookings;
        #endregion

        #region constructor 
        public BookingDB() : base()
        {
            bookings = new Collection<Booking>();
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
            foreach (DataRow row in dataSet.Tables[table].Rows)
            {
                myRow = row;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    booking = new Booking();
                    booking.Id = Convert.ToInt32(myRow["id"]);
                    booking.RoomId = Convert.ToInt32(myRow["roomId"]);
                    booking.BookingStatusId = Convert.ToInt32(myRow["bookingStatusId"]);
                    booking.CheckInDate = Convert.ToDateTime(myRow["checkInlDate"]);
                    booking.CheckOutDate = Convert.ToDateTime(myRow["checkOutDate"]);
                    booking.TotalAmount = Convert.ToInt32(myRow["totalAmount"]);
                    booking.Deposit = Convert.ToInt32(myRow["deposit"]);
                    booking.NumberOfGuests = Convert.ToInt32(myRow["numberOfGuest"]);
                    booking.SpecialRequest = Convert.ToString(myRow["specialRequest"]).TrimEnd();
                    bookings.Add(booking);
                }

            }

        }

        private void FillRow(DataRow row, Booking booking, DB.DBOperation operation)
        {
            if (operation == DB.DBOperation.Add)
            {

                row["id"] = booking.Id;


            }
            row["checkInDate"] = booking.CheckInDate;
            row["checkOutDate"] = booking.CheckOutDate;
            row["bookingStatusId"] = booking.BookingStatusId;
            row["roomId"] = booking.RoomId;
            row["deposit"] = booking.Deposit;
            row["specialRequest"] = booking.SpecialRequest;
            row["numberOfGuest"] = booking.NumberOfGuests;
            row["totalAmount"] = booking.TotalAmount;


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
                    if (booking.Id == Convert.ToInt32(dataSet.Tables[table].Rows[rowIndex]["id"]))
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
            string dataTable = bookingTable;

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

        private void Create_INSERT_Parameters(Booking booking)
        {
            dataAdapter.InsertCommand = new SqlCommand(
                "INSERT INTO bookings (roomId, bookingStatusId, checkInDate, checkOutDate, numberOfGuest, deposit , totalAmount) values (@roomId, @bookingStatusId, @checkInDate, @checkOutDate, @numberOfGuest, @deposit , @totalAmount)"
                );

            Build_INSERT_Parameters(booking);
        }
        private void Build_INSERT_Parameters(Guest guest)
        {
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@idNumber", SqlDbType.NChar, 13, "idNumber");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@title", SqlDbType.NChar, 5, "title");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@firstName", SqlDbType.NVarChar, 50, "firstName");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@lastName", SqlDbType.NVarChar, 50, "lastName");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@email", SqlDbType.NVarChar, 255, "email");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@telephone", SqlDbType.NChar, 10, "telephone");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@address", SqlDbType.NVarChar, 255, "address");
            dataAdapter.InsertCommand.Parameters.Add(param);
        }

        private void Create_UPDATE_Parameters(Guest guest)
        {
            dataAdapter.UpdateCommand = new SqlCommand("UPDATE guests SET idNumber = @idNumber, firstName = @firstName, lastName = @lastName , email = @email, telephone = @telephone, address = @address WHERE id = @originalId", connection);

            Build_UPDATE_Parameters(guest);
        }
        private void Build_UPDATE_Parameters(Guest guest)
        {
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@originalId", SqlDbType.Int, 50, "id");
            param.SourceVersion = DataRowVersion.Original;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@idNumber", SqlDbType.NChar, 13, "idNumber");
            param.SourceVersion = DataRowVersion.Original;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@title", SqlDbType.NChar, 5, "title");
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@firstName", SqlDbType.NVarChar, 50, "firstName");
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@lastName", SqlDbType.NVarChar, 50, "lastName");
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@email", SqlDbType.NVarChar, 255, "email");
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@telephone", SqlDbType.NChar, 10, "telephone");
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@address", SqlDbType.NVarChar, 255, "address");
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);
        }



        public bool UpdateDataSource(Guest guest)
        {
            bool sucess = true;
            Create_INSERT_Parameters(guest);
            Create_UPDATE_Parameters(guest);

            UpdateDataSource(sqlLocal1, guestTable);

            return sucess;
        }
        #endregion
        #region getters and setters
        public Collection<BookingController> AllBookings
        {
            get
            {
                return bookings;
            }
        }



        #endregion

    }
}
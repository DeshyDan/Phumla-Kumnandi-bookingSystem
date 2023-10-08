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
                    booking.GuestId = Convert.ToString(myRow["guestId"]);
                    booking.NumberOfRooms = Convert.ToInt32(myRow["numberOfRooms"]);
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
            row["guestId"] = booking.GuestId;
            row["checkOutDate"] = booking.CheckOutDate;
            row["bookingStatusId"] = booking.BookingStatusId;
            row["numberOfRooms"] = booking.NumberOfRooms;
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
                "INSERT INTO bookings (id,numberOfRooms,guestId, bookingStatusId, checkInDate, checkOutDate, numberOfGuests, deposit , totalAmount, specialRequest) values (@id , @numberOfRooms,@guestId ,  @bookingStatusId, @checkInDate, @checkOutDate, @numberOfGuests, @deposit , @totalAmount, specialRequest)"
                );

            Build_INSERT_Parameters(booking);
        }
        private void Build_INSERT_Parameters(Booking booking)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@id", SqlDbType.NVarChar, 25);
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@numberOfRooms", SqlDbType.Int);
            param.Value = booking.NumberOfRooms;
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@guestId", SqlDbType.Int);
            param.Value = booking.GuestId;
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@bookingStatusId", SqlDbType.Int);
            param.Value = booking.BookingStatusId;
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@checkInDate", SqlDbType.DateTime);
            param.Value = booking.CheckInDate;
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@checkOutDate", SqlDbType.DateTime);
            param.Value = booking.CheckOutDate;
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@numberOfGuests", SqlDbType.Int);
            param.Value = booking.NumberOfGuests;
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@deposit", SqlDbType.Int);
            param.Value = booking.Deposit;
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@totalAmount", SqlDbType.Int);
            param.Value = booking.TotalAmount;
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@specialRequest", SqlDbType.NVarChar, 256);
            dataAdapter.InsertCommand.Parameters.Add(param);

        }

        private void Create_UPDATE_Parameters(Booking booking)
        {
            dataAdapter.UpdateCommand = new SqlCommand("UPDATE bookings SET numberOfRooms = @numberOfRooms, guestId = @guestId, bookigStatusId = @bookingStatusId, checkInDate = @checkInDate, checkInDate = @checkOutDate,numberOfGuests = @numberOfGuests, deposit = @deposit , totalAmount = @totalAmount , specialRequest = @specialRequest WHERE id = @originalId ", connection);

            Build_UPDATE_Parameters(booking);
        }
        private void Build_UPDATE_Parameters(Booking booking)
        {

            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@originalId", SqlDbType.NVarChar,25 ,"id" );
            param.SourceVersion = DataRowVersion.Original;
            dataAdapter.UpdateCommand.Parameters.Add(param);


            param = new SqlParameter("@numberOfRooms", SqlDbType.Int);
            param.Value = booking.NumberOfRooms;
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@guestId", SqlDbType.Int);
            param.Value = booking.GuestId;
            param.SourceVersion = DataRowVersion.Original;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@bookingStatusId", SqlDbType.Int);
            param.Value = booking.BookingStatusId;
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@checkInDate", SqlDbType.DateTime);
            param.Value = booking.CheckInDate;
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@checkOutDate", SqlDbType.DateTime);
            param.Value = booking.CheckOutDate;
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@numberOfGuests", SqlDbType.Int);
            param.Value = booking.NumberOfGuests;
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@deposit", SqlDbType.Int);
            param.Value = booking.Deposit;
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@totalAmount", SqlDbType.Int);
            param.Value = booking.TotalAmount;
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@specialRequest", SqlDbType.NVarChar, 256);
            param.SourceVersion = DataRowVersion.Current;
            dataAdapter.UpdateCommand.Parameters.Add(param);


        }

        private void Create_DELETE_Parameters(Booking booking)
        {
            dataAdapter.DeleteCommand = new SqlCommand("DELETE from bookings WHERE id = @id", connection);
            Build_DELETE_Parameters(booking);

        }
        private void Build_DELETE_Parameters(Booking booking)
        {

            dataAdapter.DeleteCommand.Parameters.AddWithValue("@id", booking.Id);
        }




        public bool UpdateDataSource(Booking booking)
        {
            bool sucess = true;
            Create_INSERT_Parameters(booking);
            Create_UPDATE_Parameters(booking);
            Create_DELETE_Parameters(booking);

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
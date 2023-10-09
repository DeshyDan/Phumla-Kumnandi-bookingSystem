using Phumla_Kumnandi_Hotel_Reservation_System.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Data
{



    public class DB
    {
        #region Enum 
        public enum DBOperation
        {
            Add,
            Edit,
            Delete
        }

        #endregion 
        #region instance variables 

        private string connString = Settings.Default.bookingSystemConnectionStringTest;
        protected SqlConnection connection;
        protected DataSet dataSet;
        protected SqlDataAdapter dataAdapter;

        #endregion

        #region constructor
        public DB()
        {
            try
            {
                connection = new SqlConnection(connString);
                dataSet = new DataSet();
            }
            catch (SystemException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Error");
                return;
            }
        }

        #endregion


        #region updating the dataSet
        public void FillDataSet(string sqlString, string tableName)
        {
            // fills the dataset with new data from the database for a specific table with a query
            try
            {
                dataAdapter = new SqlDataAdapter(sqlString, connection);
                connection.Open();
                dataAdapter.Fill(dataSet, tableName);
                connection.Close();
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
            }
        }

        #endregion

        #region updating the data source
        protected bool UpdateDataSource(string sqlLocal, string tableName)
        {
            bool success;

            try
            {
                connection.Open();
                dataAdapter.Update(dataSet, tableName);
                connection.Close();

                FillDataSet(sqlLocal, tableName);
                success = true;
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
                success = false;
            }
            finally
            {
            }
            return success;

        }



        #endregion
    }


}

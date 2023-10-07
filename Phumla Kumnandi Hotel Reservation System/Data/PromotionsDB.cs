using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phumla_Kumnandi_Hotel_Reservation_System.Business;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Data
{
    public class PromotionsDB:DB
    {

        #region instance variables 
        private string promotionsTable = "promotions";
        private string sqlLocal1 = "SELECT * FROM promotions";
        private Collection<Promotion> promotions;

        #endregion


        #region constructor
        public PromotionsDB() : base()
        {
            promotions = new Collection<Promotion>();
            FillDataSet(sqlLocal1, promotionsTable);
            AddToCollection(promotionsTable);
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
            Promotion promotion;

            foreach (DataRow row in dataSet.Tables[table].Rows)
            {
                myRow = row;

                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    promotion = new Promotion();
                    promotion.Id = Convert.ToString(myRow["id"]).TrimEnd();
                    promotion.name = Convert.ToString(myRow["name"]).TrimEnd();
                    promotion.discount = Convert.ToDecimal(myRow["discount"]);
                   
                    this.promotions.Add(promotion);

                }
            }
        }

        private void FillRow(DataRow row, Promotion promotion, DB.DBOperation operation)
        {
            if (operation == DB.DBOperation.Add)
            {

                row["id"] = promotion.Id;
              

            }
            row["name"] = promotion.Name;
            row["dicount"] = promotion.Discount;
          
        }
        private int FindRow(Promotion promotion, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow row in dataSet.Tables[table].Rows)
            {
                myRow = row;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    if (promotion.Id == Convert.ToString(dataSet.Tables[table].Rows[rowIndex]["id"]))
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
        public void DataSetChange(Promotion promotion, DB.DBOperation operation)
        {

            DataRow row = null;
            string dataTable = promotionsTable;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    row = dataSet.Tables[dataTable].NewRow();
                    FillRow(row, promotion, operation);
                    dataSet.Tables[dataTable].Rows.Add(row);
                    break;
                case DB.DBOperation.Edit:
                    row = dataSet.Tables[dataTable].Rows[FindRow(promotion, dataTable)];
                    FillRow(row, promotion, operation);
                    break;
                case DB.DBOperation.Delete:
                    int rowIndexToDelete = FindRow(promotion, dataTable);
                    if (rowIndexToDelete != -1)
                    {
                        dataSet.Tables[dataTable].Rows.RemoveAt(rowIndexToDelete);
                    }
                    break;

            }
        }

        #endregion

        #region build parameters, create commands and update database
        private void insert(Promotion promotion)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@id", SqlDbType.Int, 50, "id");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@name", SqlDbType.NChar, 13, "name");
            dataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@discount", SqlDbType.NChar, 13, "discount");
            dataAdapter.InsertCommand.Parameters.Add(param);

            
        }


        private void update(Promotion promotion)
        {
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@originalId", SqlDbType.Int, 50, "id");
            param.SourceVersion = DataRowVersion.Original;
            dataAdapter.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@originalIdNumber", SqlDbType.NChar, 13, "idNumber");
            param.SourceVersion = DataRowVersion.Original;
            dataAdapter.UpdateCommand.Parameters.Add(param);

           
        }

        private void Insert(Promotion promotion)
        {
            dataAdapter.InsertCommand = new SqlCommand(
                "INSERT INTO promotions (name, discount) values(@name , @discount" );

            insert(promotion);
        }

        public bool UpdateDataSource(Promotion promotion, DB.DBOperation operation)
        {
            bool sucess = true;
            insert(promotion);
            update(promotion);


            UpdateDataSource(sqlLocal1, promotionsTable);

            return sucess;
        }
        #endregion


        #region getters and setters
        public Collection<Promotion> AllPromotions
        {
            get
            {
                return promotions;
            }
        }
        #endregion
    }
}

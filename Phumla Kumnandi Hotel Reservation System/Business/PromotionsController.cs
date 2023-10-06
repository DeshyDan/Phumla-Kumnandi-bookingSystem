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
        public class PromotionsController
        {
            #region Data Members
            PromotionsDB promotionsDB;
            Collection<Promotion> promotions;
            #endregion
            #region properties
            public Collection<Promotion> AllPromotions
            {
                get { return promotions; }

            }
            #endregion
            #region Constructor
            public PromotionsController()
            {
                promotionsDB = new PromotionsDB();
                promotions = promotionsDB.AllPromotions;


            }
            #endregion
            #region Database Communication
            public void DataMaintenance(Promotion aPromotions, DB.DBOperation operation)
            {
                Debug.WriteLine("Inside DataMaintence");
                int index = 0;
                promotionsDB.GetDataSet();

                switch (operation)
                {
                    case DB.DBOperation.Add:
                        Debug.WriteLine("operation is Added");
                        promotions.Add(aPromotions);
                        break;
                    case DB.DBOperation.Edit:
                        index = FindIndex(aPromotions);
                        promotions[index] = aPromotions;
                        break;
                    case DB.DBOperation.Delete:
                        index = FindIndex(aPromotions);
                        promotions[index] = aPromotions;
                        break;

                }
            }
            #endregion
            #region     Database Commuincation
            public void DataMaintenacne(Promotion aPromotion, DB.DBOperation operation)
            {
                Debug.WriteLine("Inside Data Maintenance");
                int index = 0;
                promotionsDB.DataSetChange(aPromotion, operation);

                switch (operation)
                {
                    case DB.DBOperation.Add:
                        Debug.WriteLine("operation is added");
                        promotions.Add(aPromotion);
                        break;
                   
               

                }
            }
            public bool FinalizeChanges(Promotion promotion, DB.DBOperation operation)
            {
                Debug.WriteLine("Inside FinalizeChange");
                return promotionsDB.UpdateDataSource(promotion, operation);

            }
            #endregion
            #region Searching through a collection
      
            public Promotion Find(string ID)
            {
                int index = 0;
                bool found = (promotions[index].ID.Equals(ID));
                int count = promotions.Count;
                while (!(found) && (index < promotions.Count - 1))
                {
                    index = index + 1;
                    found = (promotions[index].Id.Equals(ID));
                }
                return promotions[index];

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
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Business
{
    public class RoomAccount
    {
        #region Data Members
        public decimal TotalAmountDue;
        public decimal AmountPaid;
        public StatusEnum Status;
        public enum StatusEnum
        {
            OutStanding=0,
            Paid=1
        }
        #endregion
        #region Constructor
        public RoomAccount(decimal totalAmountDue, decimal amountPaid, StatusEnum status_)
        {
            this.TotalAmountDue = totalAmountDue;
            this.AmountPaid = amountPaid;
            this.Status= status_;
        }
        #endregion
        #region Utility Methods
        public decimal totalAmountDue
        {
            get { return TotalAmountDue; }
            set { TotalAmountDue = value; }
        }
        public decimal totalAmountOaid
        {
            get { return AmountPaid; }
            set { AmountPaid = value; }
        }
        public StatusEnum GetStatus()
        {
            return Status;
        }
        public void SetStatus(StatusEnum newStatus)
        {
            Status = newStatus;
        }
        public decimal CalculateAmountDue()
        {
            return TotalAmountDue-AmountPaid;
        }
        #endregion

    }
}

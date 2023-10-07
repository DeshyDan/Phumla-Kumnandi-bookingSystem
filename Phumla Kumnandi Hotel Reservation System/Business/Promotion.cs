using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Business
{
    public class Promotion
    {

        public enum Season
        {
            LowSeason,
            MidSeason,
            HighSeason


        }
        Collection<Booking> LowSeason;
        Collection<Booking> MidSeason;
        Collection<Booking> HighSeason;

        Season season;

        public Promotion() { }
        public decimal TotalAmount(DateTime checkin)
        {
            decimal amount = 0;
            DateTime lowCheckin = new DateTime(2023, 01, 01);
            DateTime midCheckin = new DateTime(2023, 06, 01);
            DateTime highCheckin = new DateTime(2023, 11, 01);

            if (checkin.Date < midCheckin.Date)
            {
                amount = 670;
            }
            else if ((checkin.Date >= midCheckin.Date) && (checkin.Date <= highCheckin.Date))
            {
                amount = 890;

            }
            else if (checkin.Date >= highCheckin.Date)
            {
                amount = 1250;
            }
            return amount;
        }
    }
}

    

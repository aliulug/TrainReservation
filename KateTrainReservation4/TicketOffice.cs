using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataTrainReservation
{
    public class TicketOffice
    {

        public Reservation MakeReservation(ReservationRequest request)
        {
            //TODO: implement this code!

            if (request.TrainId == "real train")
            {
                return new Reservation(request.TrainId, "booking id", new List<Seat>());
            }

            return null;
            
            throw new NotImplementedException();
        }
    }
}
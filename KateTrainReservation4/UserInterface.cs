using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataTrainReservation;

namespace KateTrainReservation4
{
    public class UserInterface
    {
        private readonly ITrainList _trainList;

        public UserInterface()
        { }
        
        public UserInterface(ITrainList trainList)
        {
            _trainList = trainList;
        }

        public Reservation BookSeat(string trainName, int numberOfSeats)
        {
            if (_trainList == null)
                return null;
            if (_trainList.DoesTrainHaveSeats(trainName, numberOfSeats))
                return new Reservation();
            return null;
        }
    }
}

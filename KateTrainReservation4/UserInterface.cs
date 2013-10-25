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
//        private readonly ITrainList _trainList;
        private readonly List<TrainForBooking> _trains = new List<TrainForBooking>(); 

        public UserInterface()
        { }
        
        //public UserInterface(ITrainList trainList)
        //{
        //    _trainList = trainList;
        //}

        public bool BookSeat(string trainName, int numberOfSeats)
        {
            //if (_trainList == null)
            //    return null;

            //if (_trainList.DoesTrainHaveSeats(trainName, numberOfSeats))
            //    return new Reservation();
            var train = getTrainWithName(trainName);
            if (train == null)
                return false;
            return train.BookSeats(numberOfSeats);
        }

        private TrainForBooking getTrainWithName(string trainName)
        {
            return _trains.FirstOrDefault(trainForBooking => trainForBooking.TrainName == trainName);
        }

        public void AddTrain(TrainForBooking train)
        {
            _trains.Add(train);
        }
    }
}

using KateTrainReservation4;
using NMock2;
using NUnit.Framework;
using Is = NUnit.Framework.Is;

namespace KataTrainReservation
{
    [TestFixture]
    public class TicketOfficeNUnitTest
    {
        [Test]
        public void TestThat_BookingASeatOnATrainThatDoesNotExistShouldNotWork()
        {
            var userInterface = new UserInterface();
            
            var reservation = userInterface.BookSeat("fake train", 1);

            Assert.That(reservation, Is.False);
        }

        [Test]
        public void TestThat_BookingASeatOnAnExistingTrainReturnsARealReservation()
        {
            var userInterface = new UserInterface();
            var trainForBooking = new TrainForBooking("real train");
            trainForBooking.AddCoach(new TrainCoach(10));
            userInterface.AddTrain(trainForBooking);

            var reservation = userInterface.BookSeat("real train", 1);

            Assert.That(reservation, Is.True);
        }

        [Test]
        public void TestThat_BookingASeatOnAnExistingFullTrainShouldNotWork()
        {
            var mockery = new Mockery();
            var trainList = mockery.NewMock<ITrainList>();
            var userInterface = new UserInterface();

            Stub.On(trainList).Method("DoesTrainHaveSeats").With("real full train", 2).Will(Return.Value(false));

            var reservation = userInterface.BookSeat("real full train", 2);

            Assert.That(reservation, Is.False);
        }

        [Test]
        public void TestThat_BookingASeatOnAnExistingEmptyTrainReturnsARealReservation()
        {
            var userInterface = new UserInterface();
            var trainForBooking = new TrainForBooking("real train");
            trainForBooking.AddCoach(new TrainCoach(10));
            userInterface.AddTrain(trainForBooking);

            var reservation = userInterface.BookSeat("real train", 2);

            Assert.That(reservation, Is.True);
        }

        [Test]
        public void TestThat_BookingSeatsOnATrainWithOneCouchAndTenSeatsDoesNotWorkWhenMoreThan70PercentRequested()
        {
            var userInterface = new UserInterface();
            var trainCoach = new TrainCoach(10);
            var train = new TrainForBooking("train 1");
            train.AddCoach(trainCoach);

            userInterface.AddTrain(train);
            var reservation = userInterface.BookSeat("train 1", 8);

            Assert.That(reservation, Is.False);
        }
    }
}
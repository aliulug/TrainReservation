using KateTrainReservation4;
using NMock2;
using NUnit.Framework;
using Is = NUnit.Framework.Is;

namespace KataTrainReservation
{
    [TestFixture]
    public class TicketOfficeNUnitTest
    {

        //[Test]
        //public void TestThat_BookingASeatOnATrainThatDoesNotExistReturnsNull()
        //{
        //    // TODO: write this code
        //    var ticketOffice = new TicketOffice();
        //    var reservation = ticketOffice.MakeReservation(new ReservationRequest("fake train", 1));

        //    Assert.That(reservation, Is.Null);
        //}

        //[Test]
        //public void TestThat_BookingASeatOnAnExistingTrainReturnsARealReservation()
        //{
        //    var ticketOffice = new TicketOffice();
        //    var reservation = ticketOffice.MakeReservation(new ReservationRequest("real train", 1));

        //    Assert.That(reservation, Is.Not.Null);
        //}

        [Test]
        public void TestThat_BookingASeatOnATrainThatDoesNotExistReturnsNull2()
        {
            var userInterface = new UserInterface();

            Reservation reservation = userInterface.BookSeat("fake train", 1);

            Assert.That(reservation, Is.Null);
        }

        [Test]
        public void TestThat_BookingASeatOnAnExistingTrainReturnsARealReservation()
        {
            var userInterface = new UserInterface();

            Reservation reservation = userInterface.BookSeat("real train", 1);

            Assert.That(reservation, Is.Not.Null);
        }

        [Test]
        public void TestThat_BookingASeatOnAnExistingFullTrainReturnsNull()
        {
            Mockery mockery = new Mockery();
            ITrainList trainList = mockery.NewMock<ITrainList>();
            var userInterface = new UserInterface(trainList);

            //userInterface.AddTrain("real train", 0);

            Stub.On(trainList).Method("DoesTrainHaveSeats").With("real full train", 2).Will(Return.Value(false));


            Reservation reservation = userInterface.BookSeat("real full train", 2);

            Assert.That(reservation, Is.Null);
        }
    }

    public interface ITrainList
    {
        bool DoesTrainHaveSeats(string trainName, int numberOfSeats);
    }
}
using Business_Layer.Services;
using Data_Access_Layer.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using AirportTests.Modules;

namespace AirportTests
{
    [TestFixture]
    class DbTests
    {
        AirportService _airportService;

        public DbTests()
        {
            var kernel = new StandardKernel(new AirPortServiceModule());

            _airportService = kernel.Get<AirportService>();
        }

        [Test]
        public void CreateGetPilot_when_create_pilot_then_get_pilot_correct()
        {
            Pilot pilot = new Pilot() { Name = "name", Surname = "surname", Experience = 5 };

            _airportService.Post(pilot);
            _airportService.SaveChanges();
            var newPilot = _airportService.GetAll<Pilot>().Last();

            Assert.AreEqual(pilot.Name, newPilot.Name);
            Assert.AreEqual(pilot.Surname, newPilot.Surname);
            Assert.AreEqual(pilot.Experience, newPilot.Experience);
        }

        [Test]
        public void UpdatePilot_when_update_pilot_then_get_pilot_correct()
        {
            Pilot pilot = _airportService.GetAll<Pilot>().Last();

            pilot.Surname = "updated";

            _airportService.SaveChanges();

            var newPilot = _airportService.GetAll<Pilot>().FirstOrDefault(p => p.Surname == "updated");

            Assert.False(newPilot == null);
        }

        [Test]
        public void DeletePilot_when_delete_pilot_then_get_null()
        {
            var newPilot = _airportService.GetAll<Pilot>().Last();

            Assert.False(newPilot == null);

            _airportService.Delete<Pilot>(newPilot.Id);
            _airportService.SaveChanges();


            var deletedPilot = _airportService.GetById<Pilot>(newPilot.Id);

            Assert.True(deletedPilot == null);

            _airportService.Post(new Pilot()
            {
                Name = newPilot.Name,
                Surname = newPilot.Surname,
                Experience = newPilot.Experience
            });

            _airportService.SaveChanges();

        }

        [Test]
        public void CreateGetFlight_when_create_flight_then_get_flight_correct()
        {
            Flight flight = new Flight()
            {
                ArrivalTime = new DateTime(2015, 10, 10),
                DepartureFrom = "TestDep",
                Destination = "TestDest",
                TimeOfDeparture = new DateTime(2015,10,9),
            };

            _airportService.Post(flight);
            _airportService.SaveChanges();
            var newFlight = _airportService.GetAll<Flight>().Last();

            Assert.AreEqual(flight.ArrivalTime, newFlight.ArrivalTime);
            Assert.AreEqual(flight.DepartureFrom, newFlight.DepartureFrom);
            Assert.AreEqual(flight.Destination, newFlight.Destination);
        }

        [Test]
        public void UpdateFlight_when_update_flight_then_get_flight_correct()
        {
            Flight flight = _airportService.GetAll<Flight>().Last();

            flight.DepartureFrom = "updated";

            _airportService.SaveChanges();

            var newFlight = _airportService.GetAll<Flight>().FirstOrDefault(p => p.DepartureFrom == "updated");

            Assert.False(newFlight == null);
        }

        [Test]
        public void DeleteFlight_when_delete_flight_then_get_null()
        {
            var newFlight = _airportService.GetAll<Flight>().Last();

            Assert.False(newFlight == null);

            _airportService.Delete<Flight>(newFlight.Number);
            _airportService.SaveChanges();


            var deletedFlight = _airportService.GetById<Flight>(newFlight.Number);

            Assert.True(deletedFlight == null);

            _airportService.Post(new Flight()
            {
                ArrivalTime = newFlight.ArrivalTime,
                DepartureFrom = newFlight.Destination,
                Destination = newFlight.Destination,
                TimeOfDeparture = newFlight.TimeOfDeparture
            });

            _airportService.SaveChanges();
        }

        [Test]
        public void GetCorrectTickets_when_add_tickets_then_get_correct_tickets_in_flights()
        {
            Flight flight = new Flight()
            {
                ArrivalTime = new DateTime(2015, 10, 10),
                DepartureFrom = "TestDep2",
                Destination = "TestDest2",
                TimeOfDeparture = new DateTime(2015, 10, 9),
            };

            _airportService.Post(flight);

            _airportService.SaveChanges();

            List<Ticket> tickets = new List<Ticket>()
            {
                new Ticket(){Price = 250, FlightNumber = _airportService.GetAll<Flight>().Last().Number},
                new Ticket(){Price = 350, FlightNumber = _airportService.GetAll<Flight>().Last().Number}
            };

            _airportService.Post(tickets[0]);
            _airportService.Post(tickets[1]);

            _airportService.SaveChanges();

            Assert.AreEqual(_airportService.GetAll<Flight>().Last().Tickets.Count(), 2);
        }
        [Test]
        public void GetCorrectStewardesses_when_add_stewardesses_then_get_correct_stewardesses_in_crews()
        {
            Crew Crew = new Crew()
            {
                Pilot = new Pilot() { Name = "name", Surname = "sur" }
            };

            _airportService.Post(Crew);

            _airportService.SaveChanges();

            List<Stewardess> stewardesses = new List<Stewardess>()
            {
                new Stewardess(){Name = "nameSt", Surname = "surSt", CrewId = _airportService.GetAll<Crew>().Last().Id},
                new Stewardess(){Name = "nameSt2", Surname = "surSt2", CrewId = _airportService.GetAll<Crew>().Last().Id}
            };

            _airportService.Post(stewardesses[0]);
            _airportService.Post(stewardesses[1]);

            _airportService.SaveChanges();

            Assert.AreEqual(_airportService.GetAll<Crew>().Last().Stewardesses.Count(), 2);
        }

        [Test]
        public void CreateGetStewardess_when_create_stewardess_then_get_stewardess_correct()
        {
            Stewardess stewardess = new Stewardess() { Name = "name", Surname = "surname", CrewId = _airportService.GetAll<Crew>().First().Id };

            _airportService.Post(stewardess);
            _airportService.SaveChanges();
            var newStewardess = _airportService.GetAll<Stewardess>().Last();

            Assert.AreEqual(stewardess.Name, newStewardess.Name);
            Assert.AreEqual(stewardess.Surname, stewardess.Surname);
        }

        [Test]
        public void DeletePlaneType_when_delete_PlaneType_then_get_null()
        {
            var planeType = _airportService.GetAll<PlaneType>().Last();

            Assert.False(planeType == null);

            _airportService.Delete<PlaneType>(planeType.Id);
            _airportService.SaveChanges();


            var deletedPlaneType = _airportService.GetById<PlaneType>(planeType.Id);

            Assert.True(deletedPlaneType == null);

            _airportService.Post(new PlaneType()
            {
                NumberOfSeats = planeType.NumberOfSeats,
                LoadCapacity = planeType.LoadCapacity,
                Model = planeType.Model
            });

            _airportService.SaveChanges();
        }
    }

}
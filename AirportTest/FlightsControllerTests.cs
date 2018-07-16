using AirportTests.Modules;
using Business_Layer.MyMapperConfiguration;
using Business_Layer.Services;
using Ninject;
using NUnit.Framework;
using Presentation_Layer.Controllers;
using Shared.DTOs;
using System;
using System.Net;
using System.Net.Http;

namespace AirportTests
{
    [TestFixture]
    class FlightsControllerTests
    {
        FlightsController _controller;
        public FlightsControllerTests()
        {
            var kernel = new StandardKernel(new AirPortServiceModule());
            var mapper = MyMapperConfiguration.GetConfiguration().CreateMapper();
            _controller = new FlightsController(mapper, kernel.Get<AirportService>());
        }

        [Test]
        public void PostFlightTestGoodResult_when_post_correct_then_HttpOK()
        {
            FlightDTO flight = new FlightDTO()
            {
                ArrivalTime = new DateTime(2018, 10, 10),
                DepartureFrom = "City",
                Destination = "City2",
                TimeOfDeparture = new DateTime(2018, 10, 10)
            };

            Assert.AreEqual(new HttpResponseMessage(HttpStatusCode.OK).StatusCode,
                _controller.Post(flight).StatusCode);
        }

        [Test]
        public void PostFlightTestBadResult_when_post_Bad_then_HttpBAD()
        {
            FlightDTO flight = new FlightDTO()
            {
                DepartureFrom = "",
                Destination = "City2",
                TimeOfDeparture = new DateTime(2018, 10, 10)
            };

            Assert.AreEqual(new HttpResponseMessage(HttpStatusCode.BadRequest).StatusCode, 
                _controller.Post(flight).StatusCode);
        }
    }
}

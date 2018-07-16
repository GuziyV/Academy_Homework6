using System;
using System.Collections.Generic;
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
    class PilotsControllerTests
    {
        PilotsController _controller;
        public PilotsControllerTests()
        {
            var kernel = new StandardKernel(new AirPortServiceModule());
            var mapper = MyMapperConfiguration.GetConfiguration().CreateMapper();
            _controller = new PilotsController(mapper, kernel.Get<AirportService>());
        }

        [Test]
        public void PostPilotTestGoodResult_when_post_correct_then_HttpOK()
        {
            PilotDTO flight = new PilotDTO()
            {
                Name = "Name", Experience = 2, Surname = "Surname"
            };

            Assert.AreEqual(new HttpResponseMessage(HttpStatusCode.OK).StatusCode,
                _controller.Post(flight).StatusCode);
        }

        [Test]
        public void PostPilotTestBadResult_when_post_Bad_then_HttpBAD()
        {
            PilotDTO pilot = new PilotDTO()
            {
                Name = "Name2",
                Experience = 2,
                Surname = ""
            };


            Assert.AreEqual(new HttpResponseMessage(HttpStatusCode.BadRequest).StatusCode,
                _controller.Post(pilot).StatusCode);
        }
    }
}

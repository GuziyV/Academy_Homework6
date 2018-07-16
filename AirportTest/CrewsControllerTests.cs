using AirportTests.Modules;
using Business_Layer.MyMapperConfiguration;
using Business_Layer.Services;
using Ninject;
using NUnit.Framework;
using Presentation_Layer.Controllers;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace AirportTests
{
    [TestFixture]
    class CrewsControllerTests
    {
        CrewsController _controller;
        public CrewsControllerTests()
        {
            var kernel = new StandardKernel(new AirPortServiceModule());
            var mapper = MyMapperConfiguration.GetConfiguration().CreateMapper();
            _controller = new CrewsController(mapper, kernel.Get<AirportService>());
        }

        [Test]
        public void PostCrewTestGoodResult_when_post_correct_then_HttpOK()
        {
            CrewDTO crew = new CrewDTO()
            {
                Pilot = new PilotDTO() { Name = "Name", Experience = 5, Surname = "Sur"},
                Stewardesses = new List<StewardessDTO>()
                {
                    new StewardessDTO()
                    {
                        DateOfBirth = new DateTime(1992, 10, 9),
                        Surname = "stSur",
                        Name = "stName",
                    }
                }
            };

            Assert.AreEqual(new HttpResponseMessage(System.Net.HttpStatusCode.OK).StatusCode,
                _controller.Post(crew).StatusCode);
        }

        [Test]
        public void PostCrewTestBadResult_when_post_Bad_then_HttpBAD()
        {
            CrewDTO crew = new CrewDTO()
            {
                Pilot = new PilotDTO() { Name = "Name", Surname = "Surname", Experience = 2}
            };

            Assert.AreEqual(new HttpResponseMessage(HttpStatusCode.BadRequest).StatusCode,
                _controller.Post(crew).StatusCode);
        }
    }
}

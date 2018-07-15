using Business_Layer.Services;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportTests
{
    [TestFixture]
    class CreateUpdateTests
    {
        AirportService service;
        public CreateUpdateTests()
        {
            var unitOfWork = A.Fake<IUnitOfWork>();
            service = new AirportService(unitOfWork);
        }
        [Test]
        public void Pilot_when_create_pilot_then_get_pilot_correctly()
        {
            
        }

        [SetUp]
        public void Seed()
        {
            A.CallTo(() => service.GetAll<Pilot>()).Returns(new Pil)
        }
    }
}

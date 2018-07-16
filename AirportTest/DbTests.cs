using Business_Layer.Services;
using Data_Access_Layer;
using Data_Access_Layer.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Ninject;
using Data_Access_Layer.Interfaces;
using System.Reflection;
using AirportTests.Modules;
using Data_Access_Layer.DbInitializer;
using Microsoft.EntityFrameworkCore;
using Data_Access_Layer.Contexts;

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

            Assert.AreEqual(pilot.Id, newPilot.Id);
            Assert.AreEqual(pilot.Name, newPilot.Name);
            Assert.AreEqual(pilot.Surname, newPilot.Surname);
            Assert.AreEqual(pilot.Experience, newPilot.Experience);
        }


    }
}

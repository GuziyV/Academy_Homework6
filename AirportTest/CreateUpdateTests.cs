using AirportTests.Fakes;
using AutoMapper;
using Business_Layer.DTOValidation;
using Business_Layer.MyMapperConfiguration;
using Business_Layer.Services;
using Data_Access_Layer.Models;
using FluentValidation;
using NUnit.Framework;
using Shared.DTOs;

namespace AirportTests
{
    [TestFixture]
    public class CreateUpdateTests
    {
        AirportService _service;
        IMapper _mapper;
        public CreateUpdateTests()
        {
            _mapper = MyMapperConfiguration.GetConfiguration().CreateMapper();
            var unitOfWork = new FakeUnitOfWork();
            _service = new AirportService(unitOfWork);
        }
        [Test]
        public void ValidationMappingPilot_when_validate_pilot_OK_then_map()
        {
            var pilotDTOValidator = new PilotDTOValidator();
            PilotDTO correct = new PilotDTO() 
            {
                Id = 1,
                Surname = "Surname",
                Experience = 3,
                Name = "Name"
            };

            PilotDTO incorrect = new PilotDTO()
            {
                Id = 2
            };

            bool correctRes = pilotDTOValidator.Validate(correct).IsValid;

            Assert.True(correctRes);
            var mapped = _mapper.Map<PilotDTO, Pilot>(correct);

            if (correctRes)
            {
                _service.Post<Pilot>(mapped);
            }

            bool incorrectRes = pilotDTOValidator.Validate(incorrect).IsValid;

            Assert.False(incorrectRes);
            var mappedIncorrect = _mapper.Map<PilotDTO, Pilot>(incorrect);
            
            if(incorrectRes)
            {
                _service.Post<Pilot>(mapped);
            }
        }

        
    }
}

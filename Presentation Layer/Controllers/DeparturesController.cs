using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using AutoMapper;
using Business_Layer.Services;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace Presentation_Layer.Controllers
{
    [Produces("application/json")]
    [Route("api/Departures")]
    public class DeparturesController : Controller
    {
        private readonly AirportService _service;
        private readonly IMapper _mapper;

        public DeparturesController(IMapper mapper, AirportService service)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/departures
        [HttpGet]
        public IEnumerable<DepartureDTO> Get()
        {
            return Mapper.Map<IEnumerable<Departure>, IEnumerable<DepartureDTO>>(_service.GetAll<Departure>());
        }

        // GET api/departures/id
        [HttpGet("{id}")]
        public DepartureDTO Get(int id)
        {
            return Mapper.Map<Departure, DepartureDTO>(_service.GetById<Departure>(id));
        }

        // POST api/departures
        [HttpPost]
        public HttpResponseMessage Post([FromBody]DepartureDTO departure)
        {
            if (ModelState.IsValid && departure != null)
            {
                _service.Post<Departure>(Mapper.Map<DepartureDTO, Departure>(departure));
                _service.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // POST api/departures/id
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody]DepartureDTO departure)
        {
            if (ModelState.IsValid && departure != null)
            {
                _service.Update<Departure>(id, Mapper.Map<DepartureDTO, Departure>(departure));
                _service.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/departures/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete<Departure>(id);
            _service.SaveChanges();
        }
    }
}
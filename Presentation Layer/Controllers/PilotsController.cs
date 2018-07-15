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
    [Route("api/Pilots")]
    public class PilotsController : Controller
    {
        private readonly AirportService _service;
        private readonly IMapper _mapper;

        public PilotsController(IMapper mapper, AirportService service)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/pilots
        [HttpGet]
        public IEnumerable<PilotDTO> Get()
        {
            return Mapper.Map<IEnumerable<Pilot>, IEnumerable<PilotDTO>>(_service.GetAll<Pilot>());
        }

        // GET api/pilots/id
        [HttpGet("{id}")]
        public PilotDTO Get(int id)
        {
            return Mapper.Map<Pilot, PilotDTO>(_service.GetById<Pilot>(id));
        }

        // POST api/pilots
        [HttpPost]
        public HttpResponseMessage Post([FromBody]PilotDTO pilot)
        {
            if (ModelState.IsValid && pilot != null)
            {
                _service.Post<Pilot>(Mapper.Map<PilotDTO, Pilot>(pilot));
                _service.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // POST api/pilots/id
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody]PilotDTO pilot)
        {
            if (ModelState.IsValid && pilot != null)
            {
                _service.Update<Pilot>(id, Mapper.Map<PilotDTO, Pilot>(pilot));
                _service.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/pilots/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete<Pilot>(id);
            _service.SaveChanges();
        }
    }
}
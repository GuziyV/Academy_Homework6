using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using AutoMapper;
using Business_Layer.Services;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Shared.DTOs;

namespace Presentation_Layer.Controllers
{
    [Produces("application/json")]
    [Route("api/Crews")]
    public class CrewsController : Controller
    {
        private readonly AirportService _service;
        private readonly IMapper _mapper;

        public CrewsController(IMapper mapper, AirportService service)
        {
            _service = service;
            _mapper = mapper;       
        }

        // GET api/crews
        [HttpGet]
        public IEnumerable<CrewDTO> Get()
        {
            return Mapper.Map<IEnumerable<Crew>, IEnumerable<CrewDTO>>(_service.GetAll<Crew>());
        }

        // GET api/crews/id
        [HttpGet("{id}")]
        public CrewDTO Get(int id)
        {
            return Mapper.Map<Crew, CrewDTO>(_service.GetById<Crew>(id));
        }

        // POST api/crews
        [HttpPost]
        public HttpResponseMessage Post([FromBody]CrewDTO crew)
        {
            if(ModelState.IsValid && crew != null)
            {
                _service.Post<Crew>(Mapper.Map<CrewDTO, Crew>(crew));
                _service.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // POST api/crews/id
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody]CrewDTO crew)
        {
            if (ModelState.IsValid && crew != null)
            {
                _service.Update<Crew>(id, Mapper.Map<CrewDTO, Crew>(crew));
                _service.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/crews/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete<Crew>(id);
            _service.SaveChanges();
        }
    }
}
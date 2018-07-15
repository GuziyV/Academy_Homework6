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
    [Route("api/Stewardesses")]
    public class StewardessesController : Controller
    {
        private readonly AirportService _service;
        private readonly IMapper _mapper;

        public StewardessesController(IMapper mapper, AirportService service)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/stewardesses
        [HttpGet]
        public IEnumerable<StewardessDTO> Get()
        {
            return Mapper.Map<IEnumerable<Stewardess>, IEnumerable<StewardessDTO>>(_service.GetAll<Stewardess>());
        }

        // GET api/stewardesses/id
        [HttpGet("{id}")]
        public StewardessDTO Get(int id)
        {
            return Mapper.Map<Stewardess, StewardessDTO>(_service.GetById<Stewardess>(id));
        }

        // POST api/stewardesses
        [HttpPost]
        public HttpResponseMessage Post([FromBody]StewardessDTO stewardess)
        {
            if (ModelState.IsValid && stewardess != null)
            {
                _service.Post<Stewardess>(Mapper.Map<StewardessDTO, Stewardess>(stewardess));
                _service.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // POST api/stewardesses/id
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody]StewardessDTO stewardess)
        {
            if (ModelState.IsValid && stewardess != null)
            {
                _service.Update<Stewardess>(id, Mapper.Map<StewardessDTO, Stewardess>(stewardess));
                _service.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/stewardesses/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete<Stewardess>(id);
            _service.SaveChanges();
        }
    }
}
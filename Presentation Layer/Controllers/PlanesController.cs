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
    [Route("api/Planes")]
    public class PlanesController : Controller
    {
        private readonly AirportService _service;
        private readonly IMapper _mapper;

        public PlanesController(IMapper mapper, AirportService service)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/planes
        [HttpGet]
        public IEnumerable<PlaneDTO> Get()
        {
            return Mapper.Map<IEnumerable<Plane>, IEnumerable<PlaneDTO>>(_service.GetAll<Plane>());
        }

        // GET api/planes/id
        [HttpGet("{id}")]
        public PlaneDTO Get(int id)
        {
            return Mapper.Map<Plane, PlaneDTO>(_service.GetById<Plane>(id));
        }


        // POST api/planes
        [HttpPost]
        public HttpResponseMessage Post([FromBody]PlaneDTO plane)
        {
            if (ModelState.IsValid && plane != null)
            {
                _service.Post<Plane>(Mapper.Map<PlaneDTO, Plane>(plane));
                _service.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // POST api/planes/id
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody]PlaneDTO plane)
        {
            if (ModelState.IsValid && plane != null)
            {
                _service.Update<Plane>(id, Mapper.Map<PlaneDTO, Plane>(plane));
                _service.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/planes/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete<Plane>(id);
            _service.SaveChanges();
        }
    }
}
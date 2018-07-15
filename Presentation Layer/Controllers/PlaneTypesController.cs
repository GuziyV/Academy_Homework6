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
    [Route("api/PlaneTypes")]
    public class PlaneTypesController : Controller
    {
        private readonly AirportService _service;
        private readonly IMapper _mapper;

        public PlaneTypesController(IMapper mapper, AirportService service)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/planetypes
        [HttpGet]
        public IEnumerable<PlaneTypeDTO> Get()
        {
            return Mapper.Map<IEnumerable<PlaneType>, IEnumerable<PlaneTypeDTO>>(_service.GetAll<PlaneType>());
        }

        // GET api/planestype/id
        [HttpGet("{id}")]
        public PlaneTypeDTO Get(int id)
        {
            return Mapper.Map<PlaneType, PlaneTypeDTO>(_service.GetById<PlaneType>(id));
        }

        // POST api/planetypes
        [HttpPost]
        public HttpResponseMessage Post([FromBody]PlaneTypeDTO planeType)
        {
            if (ModelState.IsValid && planeType != null)
            {
                _service.Post<PlaneType>(Mapper.Map<PlaneTypeDTO, PlaneType>(planeType));
                _service.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // POST api/planettypes/id
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody]PlaneTypeDTO planeType)
        {
            if (ModelState.IsValid && planeType != null)
            {
                _service.Update<PlaneType>(id, Mapper.Map<PlaneTypeDTO, PlaneType>(planeType));
                _service.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/planettypes/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete<PlaneType>(id);
            _service.SaveChanges();
        }
    }
}
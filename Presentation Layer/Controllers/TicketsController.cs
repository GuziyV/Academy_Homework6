﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using AutoMapper;
using Business_Layer.DTOValidation;
using Business_Layer.Services;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace Presentation_Layer.Controllers
{
    [Produces("application/json")]
    [Route("api/Tickets")]
    public class TicketsController : Controller
    {
        private readonly AirportService _service;
        private readonly IMapper _mapper;
        TicketDTOValidator validator = new TicketDTOValidator();

        public TicketsController(IMapper mapper, AirportService service)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/tickets
        [HttpGet]
        public IEnumerable<TicketDTO> Get()
        {
            return _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDTO>>(_service.GetAll<Ticket>());
        }

        // GET api/tickets/id
        [HttpGet("{id}")]
        public TicketDTO Get(int id)
        {
            return _mapper.Map<Ticket, TicketDTO>(_service.GetById<Ticket>(id));
        }

        // POST api/tickets
        [HttpPost]
        public HttpResponseMessage Post([FromBody]TicketDTO ticket)
        {
            if (ModelState.IsValid && ticket != null && validator.Validate(ticket).IsValid)
            {
                _service.Post<Ticket>(_mapper.Map<TicketDTO, Ticket>(ticket));
                _service.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // POST api/tickets/id
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody]TicketDTO ticket)
        {
            if (ModelState.IsValid && ticket != null && validator.Validate(ticket).IsValid)
            {
                _service.Update<Ticket>(id, _mapper.Map<TicketDTO, Ticket>(ticket));
                _service.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/tickets/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete<Ticket>(id);
            _service.SaveChanges();
        }
    }
}
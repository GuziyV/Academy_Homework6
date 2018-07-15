using Data_Access_Layer.Contexts;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    class FlightRepository : IRepository<Flight>
    {
        private AirportContext _context;

        public FlightRepository(AirportContext context)
        {
            _context = context;
        }

        public void Create(Flight item)
        {
            _context.Flights.Add(item);
        }

        public void Delete(int id)
        {
            _context.Flights.Remove(_context.Flights.Find(id));
        }

        public Flight Get(int id)
        {
            return _context.Flights.Include(f => f.Tickets).FirstOrDefault(f => f.Number == id);
        }

        public IEnumerable<Flight> GetAll()
        {
            return _context.Flights.Include(f => f.Tickets);
        }

        public void Update(int id, Flight item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}

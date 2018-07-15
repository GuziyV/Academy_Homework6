using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTOs
{
    public class FlightDTO
    {
        public int Number { get; set; }

        public string DepartureFrom { get; set; }

        public DateTime TimeOfDeparture { get; set; }

        public string Destination { get; set; }

        public DateTime ArrivalTime { get; set; }

        public List<TicketDTO> Tickets { get; set; }
    }
}

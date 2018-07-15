using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTOs
{
    public class DepartureDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public FlightDTO Flight { get; set; }

        public DateTime TimeOfDeparture { get; set; }

        public CrewDTO Crew { get; set; }

        public PlaneDTO Plane { get; set; }
    }
}

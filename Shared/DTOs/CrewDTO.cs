using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTOs
{
    public class CrewDTO
    {
        public int Id { get; set; }

        public PilotDTO Pilot { get; set; }

        public List<StewardessDTO> Stewardesses { get; set; }
    }
}

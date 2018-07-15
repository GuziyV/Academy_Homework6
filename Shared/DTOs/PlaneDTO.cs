using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTOs
{
    public class PlaneDTO
    {
        public int Id { get; set; }

        public PlaneTypeDTO PlaneType { get; set; }

        public DateTime ReleaseDate { get; set; }

        public TimeSpan LifeTime
        {
            get
            {
                return DateTime.Now - ReleaseDate;
            }
        }
    }
}

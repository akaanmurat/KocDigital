using System;
using System.ComponentModel.DataAnnotations;

namespace KocDigitalPOC.Data.Entities
{
    public class DataFrame
    {
        [Key]
        public Guid Id { get; set; }
        public string LocationId { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
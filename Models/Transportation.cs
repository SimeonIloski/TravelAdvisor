using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TripAdvisor.Models
{
    public class Transportation
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string startLocation { get; set; }
        public string  endLocation { get; set; }
        public  double price { get; set; }
    }
}
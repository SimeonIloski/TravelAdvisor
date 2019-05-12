using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TripAdvisor.Models
{
    public class Appartment
    {
        [Key]
        public  int Id { get; set; }
        public  string name { get; set; }
        public string locationName { get; set; }
        public  double singleBedPrice {get; set;}
        public double doubleBedPrice { get; set; }
        [Range(0,5)]
        public int rating { get; set; }
        public string imagepath { get; set; }

        
    }
}
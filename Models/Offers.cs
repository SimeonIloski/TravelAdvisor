using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TripAdvisor.Models
{
    public class Offers
    {
        [Key]
        public  int Id { get; set; }
        public  string locationName { get; set;}
        public  int transportationId { get; set; }
        public  string appartmentName { get; set; }
        public  double totalPrice { get; set; }
        public  double specialPrice { get; set; }
     }
}
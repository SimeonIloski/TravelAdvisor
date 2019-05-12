using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TripAdvisor.Models
{
    
    public class Location
    {
        [Key]
       public int Id { get; set; } 
       public string name { get; set; }
       public  string description { get; set; }
       public  string imagepath { get; set; }
  
    }
}
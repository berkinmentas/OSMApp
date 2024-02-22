using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   
    public class Point
    {
        [Key]
        public int pointId { get; set; }
        public string pointName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

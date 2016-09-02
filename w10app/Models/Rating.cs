using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w10app.Models
{
    public class Rating
    {
        public User User { get; set; }
        public Movie Movie   { get; set; }
        public Double Point { get; set; }
    } 
}

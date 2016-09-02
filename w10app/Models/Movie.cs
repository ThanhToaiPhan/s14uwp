using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w10app.Models
{
    public class Movie
    {
        public String Id { get; set; }
        public String[] Link { get; set; }
        public String Image { get; set; }
        public String Name { get; set; }
        public String Time { get; set; }
        public String ListProducer { get; set; }
        public String ListActor { get; set; }
        public String Country { get; set; }
        public String Trailer { get; set; }
        public int ReleaseYear { get; set; }
        public int NumberView { get; set; }
        public int NumberComment { get; set; }
        public string Content { get; set; }
        public List<Movie> ListRelevantMovie { get; set; }
        public String Type { get; set; }
        public String Episode { get; set; }
        public String Source { get; set; }
        public Double Rating { get; set; }
    }
}

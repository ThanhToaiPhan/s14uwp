using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w10app.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String UserName { get; set; }
        public String UserImage { get; set; }
        public String Content { get; set; }
        public int IdParent { get; set; }
        public List<Comment> ListSubComment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_management_auth.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int TotalPages { get; set; }
    }
}

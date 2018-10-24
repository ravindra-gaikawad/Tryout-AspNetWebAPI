using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetWebAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }
}
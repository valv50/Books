using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Models
{
    public class BookItem
    {
        [Key]
        public int bookId { get; set; }
        public string name { get; set; }
        public string text { get; set; }
        public decimal price { get; set; }
    }
}

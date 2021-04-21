using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBooks1.Models
{
    public class BookItem
    {
        [Key]
        public int bookId { get; set; }

        [Display(Name = "Book name")]
        public string name { get; set; }

        [Display(Name = "Text")]
        public string text { get; set; }

        [Display(Name = "Price")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal price { get; set; }

        [Display(Name = "Subscribed")]
        [Column(TypeName = "bit")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool subscribed { get; set; }
    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace inAndOut.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Borrower { get; set; }
        public string Lender { get; set; }
        [DisplayName("Item Name")]
        public string ItemName { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace KitkartFinal.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public Product PId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
    }
}

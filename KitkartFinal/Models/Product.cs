using System.ComponentModel.DataAnnotations;

namespace KitkartFinal.Models
{
 
        public class Product
        {
            [Key]
            public int ID { get; set; }
            public string ProductImage { get; set; }
            public string ProductName { get; set; }
            public int Price { get; set; }
            public int AvailableQty { get; set; }
        }
    }


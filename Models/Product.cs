using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    /// <summary>
    /// Продукт для создания питания
    /// </summary>
    public class Product
    {
        public int ID { set; get; }

        [Required]
        public string ProductName { set; get; }

        [Required]
        public int Count { set; get; }

		[ForeignKey("ProductId")]
        public virtual List<ProductRequirement> ProductRequirements { set; get; }

		[ForeignKey("ProductId")]
        public virtual List<ProductStorage> ProductStorages { set; get; }
	}
}

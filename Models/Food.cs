using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    /// <summary>
    /// Питание
    /// </summary>
    public class Food
    {
        public int ID { set; get; }
		
        [Required]
        public string FoodName { set; get; }

		[ForeignKey("FoodId")]
		public virtual List<ProductRequirement> ProductRequirements { set; get; }
	}
}

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

		public int AdminId { set; get; }

        [Required]
        public string FoodName { set; get; }

        [Required]
        public int something1 { set; get; }

        [Required]
        public int something2 { set; get; }

        [Required]
        public int something3 { set; get; }

/*		[ForeignKey("FoodId")]
		public virtual List<Transfer> Transfers { get; set; }*/

		[ForeignKey("FoodId")]
		public virtual List<ProductRequirement> ProductRequirements { set; get; }
	}
}

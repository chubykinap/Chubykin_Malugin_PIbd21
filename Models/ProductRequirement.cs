using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// Требования к продукту для создания питания
    /// </summary>
    public class ProductRequirement
    {
        public int ID { set; get; }

		[Required]
		public int FoodId { set; get; }

		[Required]
		public int ProductId { set; get; }

		public int Count { set; get; }

		public virtual Food Food { set; get; }

		public virtual Product Product { set; get; }
	}
}

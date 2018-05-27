using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// Хранение пролуктов
    /// </summary>
    public class ProductStorage
    {
        public int ID { set; get; }
		
		public int StorageId { set; get; }
		
		public int ProductId { set; get; }

		public int Count { set; get; }

		public virtual Storage Storage { set; get; }

		public virtual Product Product { set; get; }
	}
}

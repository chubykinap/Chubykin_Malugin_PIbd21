using System;

namespace Models
{
    /// <summary>
    /// Перемещения продуктов
    /// </summary>
    public class Transfer
    {
        public int ID { set; get; }

		public int AdminId { set; get; }

		public int ProviderId { set; get; }

		public int StorageId { set; get; }

		public int ProductId { set; get; }

		public int Count { set; get; }

		public ZooStatus Status { set; get; }

		public DateTime DateCreate { set; get; }

//		public int NumberOfProducts { set; get; }

		public virtual Admin Admin { set; get; }

		public virtual Provider Provider { set; get; }

		public virtual Storage Storage { set; get; }

		public virtual Product Product { set; get; }
	}
}

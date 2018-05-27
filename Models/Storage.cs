using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Склад
    /// </summary>
    public class Storage
    {
		public int Id { set; get; }

        [Required]
        public string StorageName { set; get; }

		[ForeignKey("StorageId")]
		public virtual List<ProductStorage> ProductStorages { set; get; }
	}
}

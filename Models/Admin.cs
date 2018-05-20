using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    /// <summary>
    /// Администратор
    /// </summary>
    public class Admin
    {
        public int ID { set; get; }

        [Required]
        public string Login { set; get; }

        [Required]
        public string Password { set; get; }

		[ForeignKey("AdminId")]
		public virtual List<Transfer> Transfers { get; set; }

		[ForeignKey("AdminId")]
		public virtual List<Food> Foods { get; set; }

		[ForeignKey("AdminId")]
		public virtual List<Product> Products { get; set; }
	}
}

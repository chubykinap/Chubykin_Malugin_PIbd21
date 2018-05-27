using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    /// <summary>
    /// Поставщик
    /// </summary>
    public class Provider
    {
        public int ID { set; get; }

        [Required]
        public string Login { set; get; }

        [Required]
        public string Password { set; get; }

		[ForeignKey("ProviderId")]
		public virtual List<Transfer> Transfers { get; set; }
	}
}

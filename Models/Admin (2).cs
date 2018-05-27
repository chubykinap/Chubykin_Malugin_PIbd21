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
		
        public string Login { set; get; }
		
        public string Password { set; get; }

		[ForeignKey("AdminId")]
		public virtual List<Transfer> Transfers { get; set; }
	}
}

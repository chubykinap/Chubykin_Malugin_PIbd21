using Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Classes
{
    [Table("ZooDatabase")]
	public class ZooDbContex : DbContext
	{
		public ZooDbContex()
		{
			//настройки конфигурации для entity
			Configuration.ProxyCreationEnabled = false;
			Configuration.LazyLoadingEnabled = false;
			var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
		}

		public virtual DbSet<Admin> Admins { get; set; }

		public virtual DbSet<Food> Foods { get; set; }

		public virtual DbSet<Product> Products { get; set; }

		public virtual DbSet<ProductRequirement> ProductRequirements { get; set; }

		public virtual DbSet<ProductStorage> ProductStorages { get; set; }

		public virtual DbSet<Provider> Providers { get; set; }

		public virtual DbSet<Storage> Storages { get; set; }

		public virtual DbSet<Transfer> Transfers { get; set; }
	}
}

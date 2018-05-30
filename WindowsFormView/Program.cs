using Classes;
using Classes.ImplementationsBD;
using Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace WindowsFormView
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			var container = BuildUnityContainer();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(container.Resolve <FormMain>());
		}

		public static IUnityContainer BuildUnityContainer()
		{
			var currentContainer = new UnityContainer();
			currentContainer.RegisterType<DbContext, ZooDbContex>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<ITransferService, TransferServiceBD>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<IAdminService, AdminServiceBD>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<IFoodService, FoodServiceBD>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<IProductService, ProductServiceBD>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<IProviderService, ProviderServiceBD>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<IStorageService, StorageServiceBD>(new HierarchicalLifetimeManager());

			return currentContainer;
		}
	}
}

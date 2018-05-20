using Classes.BindingModels;
using Classes.Interfaces;
using Classes.ViewModels;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.ImplementationsBD
{
	public class ProviderServiceBD : IProviderService
	{
		private ZooDbContex context;

		public ProviderServiceBD(ZooDbContex context)
		{
			this.context = context;
		}

		public List<ProviderViewModel> GetList()
		{
			List<ProviderViewModel> result = context.Admins
				.Select(rec => new ProviderViewModel
				{
					ID = rec.ID,
					Login = rec.Login
				})
				.ToList();
			return result;
		}

		public ProviderViewModel GetElement(int ID)
		{
			Provider element = context.Providers.FirstOrDefault(rec => rec.ID == ID);
			if (element != null)
			{
				return new ProviderViewModel
				{
					ID = element.ID,
					Login = element.Login
				};
			}
			throw new Exception("Элемент не найден");
		}

		public void AddElement(ProviderBindingModel model)
		{
			Provider element = context.Providers.FirstOrDefault(rec => rec.Login == model.Login);
			if (element != null)
			{
				throw new Exception("Уже есть сотрудник с таким ФИО");
			}
			context.Admins.Add(new Admin
			{
				Login = model.Login
			});
			context.SaveChanges();
		}

		public void UpdElement(ProviderBindingModel model)
		{
			Provider element = context.Providers.FirstOrDefault(rec =>
										rec.Login == model.Login && rec.ID != model.ID);
			if (element != null)
			{
				throw new Exception("Уже есть сотрудник с таким ФИО");
			}
			element = context.Providers.FirstOrDefault(rec => rec.ID == model.ID);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			element.Login = model.Login;
			context.SaveChanges();
		}

		public void DelElement(int ID)
		{
			Provider element = context.Providers.FirstOrDefault(rec => rec.ID == ID);
			if (element != null)
			{
				context.Providers.Remove(element);
				context.SaveChanges();
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}
	}
}

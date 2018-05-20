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
	public class AdminServiceBD : IAdminService
	{
		private ZooDbContex context;

		public AdminServiceBD(ZooDbContex context)
		{
			this.context = context;
		}

		public List<AdminViewModel> GetList()
		{
			List<AdminViewModel> result = context.Admins
				.Select(rec => new AdminViewModel
				{
					ID = rec.ID,
					Login = rec.Login
				})
				.ToList();
			return result;
		}

		public AdminViewModel GetElement(int ID)
		{
			Admin element = context.Admins.FirstOrDefault(rec => rec.ID == ID);
			if (element != null)
			{
				return new AdminViewModel
				{
					ID = element.ID,
					Login = element.Login
				};
			}
			throw new Exception("Элемент не найден");
		}

		public void AddElement(AdminBindingModel model)
		{
			Admin element = context.Admins.FirstOrDefault(rec => rec.Login == model.Login);
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

		public void UpdElement(AdminBindingModel model)
		{
			Admin element = context.Admins.FirstOrDefault(rec =>
										rec.Login == model.Login && rec.ID != model.ID);
			if (element != null)
			{
				throw new Exception("Уже есть сотрудник с таким ФИО");
			}
			element = context.Admins.FirstOrDefault(rec => rec.ID == model.ID);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			element.Login = model.Login;
			context.SaveChanges();
		}

		public void DelElement(int ID)
		{
			Admin element = context.Admins.FirstOrDefault(rec => rec.ID == ID);
			if (element != null)
			{
				context.Admins.Remove(element);
				context.SaveChanges();
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}
	}
}

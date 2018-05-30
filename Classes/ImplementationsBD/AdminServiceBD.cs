using Classes.BindingModels;
using Classes.Interfaces;
using Classes.ViewModels;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes.ImplementationsBD
{
    public class AdminServiceBD : IAdminService
	{
		private ZooDbContex context;

		public AdminServiceBD()
		{
			this.context = new ZooDbContex();
		}

		public List<AdminViewModel> GetList()
		{
			List<AdminViewModel> result = context.Admins
				.Select(rec => new AdminViewModel
				{
					ID = rec.ID,
					Login = rec.Login,
                    Password = rec.Password,
                    Mail = rec.Mail
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
					Login = element.Login,
                    Password = element.Password,
                    Mail = element.Mail
				};
			}
			throw new Exception("Элемент не найден");
		}

		public void AddElement(AdminBindingModel model)
		{
			Admin element = context.Admins.FirstOrDefault(rec => rec.Login == model.Login);
			if (element != null)
			{
				throw new Exception("Такой логин уже занят");
			}
            context.Admins.Add(new Admin
            {
                Login = model.Login,
                Password = model.Password,
                Mail = model.Mail
			});
			context.SaveChanges();
		}

		public void UpdElement(AdminBindingModel model)
		{
			Admin element = context.Admins.FirstOrDefault(rec =>
										rec.Login == model.Login && rec.ID != model.ID);
			if (element != null)
			{
				throw new Exception("Такой логин уже занят");
			}
			element = context.Admins.FirstOrDefault(rec => rec.ID == model.ID);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
            element.Password = model.Password;
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

        public void TryEnter(AdminBindingModel model)
        {
            Admin admin = context.Admins.FirstOrDefault(rec => rec.Login == model.Login);
            if (admin == null)
            {
                throw new Exception("Неверный логин");
            }
            if (admin.Password != model.Password)
            {
                throw new Exception("Неверный пароль");
            }
        }
    }
}

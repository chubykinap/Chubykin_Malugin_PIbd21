﻿using Classes.BindingModels;
using Classes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Interfaces
{
	public interface IStorageService
	{
		List<StorageViewModel> GetList();

		StorageViewModel GetElement(int id);

		void AddElement(StorageBindingModel model);

		void UpdElement(StorageBindingModel model);

		void DelElement(int id);
	}
}

using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyContracts.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.BussinessLogic
{
    // Класс, реализующий логику для исполнителя
    public class ImplementerLogic : IImplementerLogic
	{
		private readonly ILogger _logger;

		private readonly IImplementerStorage _implementerStorage;

		// Конструктор
		public ImplementerLogic(ILogger<ImplementerLogic> logger, IImplementerStorage implementerStorage)
		{
			_logger = logger;
			_implementerStorage = implementerStorage;
		}

		// Вывод всего отфильтрованного списка
		public List<ImplementerViewModel>? ReadList(ImplementerSearchModel? model)
		{
			_logger.LogInformation("ReadList. ImplementerFIO:{ImplementerFIO}. Id:{Id}", model?.ImplementerFIO, model?.Id);

			// list хранит весь список в случае, если model пришло со значением null на вход метода
			var list = model == null ? _implementerStorage.GetFullList() : _implementerStorage.GetFilteredList(model);

			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}

			_logger.LogInformation("ReadList. Count:{Count}", list.Count);

			return list;
		}

		// Вывод конкретного элемента
		public ImplementerViewModel? ReadElement(ImplementerSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			_logger.LogInformation("ReadList. ImplementerFIO:{ImplementerFIO}. Id:{Id}", model.ImplementerFIO, model?.Id);

			var element = _implementerStorage.GetElement(model);

			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");

				return null;
			}

			_logger.LogInformation("ReadElement find. Id:{Id}", element.Id);

			return element;
		}

		// Создание работника
		public bool Create(ImplementerBindingModel model)
		{
			CheckModel(model);

			if (_implementerStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");

				return false;
			}

			return true;
		}

		// Обновление данных о работнике
		public bool Update(ImplementerBindingModel model)
		{
			CheckModel(model);

			if (_implementerStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");

				return false;
			}

			return true;
		}

		// Удаление работника
		public bool Delete(ImplementerBindingModel model)
		{
			CheckModel(model, false);

			_logger.LogInformation("Delete. Id:{Id}", model.Id);

			if (_implementerStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");

				return false;
			}

			return true;
		}

		// Проверка входного аргумента для методов Insert, Update и Delete
		private void CheckModel(ImplementerBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			// Так как при удалении передаём как параметр false
			if (!withParams)
			{
				return;
			}

			// Проверка на наличие ФИО
			if (string.IsNullOrEmpty(model.ImplementerFIO))
			{
				throw new ArgumentNullException("Отсутствие ФИО в учётной записи", nameof(model.ImplementerFIO));
			}

			// Проверка на наличие пароля
			if (string.IsNullOrEmpty(model.Password))
			{
				throw new ArgumentNullException("Отсутствие пароля в учётной записи", nameof(model.Password));
			}

			// Проверка на наличие квалификации
			if (model.Qualification <= 0)
			{
				throw new ArgumentNullException("Указана некорректная квалификация", nameof(model.Qualification));
			}

			// Проверка на наличие квалификации
			if (model.WorkExperience < 0)
			{
				throw new ArgumentNullException("Указан некорректный стаж работы", nameof(model.WorkExperience));
			}

			_logger.LogInformation("Implementer. ImplementerFIO:{ImplementerFIO}. Password:{Password}. " +
				"Qualification:{Qualification}. WorkExperience:{ WorkExperience}. Id:{Id}",
				model.ImplementerFIO, model.Password, model.Qualification, model.WorkExperience, model.Id);

			// Для проверка на наличие такого же аккаунта
			var element = _implementerStorage.GetElement(new ImplementerSearchModel
			{
				ImplementerFIO = model.ImplementerFIO,
			});

			// Если элемент найден и его Id не совпадает с Id переданного объекта
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Исполнитель с таким именем уже есть");
			}
		}
	}
}

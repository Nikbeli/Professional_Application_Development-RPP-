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
	// Класс, реализующий логику для изделий
	public class FurnitureLogic : IFurnitureLogic
	{
		private readonly ILogger _logger;

		private readonly IFurnitureStorage _furnitureStorage;

		// Конструктор
		public FurnitureLogic(ILogger<FurnitureLogic> logger, IFurnitureStorage furnitureStorage)
		{
			_logger = logger;
			_furnitureStorage = furnitureStorage;
		}

		// Вывод отфильтрованного списка
		public List<FurnitureViewModel>? ReadList(FurnitureSearchModel? model)
		{
			_logger.LogInformation("ReadList. FurnitureName: {FurnitureName}. Id:{Id}", model?.FurnitureName, model?.Id);

			// list хранит весь список в случае, если model пришло со значением null на вход метода
			var list = model == null ? _furnitureStorage.GetFullList() : _furnitureStorage.GetFilteredList(model);

			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}

			_logger.LogInformation("ReadList. Count:{Count}", list.Count);

			return list;
		}

		// Вывод конкретного изделия
		public FurnitureViewModel? ReadElement(FurnitureSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			_logger.LogInformation("ReadElement. FurnitureName: {FurnitureName}. Id:{Id}", model.FurnitureName, model.Id);

			var element = _furnitureStorage.GetElement(model);

			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");
				return null;
			}

			_logger.LogInformation("Readelement find. Id:{Id}", model.Id);

			return element;
		}

		// Создание изделия
		public bool Create(FurnitureBindingModel model)
		{
			CheckModel(model);

			if (_furnitureStorage.Insert(model) == null)
			{
				_logger.LogWarning("Create operation failed");
				return false;
			}

			return true;
		}

		// Обновление изделия
		public bool Update(FurnitureBindingModel model)
		{
			CheckModel(model);

			if (_furnitureStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}

			return true;
		}

		// Удаление изделия
		public bool Delete(FurnitureBindingModel model)
		{
			CheckModel(model, false);

			_logger.LogInformation("Delete, Id:{Id}", model.Id);

			if (_furnitureStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");
				return false;
			}

			return true;
		}

		// Проверка входного аргумента для методов Insert, Update и Delete
		private void CheckModel(FurnitureBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			// При удалении параметру withParams передаём false
			if (!withParams)
			{
				return;
			}

			// Проверка на наличие названия изделия
			if (string.IsNullOrEmpty(model.FurnitureName))
			{
				throw new ArgumentNullException("Нет названия изделия", nameof(model.FurnitureName));
			}

			// Проверка на наличие нормальной цены у изделия
			if (model.Price <= 0)
			{
				throw new ArgumentNullException("Цена изделия должна быть больше 0", nameof(model.Price));
			}

			_logger.LogInformation("Furniture. FurnitureName:{FurnitureName}. Price:{Price}. Id:{Id}",
				model.FurnitureName, model.Price, model.Id);

			// Проверка на наличие такого же изделия в списке
			var element = _furnitureStorage.GetElement(new FurnitureSearchModel
			{
				FurnitureName = model.FurnitureName,
			});

			// Если элемент найден и его Id не совпадает с Id объекта, переданного на вход
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Изделие с таким названием уже есть");
			}
		}
	}
}

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
    // Класс, реализующий логику для заготовок
    public class WorkPieceLogic : IWorkPieceLogic
    {
        private readonly ILogger _logger;

        private readonly IWorkPieceStorage _workPieceStorage;

        // Конструктор
        public WorkPieceLogic(ILogger<WorkPieceLogic> logger, IWorkPieceStorage workPieceStorage)
        {
            _logger = logger;
            _workPieceStorage = workPieceStorage;
        }

        // Вывод отфильтрованного списка компонентов
        public List<WorkPieceViewModel>? ReadList(WorkPieceSearchModel? model)
        {
            _logger.LogInformation("ReadList. WorkPieceName:{WorkPieceName}. Id:{Id}", model?.WorkPieceName, model?.Id);

            // list хранит весь список в случае, если model пришло со значением null на вход метода
            var list = model == null ? _workPieceStorage.GetFullList() : _workPieceStorage.GetFilteredList(model);

            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }

            _logger.LogInformation("ReadList. Count:{Count}", list.Count);

            return list;
        }

        // Вывод конкретной заготовки
        public WorkPieceViewModel? ReadElement(WorkPieceSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _logger.LogInformation("ReadElement. WorkPieceName:{WorkPieceName}. Id:{Id}", model.WorkPieceName, model.Id);

            var element = _workPieceStorage.GetElement(model);

            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }

            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);

            return element;
        }

        // Создание заготовки
        public bool Create(WorkPieceBindingModel model)
        {
            CheckModel(model);

            if (_workPieceStorage.Insert(model) == null)
            {
                _logger.LogWarning("insert operation failed");
                return false;
            }

            return true;
        }

        // Обновление заготовки
        public bool Update(WorkPieceBindingModel model)
        {
            CheckModel(model);

            if (_workPieceStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }

            return true;
        }

        // Удаление заготовки
        public bool Delete(WorkPieceBindingModel model)
        {
            CheckModel(model, false);

            _logger.LogInformation("Delete. Id:{Id}", model.Id);

            if (_workPieceStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }

            return true;
        }

        // Проверка входного аргумента для методов Insert, Update и Delete
        private void CheckModel(WorkPieceBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            // При удалении передаём как параметр false
            if (!withParams)
            {
                return;
            }

            // Проверка на наличие названия заготовки
            if (string.IsNullOrEmpty(model.WorkPieceName))
            {
                throw new ArgumentNullException("Нет названия заготовки", nameof(model.WorkPieceName));
            }

            // Проверка на наличие нормальной цены у заготовки
            if (model.Cost <= 0)
            {
                throw new ArgumentNullException("Цена заготовки должна быть больше 0", nameof(model.Cost));
            }

            _logger.LogInformation("WorkPiece. WorkPieceName:{WorkPieceName}. Cost:{Cost}. Id{Id}",
                model.WorkPieceName, model.Cost, model.Id);

            // Проверка на наличие такой же заготовки в списке
            var element = _workPieceStorage.GetElement(new WorkPieceSearchModel
            {
                WorkPieceName = model.WorkPieceName,
            });

            // Если элемент найден и его Id не совпадает с Id переданного объекта
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Заготовка с таким названием уже есть");
            }
        }
    }
}

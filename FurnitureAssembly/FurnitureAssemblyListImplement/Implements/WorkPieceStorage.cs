using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyListImplement.Implements
{
    // Класс, реализующий интерфейс хранилища заготовок
    public class WorkPieceStorage : IWorkPieceStorage
    {
        // Поле для работы со списком заготовок
        private readonly DataListSingleton _source;

        // Получение в конструкторе объекта DataListSingleton
        public WorkPieceStorage()
        {
            _source = DataListSingleton.GetInstance();
        }

        // Получение полного списка заготовок
        public List<WorkPieceViewModel> GetFullList()
        {
            var result = new List<WorkPieceViewModel>();

            foreach (var workPiece in _source.WorkPiece)
            {
                result.Add(workPiece.GetViewModel);
            }

            return result;
        }

        // Получение отфильтрованного списка заготовок
        public List<WorkPieceViewModel> GetFilteredList(WorkPieceSearchModel model)
        {
            var result = new List<WorkPieceViewModel>();

            if (string.IsNullOrEmpty(model.WorkPieceName))
            {
                return result;
            }

            foreach(var workPiece in _source.WorkPiece)
            {
                if (workPiece.WorkPieceName.Contains(model.WorkPieceName))
                {
                    result.Add(workPiece.GetViewModel);
                }
            }

            return result;
        }

        // Получение элемента из списка заготовок
        public WorkPieceViewModel? GetElement(WorkPieceSearchModel model)
        {
            if (string.IsNullOrEmpty(model.WorkPieceName) && !model.Id.HasValue)
            {
                return null;
            }

            foreach (var workPiece in _source.WorkPiece)
            {
                if ((!string.IsNullOrEmpty(model.WorkPieceName) && workPiece.WorkPieceName == model.WorkPieceName) ||
                    (model.Id.HasValue && workPiece.Id == model.Id))
                {
                    return workPiece.GetViewModel;
                }
            }

            return null;
        }

        // При создании заготовки определяем для него новый id: ищем max id и прибавляем к нему 1
        public WorkPieceViewModel? Insert(WorkPieceBindingModel model)
        {
            model.Id = 1;

            foreach (var workPiece in _source.WorkPiece)
            {
                if (model.Id <= workPiece.Id)
                {
                    model.Id = workPiece.Id + 1;
                }
            }

            var newWorkPiece = WorkPiece.Create(model);

            if (newWorkPiece == null)
            {
                return null;
            }

            _source.WorkPiece.Add(newWorkPiece);

            return newWorkPiece.GetViewModel;
        }

        // Обновление заготовки
        public WorkPieceViewModel? Update(WorkPieceBindingModel model)
        {
            foreach (var workPiece in _source.WorkPiece)
            {
                if (workPiece.Id == model.Id)
                {
                    workPiece.Update(model);

                    return workPiece.GetViewModel;
                }
            }

            return null;
        }

        // Удаление заготовки
        public WorkPieceViewModel? Delete(WorkPieceBindingModel model)
        {
            for (int i = 0; i < _source.WorkPiece.Count; i++)
            {
                if (_source.WorkPiece[i].Id == model.Id)
                {
                    var element = _source.WorkPiece[i];
                    _source.WorkPiece.RemoveAt(i);

                    return element.GetViewModel;
                }
            }

            return null;
        }
    }
}

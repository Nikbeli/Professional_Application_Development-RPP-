﻿using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyListImplement.Models
{
    public class Implementer : IImplementerModel
    {
        public int Id { get; private set; }

        public string ImplementerFIO { get; private set; } = string.Empty;

        public string Password { get; private set; } = string.Empty;

        public int WorkExperience { get; private set; }

        public int Qualification { get; private set; }

        // Метод для создания объекта от класса-компонента на основе класса-BindingModel
        public static Implementer? Create(ImplementerBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }

            return new Implementer()
            {
                Id = model.Id,
                Password = model.Password,
                ImplementerFIO = model.ImplementerFIO,
                Qualification = model.Qualification,
                WorkExperience = model.WorkExperience
            };
        }

        // Метод изменения существующего объекта
        public void Update(ImplementerBindingModel? model)
        {
            if (model == null)
            {
                return;
            }

            Password = model.Password;
            ImplementerFIO = model.ImplementerFIO;
            Qualification = model.Qualification;
            WorkExperience = model.WorkExperience;
        }

        // Метод для создания объекта класса ViewModel на основе данных объекта класса-компонента
        public ImplementerViewModel GetViewModel => new()
        {
            Id = Id,
            Password = Password,
            ImplementerFIO = ImplementerFIO,
            Qualification = Qualification,
            WorkExperience = WorkExperience
        };
    }
}

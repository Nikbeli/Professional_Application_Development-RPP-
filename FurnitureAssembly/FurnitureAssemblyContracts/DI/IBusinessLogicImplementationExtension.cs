﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.DI
{
    public interface IBusinessLogicImplementationExtension
    {
        public int Priority { get; }

        // Регистрация сервисов
        public void RegisterServices();
    }
}

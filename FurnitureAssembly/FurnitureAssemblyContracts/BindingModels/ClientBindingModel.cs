using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.BindingModels
{
    // Реализация сущности "Клиент"
    public class ClientBindingModel : IClientModel
    {
        public int Id { get; set; }

        public string ClientFIO { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}

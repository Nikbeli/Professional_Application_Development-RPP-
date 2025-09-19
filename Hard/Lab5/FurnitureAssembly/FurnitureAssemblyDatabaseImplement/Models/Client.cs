using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDatabaseImplement.Models
{
    public class Client : IClientModel
    {
        public int Id { get; private set; }

        [Required]
        public string ClientFIO { get; private set; } = string.Empty;

        [Required]
        public string Email { get; private set; } = string.Empty;

        [Required]
        public string Password { get; private set; } = string.Empty;

        // Для реализации связи многие-ко-многим с заказами (клиенты могу сделать одинаковый заказ)
        [ForeignKey("ClientId")]
        public virtual List<Order> Orders { get; set; } = new();

        public static Client? Create(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new()
            {
                Id = model.Id,
                ClientFIO = model.ClientFIO,
                Email = model.Email,
                Password = model.Password
            };
        }

        public void Update(ClientBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            ClientFIO = model.ClientFIO;
            Email = model.Email;
            Password = model.Password;
        }

        public ClientViewModel GetViewModel => new()
        {
            Id = Id,
            ClientFIO = ClientFIO,
            Email = Email,
            Password = Password,
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDataModels.Models
{
    // Интерфейс, отвечающий за клиента
    public interface IClientModel : IId
    {
        string ClientFIO { get; }

        string Email { get; }

        string Password { get; }
    }
}

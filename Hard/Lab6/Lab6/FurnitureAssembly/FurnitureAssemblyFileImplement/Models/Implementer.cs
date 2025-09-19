using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FurnitureAssemblyFileImplement.Models
{
    public class Implementer : IImplementerModel
    {
        public int Id { get; private set; }

        public string ImplementerFIO { get; private set; } = string.Empty;

        public string Password { get; private set; } = string.Empty;

        public int WorkExperience { get; private set; }

        public int Qualification { get; private set; }

        public static Implementer? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                ImplementerFIO = element.Element("FIO")!.Value,
                Password = element.Element("Password")!.Value,
                Qualification = Convert.ToInt32(element.Element("Qualification")!.Value),
                WorkExperience = Convert.ToInt32(element.Element("WorkExperience")!.Value),
            };
        }

        public static Implementer? Create(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new()
            {
                Id = model.Id,
                ImplementerFIO = model.ImplementerFIO,
                Password = model.Password,
                Qualification = model.Qualification,
                WorkExperience = model.WorkExperience,
            };
        }

        public void Update(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            ImplementerFIO = model.ImplementerFIO;
            Password = model.Password;
            Qualification = model.Qualification;
            WorkExperience = model.WorkExperience;
        }

        public ImplementerViewModel GetViewModel => new()
        {
            Id = Id,
            ImplementerFIO = ImplementerFIO,
            Password = Password,
            Qualification = Qualification,
        };

        public XElement GetXElement => new("Client",
            new XAttribute("Id", Id),
            new XElement("FIO", ImplementerFIO),
            new XElement("Password", Password),
            new XElement("Qualification", Qualification),
            new XElement("WorkExperience", WorkExperience)
            );
    }
}

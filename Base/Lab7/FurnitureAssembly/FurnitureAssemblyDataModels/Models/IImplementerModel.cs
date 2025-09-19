using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDataModels.Models
{
	// Модель исполнителя
	public interface IImplementerModel : IId
	{
		string ImplementerFIO { get; }

		string Password { get; }

		int WorkExperience { get; }

		int Qualification { get; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDataModels.Enums
{
	// Статус заказа
	public enum OrderStatus
	{
		Неизвестен = -1,

		Принят = 0,

		Выполняется = 1,

		Готов = 2,

		Выдан = 3
	}
}

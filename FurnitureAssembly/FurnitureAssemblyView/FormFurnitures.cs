using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.DI;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurnitureAssemblyView
{
	public partial class FormFurnitures : Form
	{
		private readonly ILogger _logger;

		private readonly IFurnitureLogic _logic;

		public FormFurnitures(ILogger<FormFurnitures> logger, IFurnitureLogic logic)
		{
			InitializeComponent();

			_logger = logger;
			_logic = logic;
		}

		private void FormFurnitures_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			try
			{
				dataGridView.FillandConfigGrid(_logic.ReadList(null));

				_logger.LogInformation("Загрузка изделий");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки изделий");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormFurniture>();

			if (form.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void ButtonUpdate_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				var form = DependencyManager.Instance.Resolve<FormFurniture>();

				form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);

				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadData();
				}
			}
		}

		private void ButtonDelete_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);

					_logger.LogInformation("Удаление изделия");

					try
					{
						if (!_logic.Delete(new FurnitureBindingModel
						{
							Id = id
						}))
						{
							throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
						}

						LoadData();
					}
					catch (Exception ex)
					{
						_logger.LogError(ex, "Ошибка удаления компонента");
						MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void ButtonRefresh_Click(object sender, EventArgs e)
		{
			LoadData();
		}
	}
}

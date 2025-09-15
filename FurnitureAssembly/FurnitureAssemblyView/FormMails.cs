using FurnitureAssemblyContracts.BusinessLogicsContracts;
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
	public partial class FormMails : Form
	{
		private readonly ILogger _logger;

		private readonly IMessageInfoLogic _messageLogic;

		public FormMails(ILogger<FormMails> logger, IMessageInfoLogic messageLogic)
		{
			InitializeComponent();

			_logger = logger;
			_messageLogic = messageLogic;
		}

		private void FormMails_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			_logger.LogInformation("Загрузка писем");

			try
			{
				dataGridView.FillandConfigGrid(_messageLogic.ReadList(null));

				_logger.LogInformation("Успешная загрузка писем");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки писем");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}

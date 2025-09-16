﻿using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.ViewModels;
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

		private int currentPage = 1;

		public int pageSize = 5;

		public FormMails(ILogger<FormMails> logger, IMessageInfoLogic messageLogic)
        {
            InitializeComponent();

            _logger = logger;
            _messageLogic = messageLogic;

            buttonBack.Enabled = false;
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private bool LoadData()
        {
            _logger.LogInformation("Загрузка писем");

			try
			{
				var list = _messageLogic.ReadList(new()
				{
					Page = currentPage,
					PageSize = pageSize,
				});

				if (list != null)
				{
					dataGridView.DataSource = list;
					dataGridView.Columns["ClientId"].Visible = false;
					dataGridView.Columns["MessageId"].Visible = false;
					dataGridView.Columns["Body"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}

				_logger.LogInformation("Загрузка списка писем");

				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки писем");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

        private void ButtonForward_Click(object sender, EventArgs e)
        {
			currentPage++;
			if (!LoadData() || ((List<MessageInfoViewModel>)dataGridView.DataSource).Count == 0)
			{
				_logger.LogWarning("Обращение к несуществующему письму");

				currentPage--;
				LoadData();

				buttonForward.Enabled = false;
			}
			else
			{
				buttonBack.Enabled = true;
			}
		}

        private void ButtonBack_Click(object sender, EventArgs e)
        {
			if (currentPage == 1)
			{
				_logger.LogWarning("Некорректный номер страницы {page}", currentPage - 1);
				return;
			}

			currentPage--;

			if (LoadData())
			{
				buttonForward.Enabled = true;

				if (currentPage == 1)
				{
					buttonBack.Enabled = false;
				}
			}
		}

        private void ButtonAnswer_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormAnswerMail));

                if (service is FormAnswerMail form)
                {
                    form.MessageId = dataGridView.SelectedRows[0].Cells["MessageId"].Value.ToString();

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }
    }
}

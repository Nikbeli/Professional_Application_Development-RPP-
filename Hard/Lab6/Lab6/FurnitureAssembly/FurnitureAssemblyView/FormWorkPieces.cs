using FurnitureAssemblyContracts.BindingModels;
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
    // Форма со всеми созданными заготовками
    public partial class FormWorkPieces : Form
    {
        private readonly ILogger _logger;

        private readonly IWorkPieceLogic _logic;

        public FormWorkPieces(ILogger<FormWorkPieces> logger, IWorkPieceLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void FormWorkPiece_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Загрузка созданных заготовок
        private void LoadData()
        {
            try
            {
                var list = _logic.ReadList(null);

                // Растягиваем колонку Название на всю ширину, колонку Id скрываем
                if(list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns["Id"].Visible = false;
                    dataGridView.Columns["WorkPieceName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                _logger.LogInformation("Загрузка заготовок");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки заготовок");

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormWorkPiece));

            if (service is FormWorkPiece form)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        // Проверяем наличие выделенной строки
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormWorkPiece));
                
                if (service is FormWorkPiece form)
                {
                    form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            // Проверяем наличие выделенной строки
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);

                    _logger.LogInformation("Удаление компонента");

                    try
                    {
                        if (!_logic.Delete(new WorkPieceBindingModel
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

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.DI;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyDataModels.Models;
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
    public partial class FormFurniture : Form
    {
        private readonly ILogger _logger;

        private readonly IFurnitureLogic _logic;

        private int? _id;

        private Dictionary<int, (IWorkPieceModel, int)> _furnitureWorkPieces;

        public int Id { set { _id = value; } }

        public FormFurniture(ILogger<FormFurniture> logger, IFurnitureLogic logic)
        {
            InitializeComponent();

            _logger = logger;
            _logic = logic;
            _furnitureWorkPieces = new Dictionary<int, (IWorkPieceModel, int)>();
        }

        private void FormFurniture_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                _logger.LogInformation("Загрузка изделия");

                try
                {
                    var view = _logic.ReadElement(new FurnitureSearchModel { Id = _id.Value });

                    if (view != null)
                    {
                        textBoxName.Text = view.FurnitureName;
                        textBoxPrice.Text = view.Price.ToString();
                        _furnitureWorkPieces = view.FurnitureWorkPieces ?? new Dictionary<int, (IWorkPieceModel, int)>();
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка загрузки изделия");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadData()
        {
            _logger.LogInformation("Загрузка заготовок для изделия");

            try
            {
                if (_furnitureWorkPieces != null)
                {
                    dataGridView.Rows.Clear();

                    foreach (var awp in _furnitureWorkPieces)
                    {
                        dataGridView.Rows.Add(new object[] { awp.Key, awp.Value.Item1.WorkPieceName, awp.Value.Item2 });
                    }

                    textBoxPrice.Text = CalcPrice().ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки заготовки для изделия");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormFurnitureWorkPiece>();

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.WorkPieceModel == null)
                {
                    return;
                }

                _logger.LogInformation("Добавление новой заготовки:{WorkPieceName} - {Count}", form.WorkPieceModel.WorkPieceName, form.Count);

                if (_furnitureWorkPieces.ContainsKey(form.Id))
                {
                    _furnitureWorkPieces[form.Id] = (form.WorkPieceModel, form.Count);
                }
                else
                {
                    _furnitureWorkPieces.Add(form.Id, (form.WorkPieceModel, form.Count));
                }

                LoadData();
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = DependencyManager.Instance.Resolve<FormFurnitureWorkPiece>();

                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = _furnitureWorkPieces[id].Item2;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.WorkPieceModel == null)
                    {
                        return;
                    }

                    _logger.LogInformation("Изменение компонента:{WorkPieceName} - {Count}", form.WorkPieceModel.WorkPieceName, form.Count);
                    _furnitureWorkPieces[form.Id] = (form.WorkPieceModel, form.Count);

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
                    try
                    {
                        _logger.LogInformation("Удаление заготовки:{WorkPieceName} - {Count}", dataGridView.SelectedRows[0].Cells[1].Value);
                        _furnitureWorkPieces?.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LoadData();
                }
            }
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_furnitureWorkPieces == null || _furnitureWorkPieces.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _logger.LogInformation("Сохранение изделия");

            try
            {
                var model = new FurnitureBindingModel
                {
                    Id = _id ?? 0,
                    FurnitureName = textBoxName.Text,
                    Price = Convert.ToDouble(textBoxPrice.Text),
                    FurnitureWorkPieces = _furnitureWorkPieces
                };

                var operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);

                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка сохранения изделия");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // В конце умножить на 1.1, так как прибавляем к итоговой стоимости некоторый процент (в данном случае 10%)
        private double CalcPrice()
        {
            double price = 0;

            foreach (var elem in _furnitureWorkPieces)
            {
                price += ((elem.Value.Item1?.Cost ?? 0) * elem.Value.Item2);
            }

            return Math.Round(price * 1.1, 2);
        }
    }
}

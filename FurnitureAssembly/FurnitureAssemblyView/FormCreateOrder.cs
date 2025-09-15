using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
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
    public partial class FormCreateOrder : Form
    {
        private readonly ILogger _logger;

        private readonly IFurnitureLogic _logicFurniture;

        private readonly IOrderLogic _logicOrder;

        public FormCreateOrder(ILogger<FormCreateOrder> logger, IFurnitureLogic logicFurniture, IOrderLogic logicOrder)
        {
            InitializeComponent();

            _logger = logger;
            _logicFurniture = logicFurniture;
            _logicOrder = logicOrder;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            _logger.LogInformation("Загрузка изделий для заказа");

            try
            {
                var list = _logicFurniture.ReadList(null);

                if (list != null)
                {
                    comboBoxFurniture.DisplayMember = "FurnitureName";
                    comboBoxFurniture.ValueMember = "Id";
                    comboBoxFurniture.DataSource = list;
                    comboBoxFurniture.SelectedItem = null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки изделий для заказа");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxFurniture.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxFurniture.SelectedValue);
                    
                    var furniture = _logicFurniture.ReadElement(new FurnitureSearchModel
                    {
                        Id = id
                    });

                    int count = Convert.ToInt32(textBoxCount.Text);

                    textBoxSum.Text = Math.Round(count * (furniture?.Price ?? 0), 2).ToString();
                   
                    _logger.LogInformation("Расчет суммы заказа");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка расчета суммы заказа");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ComboBoxFurniture_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxFurniture.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _logger.LogInformation("Создание заказа");

            try
            {
                var operationResult = _logicOrder.CreateOrder(new OrderBindingModel
                {
                    FurnitureId = Convert.ToInt32(comboBoxFurniture.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDouble(textBoxSum.Text)
                });

                if (!operationResult)
                {
                    throw new Exception("Ошибка при создании заказа. Дополнительная информация в логах.");
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания заказа");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

using FurnitureAssemblyContracts.BusinesslogicShopContracts;
using FurnitureAssemblyContracts.SearchModels;
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
    public partial class FormSellFurniture : Form
    {
        private readonly ILogger _logger;

        private readonly IFurnitureLogic _logicFurniture;

        private readonly IShopLogic _logicShop;

        public FormSellFurniture(ILogger<FormAddFurniture> logger, IFurnitureLogic logicFurniture, IShopLogic logicShop)
        {
            InitializeComponent();

            _logger = logger;
            _logicFurniture = logicFurniture;
            _logicShop = logicShop;
        }

        private void FormSellFurniture_Load(object sender, EventArgs e)
        {
            _logger.LogInformation("Загрузка списка изделий для продажи");

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
                _logger.LogError(ex, "Ошибка загрузки списка изделий");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            _logger.LogInformation("Продажа изделия");

            try
            {
                var operationResult = _logicShop.SellFurnitures(_logicFurniture.ReadElement(new FurnitureSearchModel()
                {
                    Id = Convert.ToInt32(comboBoxFurniture.SelectedValue)
                })!, Convert.ToInt32(textBoxCount.Text));

                if (!operationResult)
                {
                    throw new Exception("Ошибка при продаже изделия. Дополнительная информация в логах. Недостаточно изделий");
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка продажи изделия");
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

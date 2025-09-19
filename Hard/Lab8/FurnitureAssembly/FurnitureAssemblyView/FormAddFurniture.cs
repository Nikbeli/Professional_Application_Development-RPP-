using FurnitureAssemblyContracts.BusinessLogicsContracts;
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
    public partial class FormAddFurniture : Form
    {
        private readonly ILogger _logger;
        private readonly IFurnitureLogic _logicI;
        private readonly IShopLogic _logicS;

        public FormAddFurniture(ILogger<FormAddFurniture> logger, IFurnitureLogic logicI, IShopLogic logicS)
        {
            InitializeComponent();
            _logger = logger;
            _logicI = logicI;
            _logicS = logicS;
        }

        private void FormAddFurniture_Load(object sender, EventArgs e)
        {
            _logger.LogInformation("Загрузка списка изделий для пополнения");

            try
            {
                var list = _logicI.ReadList(null);

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

            _logger.LogInformation("Загрузка списка магазинов для пополнения");
            try
            {
                var list = _logicS.ReadList(null);

                if (list != null)
                {
                    comboBoxShop.DisplayMember = "ShopName";
                    comboBoxShop.ValueMember = "Id";
                    comboBoxShop.DataSource = list;
                    comboBoxShop.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка магазинов");
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

            if (comboBoxShop.SelectedValue == null)
            {
                MessageBox.Show("Выберите магазин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _logger.LogInformation("Пополнение магазина");

            try
            {
                var operationResult = _logicS.AddFurniture(new ShopSearchModel
                {
                    Id = Convert.ToInt32(comboBoxShop.SelectedValue)
                },

                _logicI.ReadElement(new FurnitureSearchModel()
                {
                    Id = Convert.ToInt32(comboBoxFurniture.SelectedValue)
                })!, Convert.ToInt32(textBoxCount.Text));

                if (!operationResult)
                {
                    throw new Exception("Ошибка при пополнении магазина. Дополнительная информация в логах.");
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

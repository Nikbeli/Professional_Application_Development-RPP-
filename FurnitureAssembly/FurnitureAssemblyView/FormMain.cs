using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyDataModels.Enums;
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
    public partial class FormMain : Form
    {
        private readonly ILogger _logger;

        private readonly IOrderLogic _orderLogic;

        private readonly IReportLogic _reportLogic;

        private readonly IWorkProcess _workProcess;

        public FormMain(ILogger<FormMain> logger, IOrderLogic orderLogic, IReportLogic reportLogic, IWorkProcess workProcess)
        {
            InitializeComponent();

            _logger = logger;
            _orderLogic = orderLogic;
            _reportLogic = reportLogic;
            _workProcess = workProcess;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            _logger.LogInformation("Загрузка заказов");

            try
            {
                var list = _orderLogic.ReadList(null);

                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns["FurnitureId"].Visible = false;
                    dataGridView.Columns["ClientId"].Visible = false;
                    dataGridView.Columns["ImplementerId"].Visible = false;
                    dataGridView.Columns["FurnitureName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns["ClientFIO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns["ImplementerFIO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                _logger.LogInformation("Загрузка заказов");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки заказов");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WorkPieceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormWorkPieces));

            if (service is FormWorkPieces form)
            {
                form.ShowDialog();
            }
        }

        private void FurnitureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormFurnitures));

            if (service is FormFurnitures form)
            {
                form.ShowDialog();
            }
        }

        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormCreateOrder));

            if (service is FormCreateOrder form)
            {
                form.ShowDialog();
                LoadData();
            }
        }

        private void ButtonIssuedOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                _logger.LogInformation("Заказ №{id}. Меняется статус на 'Выдан'", id);

                try
                {
                    var operationResult = _orderLogic.DeliveryOrder(new OrderBindingModel
                    {
                        Id = id
                    });

                    if (!operationResult)
                    {
                        throw new Exception("Заказ не в статусе готовности. Дополнительная информация в логах.");
                    }

                    _logger.LogInformation("Заказ №{id} выдан", id);

                    LoadData();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка отметки о выдачи заказа");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormShops));

            if (service is FormShops form)
            {
                form.ShowDialog();
            }
        }


        private void AddFurnitureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormAddFurniture));

            if (service is FormAddFurniture form)
            {
                form.ShowDialog();
                LoadData();
            }
        }

        private void ButtonSellFurniture_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormSellFurniture));
            if (service is FormSellFurniture form)
            {
                form.ShowDialog();
                LoadData();
            }
        }

        private void GroupedOrdersReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormReportGroupedOrders));

            if (service is FormReportGroupedOrders form)
            {
                form.ShowDialog();
            }
        }

        private void OrdersReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormReportOrders));

            if (service is FormReportOrders form)
            {
                form.ShowDialog();
            }
        }

        private void WorkloadStoresReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormReportShopFurnitures));

            if (service is FormReportShopFurnitures form)
            {
                form.ShowDialog();
            }
        }

        private void ShopsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _reportLogic.SaveShopsToWordFile(new ReportBindingModel { FileName = dialog.FileName });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ReportFurnitureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _reportLogic.SaveFurnituresToWordFile(new ReportBindingModel
                {
                    FileName = dialog.FileName
                });

                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void WorkPieceFurnituresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormReportFurnitureWorkPieces));

            if (service is FormReportFurnitureWorkPieces form)
            {
                form.ShowDialog();
            }
        }

        private void ClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormClients));

            if (service is FormClients form)
            {
                form.ShowDialog();
            }
        }

        private void ImplementerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormImplementers));

            if (service is FormImplementers form)
            {
                form.ShowDialog();
            }
        }

        private void StartWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _workProcess.DoWork((Program.ServiceProvider?.GetService(typeof(IImplementerLogic)) as IImplementerLogic)!, _orderLogic);

            MessageBox.Show("Процесс обработки запущен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

namespace FurnitureAssemblyView
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView = new DataGridView();
            buttonCreateOrder = new Button();
            buttonIssuedOrder = new Button();
            buttonRefresh = new Button();
            menuStrip = new MenuStrip();
            toolStripMenuItem = new ToolStripMenuItem();
            workPieceToolStripMenuItem = new ToolStripMenuItem();
            furnitureToolStripMenuItem = new ToolStripMenuItem();
            shopToolStripMenuItem = new ToolStripMenuItem();
            addFurnitureToolStripMenuItem = new ToolStripMenuItem();
            reportToolStripMenuItem = new ToolStripMenuItem();
            groupedOrdersReportToolStripMenuItem = new ToolStripMenuItem();
            ordersReportToolStripMenuItem = new ToolStripMenuItem();
            workloadStoresReportToolStripMenuItem = new ToolStripMenuItem();
            shopsReportToolStripMenuItem = new ToolStripMenuItem();
            reportManufactureToolStripMenuItem = new ToolStripMenuItem();
            workPieceManufacturesToolStripMenuItem = new ToolStripMenuItem();
            workWithClientsToolStripMenuItem = new ToolStripMenuItem();
            clientsToolStripMenuItem = new ToolStripMenuItem();
            письмаToolStripMenuItem = new ToolStripMenuItem();
            workWithImplementerToolStripMenuItem = new ToolStripMenuItem();
            implementerToolStripMenuItem = new ToolStripMenuItem();
            startWorkToolStripMenuItem = new ToolStripMenuItem();
            создатьБэкапToolStripMenuItem = new ToolStripMenuItem();
            buttonSellFurniture = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(11, 36);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(937, 403);
            dataGridView.TabIndex = 0;
            // 
            // buttonCreateOrder
            // 
            buttonCreateOrder.Location = new Point(1014, 51);
            buttonCreateOrder.Name = "buttonCreateOrder";
            buttonCreateOrder.Size = new Size(247, 48);
            buttonCreateOrder.TabIndex = 1;
            buttonCreateOrder.Text = "Создать заказ";
            buttonCreateOrder.UseVisualStyleBackColor = true;
            buttonCreateOrder.Click += ButtonCreateOrder_Click;
            // 
            // buttonIssuedOrder
            // 
            buttonIssuedOrder.Location = new Point(1014, 121);
            buttonIssuedOrder.Name = "buttonIssuedOrder";
            buttonIssuedOrder.Size = new Size(247, 43);
            buttonIssuedOrder.TabIndex = 4;
            buttonIssuedOrder.Text = "Заказ выдан";
            buttonIssuedOrder.UseVisualStyleBackColor = true;
            buttonIssuedOrder.Click += ButtonIssuedOrder_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(1014, 187);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(247, 41);
            buttonRefresh.TabIndex = 5;
            buttonRefresh.Text = "Обновить";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += ButtonRefresh_Click;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem, reportToolStripMenuItem, workWithClientsToolStripMenuItem, workWithImplementerToolStripMenuItem, startWorkToolStripMenuItem, создатьБэкапToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(6, 3, 0, 3);
            menuStrip.Size = new Size(1297, 30);
            menuStrip.TabIndex = 6;
            menuStrip.Text = "menuStrip";
            // 
            // toolStripMenuItem
            // 
            toolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { workPieceToolStripMenuItem, furnitureToolStripMenuItem, shopToolStripMenuItem, addFurnitureToolStripMenuItem });
            toolStripMenuItem.Name = "toolStripMenuItem";
            toolStripMenuItem.Size = new Size(117, 24);
            toolStripMenuItem.Text = "Справочники";
            // 
            // workPieceToolStripMenuItem
            // 
            workPieceToolStripMenuItem.Name = "workPieceToolStripMenuItem";
            workPieceToolStripMenuItem.Size = new Size(251, 26);
            workPieceToolStripMenuItem.Text = "Заготовки";
            workPieceToolStripMenuItem.Click += WorkPieceToolStripMenuItem_Click;
            // 
            // furnitureToolStripMenuItem
            // 
            furnitureToolStripMenuItem.Name = "furnitureToolStripMenuItem";
            furnitureToolStripMenuItem.Size = new Size(251, 26);
            furnitureToolStripMenuItem.Text = "Изделия";
            furnitureToolStripMenuItem.Click += FurnitureToolStripMenuItem_Click;
            // 
            // shopToolStripMenuItem
            // 
            shopToolStripMenuItem.Name = "shopToolStripMenuItem";
            shopToolStripMenuItem.Size = new Size(251, 26);
            shopToolStripMenuItem.Text = "Магазины";
            shopToolStripMenuItem.Click += ShopToolStripMenuItem_Click;
            // 
            // addFurnitureToolStripMenuItem
            // 
            addFurnitureToolStripMenuItem.Name = "addFurnitureToolStripMenuItem";
            addFurnitureToolStripMenuItem.Size = new Size(251, 26);
            addFurnitureToolStripMenuItem.Text = "Пополнение магазина";
            addFurnitureToolStripMenuItem.Click += AddFurnitureToolStripMenuItem_Click;
            // 
            // reportToolStripMenuItem
            // 
            reportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { groupedOrdersReportToolStripMenuItem, ordersReportToolStripMenuItem, workloadStoresReportToolStripMenuItem, shopsReportToolStripMenuItem, reportManufactureToolStripMenuItem, workPieceManufacturesToolStripMenuItem });
            reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            reportToolStripMenuItem.Size = new Size(73, 24);
            reportToolStripMenuItem.Text = "Отчёты";
            // 
            // groupedOrdersReportToolStripMenuItem
            // 
            groupedOrdersReportToolStripMenuItem.Name = "groupedOrdersReportToolStripMenuItem";
            groupedOrdersReportToolStripMenuItem.Size = new Size(310, 26);
            groupedOrdersReportToolStripMenuItem.Text = "Список заказов за весь период";
            groupedOrdersReportToolStripMenuItem.Click += GroupedOrdersReportToolStripMenuItem_Click;
            // 
            // ordersReportToolStripMenuItem
            // 
            ordersReportToolStripMenuItem.Name = "ordersReportToolStripMenuItem";
            ordersReportToolStripMenuItem.Size = new Size(310, 26);
            ordersReportToolStripMenuItem.Text = "Список заказов";
            ordersReportToolStripMenuItem.Click += OrdersReportToolStripMenuItem_Click;
            // 
            // workloadStoresReportToolStripMenuItem
            // 
            workloadStoresReportToolStripMenuItem.Name = "workloadStoresReportToolStripMenuItem";
            workloadStoresReportToolStripMenuItem.Size = new Size(310, 26);
            workloadStoresReportToolStripMenuItem.Text = "Загруженность магазинов";
            workloadStoresReportToolStripMenuItem.Click += WorkloadStoresReportToolStripMenuItem_Click;
            // 
            // shopsReportToolStripMenuItem
            // 
            shopsReportToolStripMenuItem.Name = "shopsReportToolStripMenuItem";
            shopsReportToolStripMenuItem.Size = new Size(310, 26);
            shopsReportToolStripMenuItem.Text = "Таблица магазинов";
            shopsReportToolStripMenuItem.Click += ShopsReportToolStripMenuItem_Click;
            // 
            // reportManufactureToolStripMenuItem
            // 
            reportManufactureToolStripMenuItem.Name = "reportManufactureToolStripMenuItem";
            reportManufactureToolStripMenuItem.Size = new Size(310, 26);
            reportManufactureToolStripMenuItem.Text = "Список изделий";
            reportManufactureToolStripMenuItem.Click += ReportFurnitureToolStripMenuItem_Click;
            // 
            // workPieceManufacturesToolStripMenuItem
            // 
            workPieceManufacturesToolStripMenuItem.Name = "workPieceManufacturesToolStripMenuItem";
            workPieceManufacturesToolStripMenuItem.Size = new Size(310, 26);
            workPieceManufacturesToolStripMenuItem.Text = "Заготовки по изделиям";
            workPieceManufacturesToolStripMenuItem.Click += WorkPieceFurnituresToolStripMenuItem_Click;
            // 
            // workWithClientsToolStripMenuItem
            // 
            workWithClientsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clientsToolStripMenuItem, письмаToolStripMenuItem });
            workWithClientsToolStripMenuItem.Name = "workWithClientsToolStripMenuItem";
            workWithClientsToolStripMenuItem.Size = new Size(161, 24);
            workWithClientsToolStripMenuItem.Text = "Работа с клиентами";
            // 
            // clientsToolStripMenuItem
            // 
            clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            clientsToolStripMenuItem.Size = new Size(152, 26);
            clientsToolStripMenuItem.Text = "Клиенты";
            clientsToolStripMenuItem.Click += ClientsToolStripMenuItem_Click;
            // 
            // письмаToolStripMenuItem
            // 
            письмаToolStripMenuItem.Name = "письмаToolStripMenuItem";
            письмаToolStripMenuItem.Size = new Size(152, 26);
            письмаToolStripMenuItem.Text = "Письма";
            письмаToolStripMenuItem.Click += MessageToolStripMenuItem_Click;
            // 
            // workWithImplementerToolStripMenuItem
            // 
            workWithImplementerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { implementerToolStripMenuItem });
            workWithImplementerToolStripMenuItem.Name = "workWithImplementerToolStripMenuItem";
            workWithImplementerToolStripMenuItem.Size = new Size(196, 24);
            workWithImplementerToolStripMenuItem.Text = "Работа с исполнителями";
            workWithImplementerToolStripMenuItem.Click += ImplementerToolStripMenuItem_Click;
            // 
            // implementerToolStripMenuItem
            // 
            implementerToolStripMenuItem.Name = "implementerToolStripMenuItem";
            implementerToolStripMenuItem.Size = new Size(185, 26);
            implementerToolStripMenuItem.Text = "Исполнители";
            // 
            // startWorkToolStripMenuItem
            // 
            startWorkToolStripMenuItem.Name = "startWorkToolStripMenuItem";
            startWorkToolStripMenuItem.Size = new Size(114, 24);
            startWorkToolStripMenuItem.Text = "Запуск работ";
            startWorkToolStripMenuItem.Click += StartWorkToolStripMenuItem_Click;
            // 
            // создатьБэкапToolStripMenuItem
            // 
            создатьБэкапToolStripMenuItem.Name = "создатьБэкапToolStripMenuItem";
            создатьБэкапToolStripMenuItem.Size = new Size(122, 24);
            создатьБэкапToolStripMenuItem.Text = "Создать бэкап";
            создатьБэкапToolStripMenuItem.Click += CreateBackUpToolStripMenuItem_Click;
            // 
            // buttonSellFurniture
            // 
            buttonSellFurniture.Location = new Point(1014, 249);
            buttonSellFurniture.Name = "buttonSellFurniture";
            buttonSellFurniture.Size = new Size(247, 40);
            buttonSellFurniture.TabIndex = 8;
            buttonSellFurniture.Text = "Продажа изделий";
            buttonSellFurniture.UseVisualStyleBackColor = true;
            buttonSellFurniture.Click += ButtonSellFurniture_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1297, 451);
            Controls.Add(buttonSellFurniture);
            Controls.Add(buttonRefresh);
            Controls.Add(buttonIssuedOrder);
            Controls.Add(buttonCreateOrder);
            Controls.Add(dataGridView);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "FormMain";
            Text = "Сборка мебели";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Button buttonCreateOrder;
        private Button buttonIssuedOrder;
        private Button buttonRefresh;
        private MenuStrip menuStrip;
        private ToolStripMenuItem toolStripMenuItem;
        private ToolStripMenuItem workPieceToolStripMenuItem;
        private ToolStripMenuItem furnitureToolStripMenuItem;
        private ToolStripMenuItem shopToolStripMenuItem;
        private ToolStripMenuItem addFurnitureToolStripMenuItem;
        private Button buttonSellFurniture;
        private ToolStripMenuItem reportToolStripMenuItem;
        private ToolStripMenuItem groupedOrdersReportToolStripMenuItem;
        private ToolStripMenuItem ordersReportToolStripMenuItem;
        private ToolStripMenuItem workloadStoresReportToolStripMenuItem;
        private ToolStripMenuItem shopsReportToolStripMenuItem;
        private ToolStripMenuItem reportManufactureToolStripMenuItem;
        private ToolStripMenuItem workPieceManufacturesToolStripMenuItem;
        private ToolStripMenuItem workWithClientsToolStripMenuItem;
        private ToolStripMenuItem clientsToolStripMenuItem;
        private ToolStripMenuItem startWorkToolStripMenuItem;
        private ToolStripMenuItem workWithImplementerToolStripMenuItem;
        private ToolStripMenuItem implementerToolStripMenuItem;
        private ToolStripMenuItem письмаToolStripMenuItem;
        private ToolStripMenuItem создатьБэкапToolStripMenuItem;
    }
}
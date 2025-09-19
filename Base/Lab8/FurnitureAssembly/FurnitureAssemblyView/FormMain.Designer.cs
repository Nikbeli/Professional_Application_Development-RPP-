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
            mailsToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            workPiecesToolStripMenuItem = new ToolStripMenuItem();
            workPieceFurnituresToolStripMenuItem = new ToolStripMenuItem();
            ordersToolStripMenuItem = new ToolStripMenuItem();
            workWithClientsToolStripMenuItem = new ToolStripMenuItem();
            clientsToolStripMenuItem = new ToolStripMenuItem();
            workWithImplementerToolStripMenuItem = new ToolStripMenuItem();
            implementerToolStripMenuItem = new ToolStripMenuItem();
            startingWorkToolStripMenuItem = new ToolStripMenuItem();
            createBackUpToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(10, 27);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(820, 302);
            dataGridView.TabIndex = 0;
            // 
            // buttonCreateOrder
            // 
            buttonCreateOrder.Location = new Point(887, 50);
            buttonCreateOrder.Margin = new Padding(3, 2, 3, 2);
            buttonCreateOrder.Name = "buttonCreateOrder";
            buttonCreateOrder.Size = new Size(206, 34);
            buttonCreateOrder.TabIndex = 1;
            buttonCreateOrder.Text = "Создать заказ";
            buttonCreateOrder.UseVisualStyleBackColor = true;
            buttonCreateOrder.Click += ButtonCreateOrder_Click;
            // 
            // buttonIssuedOrder
            // 
            buttonIssuedOrder.Location = new Point(887, 100);
            buttonIssuedOrder.Margin = new Padding(3, 2, 3, 2);
            buttonIssuedOrder.Name = "buttonIssuedOrder";
            buttonIssuedOrder.Size = new Size(206, 33);
            buttonIssuedOrder.TabIndex = 4;
            buttonIssuedOrder.Text = "Заказ выдан";
            buttonIssuedOrder.UseVisualStyleBackColor = true;
            buttonIssuedOrder.Click += ButtonIssuedOrder_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(887, 152);
            buttonRefresh.Margin = new Padding(3, 2, 3, 2);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(206, 29);
            buttonRefresh.TabIndex = 5;
            buttonRefresh.Text = "Обновить";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += ButtonRefresh_Click;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem, reportsToolStripMenuItem, workWithClientsToolStripMenuItem, workWithImplementerToolStripMenuItem, startingWorkToolStripMenuItem, createBackUpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(5, 2, 0, 2);
            menuStrip.Size = new Size(1135, 24);
            menuStrip.TabIndex = 6;
            menuStrip.Text = "menuStrip";
            // 
            // toolStripMenuItem
            // 
            toolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { workPieceToolStripMenuItem, furnitureToolStripMenuItem, mailsToolStripMenuItem });
            toolStripMenuItem.Name = "toolStripMenuItem";
            toolStripMenuItem.Size = new Size(94, 20);
            toolStripMenuItem.Text = "Справочники";
            // 
            // workPieceToolStripMenuItem
            // 
            workPieceToolStripMenuItem.Name = "workPieceToolStripMenuItem";
            workPieceToolStripMenuItem.Size = new Size(130, 22);
            workPieceToolStripMenuItem.Text = "Заготовки";
            workPieceToolStripMenuItem.Click += WorkPieceToolStripMenuItem_Click;
            // 
            // furnitureToolStripMenuItem
            // 
            furnitureToolStripMenuItem.Name = "furnitureToolStripMenuItem";
            furnitureToolStripMenuItem.Size = new Size(130, 22);
            furnitureToolStripMenuItem.Text = "Изделия";
            furnitureToolStripMenuItem.Click += FurnitureToolStripMenuItem_Click;
            // 
            // mailsToolStripMenuItem
            // 
            mailsToolStripMenuItem.Name = "mailsToolStripMenuItem";
            mailsToolStripMenuItem.Size = new Size(130, 22);
            mailsToolStripMenuItem.Text = "Письма";
            mailsToolStripMenuItem.Click += MailsToolStripMenuItem_Click;
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { workPiecesToolStripMenuItem, workPieceFurnituresToolStripMenuItem, ordersToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(60, 20);
            reportsToolStripMenuItem.Text = "Отчёты";
            // 
            // workPiecesToolStripMenuItem
            // 
            workPiecesToolStripMenuItem.Name = "workPiecesToolStripMenuItem";
            workPiecesToolStripMenuItem.Size = new Size(203, 22);
            workPiecesToolStripMenuItem.Text = "Список заготовок";
            workPiecesToolStripMenuItem.Click += WorkPiecesToolStripMenuItem_Click;
            // 
            // workPieceFurnituresToolStripMenuItem
            // 
            workPieceFurnituresToolStripMenuItem.Name = "workPieceFurnituresToolStripMenuItem";
            workPieceFurnituresToolStripMenuItem.Size = new Size(203, 22);
            workPieceFurnituresToolStripMenuItem.Text = "Заготовки по изделиям";
            workPieceFurnituresToolStripMenuItem.Click += WorkPieceFurnituresToolStripMenuItem_Click;
            // 
            // ordersToolStripMenuItem
            // 
            ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            ordersToolStripMenuItem.Size = new Size(203, 22);
            ordersToolStripMenuItem.Text = "Список заказов";
            ordersToolStripMenuItem.Click += OrdersToolStripMenuItem_Click;
            // 
            // workWithClientsToolStripMenuItem
            // 
            workWithClientsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clientsToolStripMenuItem });
            workWithClientsToolStripMenuItem.Name = "workWithClientsToolStripMenuItem";
            workWithClientsToolStripMenuItem.Size = new Size(129, 20);
            workWithClientsToolStripMenuItem.Text = "Работа с клиентами";
            // 
            // clientsToolStripMenuItem
            // 
            clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            clientsToolStripMenuItem.Size = new Size(122, 22);
            clientsToolStripMenuItem.Text = "Клиенты";
            clientsToolStripMenuItem.Click += ClientsToolStripMenuItem_Click;
            // 
            // workWithImplementerToolStripMenuItem
            // 
            workWithImplementerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { implementerToolStripMenuItem });
            workWithImplementerToolStripMenuItem.Name = "workWithImplementerToolStripMenuItem";
            workWithImplementerToolStripMenuItem.Size = new Size(157, 20);
            workWithImplementerToolStripMenuItem.Text = "Работа с исполнителями";
            // 
            // implementerToolStripMenuItem
            // 
            implementerToolStripMenuItem.Name = "implementerToolStripMenuItem";
            implementerToolStripMenuItem.Size = new Size(149, 22);
            implementerToolStripMenuItem.Text = "Исполнители";
            implementerToolStripMenuItem.Click += ImplementerToolStripMenuItem_Click;
            // 
            // startingWorkToolStripMenuItem
            // 
            startingWorkToolStripMenuItem.Name = "startingWorkToolStripMenuItem";
            startingWorkToolStripMenuItem.Size = new Size(92, 20);
            startingWorkToolStripMenuItem.Text = "Запуск работ";
            startingWorkToolStripMenuItem.Click += StartingWorkToolStripMenuItem_Click;
            // 
            // createBackUpToolStripMenuItem
            // 
            createBackUpToolStripMenuItem.Name = "createBackUpToolStripMenuItem";
            createBackUpToolStripMenuItem.Size = new Size(97, 20);
            createBackUpToolStripMenuItem.Text = "Создать бекап";
            createBackUpToolStripMenuItem.Click += CreateBackUpToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1135, 338);
            Controls.Add(buttonRefresh);
            Controls.Add(buttonIssuedOrder);
            Controls.Add(buttonCreateOrder);
            Controls.Add(dataGridView);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 2, 3, 2);
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
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem workPiecesToolStripMenuItem;
        private ToolStripMenuItem workPieceFurnituresToolStripMenuItem;
        private ToolStripMenuItem ordersToolStripMenuItem;
        private ToolStripMenuItem workWithClientsToolStripMenuItem;
        private ToolStripMenuItem clientsToolStripMenuItem;
		private ToolStripMenuItem workWithImplementerToolStripMenuItem;
		private ToolStripMenuItem implementerToolStripMenuItem;
		private ToolStripMenuItem startingWorkToolStripMenuItem;
        private ToolStripMenuItem mailsToolStripMenuItem;
        private ToolStripMenuItem createBackUpToolStripMenuItem;
    }
}
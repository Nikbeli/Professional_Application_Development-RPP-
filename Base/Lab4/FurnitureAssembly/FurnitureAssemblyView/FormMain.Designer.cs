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
            buttonTakeOrderInWork = new Button();
            buttonOrderReady = new Button();
            buttonIssuedOrder = new Button();
            buttonRefresh = new Button();
            menuStrip = new MenuStrip();
            toolStripMenuItem = new ToolStripMenuItem();
            workPieceToolStripMenuItem = new ToolStripMenuItem();
            furnitureToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            workPiecesToolStripMenuItem = new ToolStripMenuItem();
            workPieceFurnituresToolStripMenuItem = new ToolStripMenuItem();
            ordersToolStripMenuItem = new ToolStripMenuItem();
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
            // buttonTakeOrderInWork
            // 
            buttonTakeOrderInWork.Location = new Point(887, 107);
            buttonTakeOrderInWork.Margin = new Padding(3, 2, 3, 2);
            buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
            buttonTakeOrderInWork.Size = new Size(206, 36);
            buttonTakeOrderInWork.TabIndex = 2;
            buttonTakeOrderInWork.Text = "Отдать на выполнение";
            buttonTakeOrderInWork.UseVisualStyleBackColor = true;
            buttonTakeOrderInWork.Click += ButtonTakeOrderInWork_Click;
            // 
            // buttonOrderReady
            // 
            buttonOrderReady.Location = new Point(887, 165);
            buttonOrderReady.Margin = new Padding(3, 2, 3, 2);
            buttonOrderReady.Name = "buttonOrderReady";
            buttonOrderReady.Size = new Size(206, 31);
            buttonOrderReady.TabIndex = 3;
            buttonOrderReady.Text = "Заказ готов";
            buttonOrderReady.UseVisualStyleBackColor = true;
            buttonOrderReady.Click += ButtonOrderReady_Click;
            // 
            // buttonIssuedOrder
            // 
            buttonIssuedOrder.Location = new Point(887, 217);
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
            buttonRefresh.Location = new Point(887, 269);
            buttonRefresh.Margin = new Padding(3, 2, 3, 2);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(206, 29);
            buttonRefresh.TabIndex = 5;
            buttonRefresh.Text = "Обновить";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += ButtonRef_Click;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem, reportsToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(5, 2, 0, 2);
            menuStrip.Size = new Size(1135, 24);
            menuStrip.TabIndex = 6;
            menuStrip.Text = "menuStrip";
            // 
            // toolStripMenuItem
            // 
            toolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { workPieceToolStripMenuItem, furnitureToolStripMenuItem });
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
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1135, 338);
            Controls.Add(buttonRefresh);
            Controls.Add(buttonIssuedOrder);
            Controls.Add(buttonOrderReady);
            Controls.Add(buttonTakeOrderInWork);
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
        private Button buttonTakeOrderInWork;
        private Button buttonOrderReady;
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
    }
}
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
            shopToolStripMenuItem = new ToolStripMenuItem();
            addFurnitureToolStripMenuItem = new ToolStripMenuItem();
            buttonSellFurniture = new Button();
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
            buttonCreateOrder.Location = new Point(887, 38);
            buttonCreateOrder.Margin = new Padding(3, 2, 3, 2);
            buttonCreateOrder.Name = "buttonCreateOrder";
            buttonCreateOrder.Size = new Size(216, 36);
            buttonCreateOrder.TabIndex = 1;
            buttonCreateOrder.Text = "Создать заказ";
            buttonCreateOrder.UseVisualStyleBackColor = true;
            buttonCreateOrder.Click += ButtonCreateOrder_Click;
            // 
            // buttonTakeOrderInWork
            // 
            buttonTakeOrderInWork.Location = new Point(887, 96);
            buttonTakeOrderInWork.Margin = new Padding(3, 2, 3, 2);
            buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
            buttonTakeOrderInWork.Size = new Size(216, 34);
            buttonTakeOrderInWork.TabIndex = 2;
            buttonTakeOrderInWork.Text = "Отдать на выполнение";
            buttonTakeOrderInWork.UseVisualStyleBackColor = true;
            buttonTakeOrderInWork.Click += ButtonTakeOrderInWork_Click;
            // 
            // buttonOrderReady
            // 
            buttonOrderReady.Location = new Point(887, 148);
            buttonOrderReady.Margin = new Padding(3, 2, 3, 2);
            buttonOrderReady.Name = "buttonOrderReady";
            buttonOrderReady.Size = new Size(216, 33);
            buttonOrderReady.TabIndex = 3;
            buttonOrderReady.Text = "Заказ готов";
            buttonOrderReady.UseVisualStyleBackColor = true;
            buttonOrderReady.Click += ButtonOrderReady_Click;
            // 
            // buttonIssuedOrder
            // 
            buttonIssuedOrder.Location = new Point(887, 201);
            buttonIssuedOrder.Margin = new Padding(3, 2, 3, 2);
            buttonIssuedOrder.Name = "buttonIssuedOrder";
            buttonIssuedOrder.Size = new Size(216, 32);
            buttonIssuedOrder.TabIndex = 4;
            buttonIssuedOrder.Text = "Заказ выдан";
            buttonIssuedOrder.UseVisualStyleBackColor = true;
            buttonIssuedOrder.Click += ButtonIssuedOrder_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(887, 250);
            buttonRefresh.Margin = new Padding(3, 2, 3, 2);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(216, 31);
            buttonRefresh.TabIndex = 5;
            buttonRefresh.Text = "Обновить";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += ButtonRefresh_Click;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(5, 2, 0, 2);
            menuStrip.Size = new Size(1135, 24);
            menuStrip.TabIndex = 6;
            menuStrip.Text = "menuStrip";
            // 
            // toolStripMenuItem
            // 
            toolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { workPieceToolStripMenuItem, furnitureToolStripMenuItem, shopToolStripMenuItem, addFurnitureToolStripMenuItem });
            toolStripMenuItem.Name = "toolStripMenuItem";
            toolStripMenuItem.Size = new Size(94, 20);
            toolStripMenuItem.Text = "Справочники";
            // 
            // workPieceToolStripMenuItem
            // 
            workPieceToolStripMenuItem.Name = "workPieceToolStripMenuItem";
            workPieceToolStripMenuItem.Size = new Size(198, 22);
            workPieceToolStripMenuItem.Text = "Заготовки";
            workPieceToolStripMenuItem.Click += WorkPieceToolStripMenuItem_Click;
            // 
            // furnitureToolStripMenuItem
            // 
            furnitureToolStripMenuItem.Name = "furnitureToolStripMenuItem";
            furnitureToolStripMenuItem.Size = new Size(198, 22);
            furnitureToolStripMenuItem.Text = "Изделия";
            furnitureToolStripMenuItem.Click += FurnitureToolStripMenuItem_Click;
            // 
            // shopToolStripMenuItem
            // 
            shopToolStripMenuItem.Name = "shopToolStripMenuItem";
            shopToolStripMenuItem.Size = new Size(198, 22);
            shopToolStripMenuItem.Text = "Магазины";
            shopToolStripMenuItem.Click += ShopToolStripMenuItem_Click;
            // 
            // addFurnitureToolStripMenuItem
            // 
            addFurnitureToolStripMenuItem.Name = "addFurnitureToolStripMenuItem";
            addFurnitureToolStripMenuItem.Size = new Size(198, 22);
            addFurnitureToolStripMenuItem.Text = "Пополнение магазина";
            addFurnitureToolStripMenuItem.Click += AddFurnitureToolStripMenuItem_Click;
            // 
            // buttonSellFurniture
            // 
            buttonSellFurniture.Location = new Point(887, 297);
            buttonSellFurniture.Margin = new Padding(3, 2, 3, 2);
            buttonSellFurniture.Name = "buttonSellFurniture";
            buttonSellFurniture.Size = new Size(216, 30);
            buttonSellFurniture.TabIndex = 8;
            buttonSellFurniture.Text = "Продажа изделий";
            buttonSellFurniture.UseVisualStyleBackColor = true;
            buttonSellFurniture.Click += ButtonSellFurniture_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1135, 338);
            Controls.Add(buttonSellFurniture);
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
        private ToolStripMenuItem shopToolStripMenuItem;
        private ToolStripMenuItem addFurnitureToolStripMenuItem;
        private Button buttonSellFurniture;
    }
}
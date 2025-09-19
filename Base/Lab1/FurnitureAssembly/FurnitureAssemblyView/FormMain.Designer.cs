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
            menuStrip1 = new MenuStrip();
            toolStripMenuItem = new ToolStripMenuItem();
            workPieceToolStripMenuItem = new ToolStripMenuItem();
            furnitureToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            menuStrip1.SuspendLayout();
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
            buttonCreateOrder.Location = new Point(1014, 67);
            buttonCreateOrder.Name = "buttonCreateOrder";
            buttonCreateOrder.Size = new Size(235, 46);
            buttonCreateOrder.TabIndex = 1;
            buttonCreateOrder.Text = "Создать заказ";
            buttonCreateOrder.UseVisualStyleBackColor = true;
            buttonCreateOrder.Click += ButtonCreateOrder_Click;
            // 
            // buttonTakeOrderInWork
            // 
            buttonTakeOrderInWork.Location = new Point(1014, 143);
            buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
            buttonTakeOrderInWork.Size = new Size(235, 48);
            buttonTakeOrderInWork.TabIndex = 2;
            buttonTakeOrderInWork.Text = "Отдать на выполнение";
            buttonTakeOrderInWork.UseVisualStyleBackColor = true;
            buttonTakeOrderInWork.Click += ButtonTakeOrderInWork_Click;
            // 
            // buttonOrderReady
            // 
            buttonOrderReady.Location = new Point(1014, 220);
            buttonOrderReady.Name = "buttonOrderReady";
            buttonOrderReady.Size = new Size(235, 41);
            buttonOrderReady.TabIndex = 3;
            buttonOrderReady.Text = "Заказ готов";
            buttonOrderReady.UseVisualStyleBackColor = true;
            buttonOrderReady.Click += ButtonOrderReady_Click;
            // 
            // buttonIssuedOrder
            // 
            buttonIssuedOrder.Location = new Point(1014, 289);
            buttonIssuedOrder.Name = "buttonIssuedOrder";
            buttonIssuedOrder.Size = new Size(235, 44);
            buttonIssuedOrder.TabIndex = 4;
            buttonIssuedOrder.Text = "Заказ выдан";
            buttonIssuedOrder.UseVisualStyleBackColor = true;
            buttonIssuedOrder.Click += ButtonIssuedOrder_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(1014, 359);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(235, 39);
            buttonRefresh.TabIndex = 5;
            buttonRefresh.Text = "Обновить";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += ButtonRef_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(1297, 30);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem
            // 
            toolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { workPieceToolStripMenuItem, furnitureToolStripMenuItem });
            toolStripMenuItem.Name = "toolStripMenuItem";
            toolStripMenuItem.Size = new Size(117, 24);
            toolStripMenuItem.Text = "Справочники";
            // 
            // workPieceToolStripMenuItem
            // 
            workPieceToolStripMenuItem.Name = "workPieceToolStripMenuItem";
            workPieceToolStripMenuItem.Size = new Size(224, 26);
            workPieceToolStripMenuItem.Text = "Заготовки";
            workPieceToolStripMenuItem.Click += WorkPieceToolStripMenuItem_Click;
            // 
            // furnitureToolStripMenuItem
            // 
            furnitureToolStripMenuItem.Name = "furnitureToolStripMenuItem";
            furnitureToolStripMenuItem.Size = new Size(224, 26);
            furnitureToolStripMenuItem.Text = "Изделия";
            furnitureToolStripMenuItem.Click += FurnitureToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1297, 451);
            Controls.Add(buttonRefresh);
            Controls.Add(buttonIssuedOrder);
            Controls.Add(buttonOrderReady);
            Controls.Add(buttonTakeOrderInWork);
            Controls.Add(buttonCreateOrder);
            Controls.Add(dataGridView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            Text = "Сборка мебели";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem;
        private ToolStripMenuItem workPieceToolStripMenuItem;
        private ToolStripMenuItem furnitureToolStripMenuItem;
    }
}
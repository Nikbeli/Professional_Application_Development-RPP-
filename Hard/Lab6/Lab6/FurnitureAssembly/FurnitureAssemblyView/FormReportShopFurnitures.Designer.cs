﻿namespace FurnitureAssemblyView
{
	partial class FormReportShopFurnitures
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
			buttonSaveToExcel = new Button();
			ColumnShop = new DataGridViewTextBoxColumn();
            ColumnFurniture = new DataGridViewTextBoxColumn();
			ColumnCount = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
			SuspendLayout();
			// 
			// dataGridView
			// 
			dataGridView.AllowUserToAddRows = false;
			dataGridView.AllowUserToDeleteRows = false;
			dataGridView.AllowUserToOrderColumns = true;
			dataGridView.AllowUserToResizeColumns = false;
			dataGridView.AllowUserToResizeRows = false;
			dataGridView.BackgroundColor = SystemColors.ControlLightLight;
			dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.Columns.AddRange(new DataGridViewColumn[] { ColumnShop, ColumnFurniture, ColumnCount });
			dataGridView.Dock = DockStyle.Bottom;
			dataGridView.Location = new Point(0, 63);
			dataGridView.Margin = new Padding(4, 5, 4, 5);
			dataGridView.MultiSelect = false;
			dataGridView.Name = "dataGridView";
			dataGridView.ReadOnly = true;
			dataGridView.RowHeadersVisible = false;
			dataGridView.RowHeadersWidth = 51;
			dataGridView.Size = new Size(704, 680);
			dataGridView.TabIndex = 0;
			// 
			// buttonSaveToExcel
			// 
			buttonSaveToExcel.Location = new Point(16, 18);
			buttonSaveToExcel.Margin = new Padding(4, 5, 4, 5);
			buttonSaveToExcel.Name = "buttonSaveToExcel";
			buttonSaveToExcel.Size = new Size(212, 35);
			buttonSaveToExcel.TabIndex = 1;
			buttonSaveToExcel.Text = "Сохранить в Excel";
			buttonSaveToExcel.UseVisualStyleBackColor = true;
			buttonSaveToExcel.Click += ButtonSaveToExcel_Click;
			// 
			// ColumnShop
			// 
			ColumnShop.HeaderText = "Магазин";
			ColumnShop.MinimumWidth = 6;
			ColumnShop.Name = "ColumnShop";
			ColumnShop.ReadOnly = true;
			ColumnShop.Width = 200;
            // 
            // ColumnFurniture
            // 
            ColumnFurniture.HeaderText = "Изделие";
            ColumnFurniture.MinimumWidth = 6;
			ColumnFurniture.Name = "ColumnFurniture";
            ColumnFurniture.ReadOnly = true;
            ColumnFurniture.Width = 200;
			// 
			// ColumnCount
			// 
			ColumnCount.HeaderText = "Количество";
			ColumnCount.MinimumWidth = 6;
			ColumnCount.Name = "ColumnCount";
			ColumnCount.ReadOnly = true;
			ColumnCount.Width = 125;
			// 
			// FormReportShopFurnitures
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(704, 743);
			Controls.Add(buttonSaveToExcel);
			Controls.Add(dataGridView);
			Margin = new Padding(4, 5, 4, 5);
			Name = "FormReportShopFurnitures";
			Text = "Загруженность магазинов";
			Load += FormReportShopFurnitures_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView dataGridView;
		private Button buttonSaveToExcel;
		private DataGridViewTextBoxColumn ColumnShop;
		private DataGridViewTextBoxColumn ColumnFurniture;
		private DataGridViewTextBoxColumn ColumnCount;
	}
}
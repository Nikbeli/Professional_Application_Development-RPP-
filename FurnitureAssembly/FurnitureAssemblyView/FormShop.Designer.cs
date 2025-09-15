namespace FurnitureAssemblyView
{
    partial class FormShop
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
            labelName = new Label();
            labelAddress = new Label();
            textBoxName = new TextBox();
            textBoxAddress = new TextBox();
            groupBoxIceCreams = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            ColumnFurnitureName = new DataGridViewTextBoxColumn();
            ColumnCount = new DataGridViewTextBoxColumn();
            buttonSave = new Button();
            buttonCancel = new Button();
            labelDate = new Label();
            dateTimePickerDate = new DateTimePicker();
            groupBoxIceCreams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(18, 10);
            labelName.Name = "labelName";
            labelName.Size = new Size(62, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Название:";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(266, 9);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(43, 15);
            labelAddress.TabIndex = 1;
            labelAddress.Text = "Адрес:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(86, 7);
            textBoxName.Margin = new Padding(3, 2, 3, 2);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(138, 23);
            textBoxName.TabIndex = 2;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(315, 6);
            textBoxAddress.Margin = new Padding(3, 2, 3, 2);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(138, 23);
            textBoxAddress.TabIndex = 3;
            // 
            // groupBoxIceCreams
            // 
            groupBoxIceCreams.Controls.Add(dataGridView);
            groupBoxIceCreams.Location = new Point(12, 62);
            groupBoxIceCreams.Margin = new Padding(3, 2, 3, 2);
            groupBoxIceCreams.Name = "groupBoxIceCreams";
            groupBoxIceCreams.Padding = new Padding(3, 2, 3, 2);
            groupBoxIceCreams.Size = new Size(720, 206);
            groupBoxIceCreams.TabIndex = 4;
            groupBoxIceCreams.TabStop = false;
            groupBoxIceCreams.Text = "Изделия";
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, ColumnFurnitureName, ColumnCount });
            dataGridView.Location = new Point(5, 20);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(709, 182);
            dataGridView.TabIndex = 0;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.Visible = false;
            // 
            // ColumnFurnitureName
            // 
            ColumnFurnitureName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnFurnitureName.HeaderText = "Изделие";
            ColumnFurnitureName.MinimumWidth = 6;
            ColumnFurnitureName.Name = "ColumnFurnitureName";
            ColumnFurnitureName.Resizable = DataGridViewTriState.True;
            // 
            // ColumnCount
            // 
            ColumnCount.HeaderText = "Количество";
            ColumnCount.MinimumWidth = 6;
            ColumnCount.Name = "ColumnCount";
            ColumnCount.Width = 125;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(389, 272);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(153, 36);
            buttonSave.TabIndex = 5;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(571, 272);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(147, 36);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(492, 9);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(90, 15);
            labelDate.TabIndex = 7;
            labelDate.Text = "Дата открытия:";
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Location = new Point(588, 7);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(127, 23);
            dateTimePickerDate.TabIndex = 9;
            // 
            // FormShop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 319);
            Controls.Add(dateTimePickerDate);
            Controls.Add(labelDate);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(groupBoxIceCreams);
            Controls.Add(textBoxAddress);
            Controls.Add(textBoxName);
            Controls.Add(labelAddress);
            Controls.Add(labelName);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormShop";
            Text = "Магазин";
            Load += FormShop_Load;
            groupBoxIceCreams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private Label labelAddress;
        private TextBox textBoxName;
        private TextBox textBoxAddress;
        private GroupBox groupBoxIceCreams;
        private DataGridView dataGridView;
        private Button buttonSave;
        private Button buttonCancel;
        private Label labelDate;
        private DateTimePicker dateTimePickerDate;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ColumnFurnitureName;
        private DataGridViewTextBoxColumn ColumnCount;
    }
}
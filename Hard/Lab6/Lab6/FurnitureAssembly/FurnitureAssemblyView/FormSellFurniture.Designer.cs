namespace FurnitureAssemblyView
{
    partial class FormSellFurniture
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
            labelFurniture = new Label();
            labelCount = new Label();
            comboBoxFurniture = new ComboBox();
            textBoxCount = new TextBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelFurniture
            // 
            labelFurniture.AutoSize = true;
            labelFurniture.Location = new Point(28, 24);
            labelFurniture.Name = "labelFurniture";
            labelFurniture.Size = new Size(56, 15);
            labelFurniture.TabIndex = 0;
            labelFurniture.Text = "Изделие:";
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Location = new Point(30, 64);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(75, 15);
            labelCount.TabIndex = 1;
            labelCount.Text = "Количество:";
            // 
            // comboBoxFurniture
            // 
            comboBoxFurniture.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFurniture.FormattingEnabled = true;
            comboBoxFurniture.Location = new Point(149, 24);
            comboBoxFurniture.Margin = new Padding(3, 2, 3, 2);
            comboBoxFurniture.Name = "comboBoxFurniture";
            comboBoxFurniture.Size = new Size(230, 23);
            comboBoxFurniture.TabIndex = 3;
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(149, 64);
            textBoxCount.Margin = new Padding(3, 2, 3, 2);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(230, 23);
            textBoxCount.TabIndex = 4;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(169, 102);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(101, 26);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(282, 102);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(97, 26);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // FormSellFurniture
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 135);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(textBoxCount);
            Controls.Add(comboBoxFurniture);
            Controls.Add(labelCount);
            Controls.Add(labelFurniture);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormSellFurniture";
            Text = "Продажа изделий";
            Load += FormSellFurniture_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelFurniture;
        private Label labelCount;
        private ComboBox comboBoxFurniture;
        private TextBox textBoxCount;
        private Button buttonSave;
        private Button buttonCancel;
    }
}
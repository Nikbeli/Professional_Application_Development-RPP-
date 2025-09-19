namespace FurnitureAssemblyView
{
    partial class FormWorkPiece
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelName = new Label();
            labelPrice = new Label();
            textBoxName = new TextBox();
            textBoxCost = new TextBox();
            buttonCancel = new Button();
            buttonSave = new Button();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(26, 18);
            labelName.Name = "labelName";
            labelName.Size = new Size(62, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Название:";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(26, 49);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(38, 15);
            labelPrice.TabIndex = 1;
            labelPrice.Text = "Цена:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(111, 16);
            textBoxName.Margin = new Padding(3, 2, 3, 2);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(257, 23);
            textBoxName.TabIndex = 2;
            // 
            // textBoxCost
            // 
            textBoxCost.Location = new Point(111, 46);
            textBoxCost.Margin = new Padding(3, 2, 3, 2);
            textBoxCost.Name = "textBoxCost";
            textBoxCost.Size = new Size(157, 23);
            textBoxCost.TabIndex = 3;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(289, 78);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(105, 26);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(171, 78);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(97, 26);
            buttonSave.TabIndex = 5;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // FormWorkPiece
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 115);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            Controls.Add(textBoxCost);
            Controls.Add(textBoxName);
            Controls.Add(labelPrice);
            Controls.Add(labelName);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormWorkPiece";
            Text = "Заготовка";
            Load += FormWorkPiece_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private Label labelPrice;
        private TextBox textBoxName;
        private TextBox textBoxCost;
        private Button buttonCancel;
        private Button buttonSave;
    }
}
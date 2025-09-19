namespace FurnitureAssemblyView
{
    partial class FormFurnitureWorkPiece
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
            labelWorkPiece = new Label();
            labelCount = new Label();
            comboBoxWorkPiece = new ComboBox();
            textBoxCount = new TextBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelWorkPiece
            // 
            labelWorkPiece.AutoSize = true;
            labelWorkPiece.Location = new Point(31, 33);
            labelWorkPiece.Name = "labelWorkPiece";
            labelWorkPiece.Size = new Size(81, 20);
            labelWorkPiece.TabIndex = 0;
            labelWorkPiece.Text = "Заготовка:";
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Location = new Point(31, 79);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(93, 20);
            labelCount.TabIndex = 1;
            labelCount.Text = "Количество:";
            // 
            // comboBoxWorkPiece
            // 
            comboBoxWorkPiece.FormattingEnabled = true;
            comboBoxWorkPiece.Location = new Point(156, 30);
            comboBoxWorkPiece.Name = "comboBoxWorkPiece";
            comboBoxWorkPiece.Size = new Size(320, 28);
            comboBoxWorkPiece.TabIndex = 2;
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(156, 76);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(320, 27);
            textBoxCount.TabIndex = 3;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(236, 118);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(110, 38);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(363, 118);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(113, 38);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // FormFurnitureWorkPiece
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 168);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(textBoxCount);
            Controls.Add(comboBoxWorkPiece);
            Controls.Add(labelCount);
            Controls.Add(labelWorkPiece);
            Name = "FormFurnitureWorkPiece";
            Text = "Заготовки для изделия";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelWorkPiece;
        private Label labelCount;
        private ComboBox comboBoxWorkPiece;
        private TextBox textBoxCount;
        private Button buttonSave;
        private Button buttonCancel;
    }
}
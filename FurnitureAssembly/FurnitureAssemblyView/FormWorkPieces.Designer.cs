namespace FurnitureAssemblyView
{
    partial class FormWorkPieces
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
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonRef = new Button();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(561, 27);
            buttonAdd.Margin = new Padding(3, 2, 3, 2);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(100, 38);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += ButtonAdd_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(561, 85);
            buttonUpdate.Margin = new Padding(3, 2, 3, 2);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(100, 36);
            buttonUpdate.TabIndex = 1;
            buttonUpdate.Text = "Изменить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += ButtonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(561, 143);
            buttonDelete.Margin = new Padding(3, 2, 3, 2);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(100, 34);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += ButtonDelete_Click;
            // 
            // buttonRef
            // 
            buttonRef.Location = new Point(561, 197);
            buttonRef.Margin = new Padding(3, 2, 3, 2);
            buttonRef.Name = "buttonRef";
            buttonRef.Size = new Size(100, 34);
            buttonRef.TabIndex = 3;
            buttonRef.Text = "Обновить";
            buttonRef.UseVisualStyleBackColor = true;
            buttonRef.Click += ButtonRefresh_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(10, 9);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(528, 320);
            dataGridView.TabIndex = 4;
            // 
            // FormWorkPieces
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(683, 338);
            Controls.Add(dataGridView);
            Controls.Add(buttonRef);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormWorkPieces";
            Text = "Заготовки";
            Load += FormWorkPiece_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonRef;
        private DataGridView dataGridView;
    }
}
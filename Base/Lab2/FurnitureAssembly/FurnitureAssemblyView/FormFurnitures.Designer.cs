namespace FurnitureAssemblyView
{
    partial class FormFurnitures
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
            buttonAdd.Location = new Point(640, 35);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(116, 50);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += ButtonAdd_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(640, 105);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(116, 50);
            buttonUpdate.TabIndex = 1;
            buttonUpdate.Text = "Изменить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += ButtonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(640, 175);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(116, 50);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += ButtonDelete_Click;
            // 
            // buttonRef
            // 
            buttonRef.Location = new Point(640, 245);
            buttonRef.Name = "buttonRef";
            buttonRef.Size = new Size(116, 50);
            buttonRef.TabIndex = 3;
            buttonRef.Text = "Обновить";
            buttonRef.UseVisualStyleBackColor = true;
            buttonRef.Click += ButtonRef_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(604, 426);
            dataGridView.TabIndex = 4;
            // 
            // FormFurnitures
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 450);
            Controls.Add(dataGridView);
            Controls.Add(buttonRef);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Name = "FormFurnitures";
            Text = "Изделия";
            Load += FormFurnitures_Load;
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
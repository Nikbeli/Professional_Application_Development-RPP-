namespace FurnitureAssemblyView
{
    partial class FormReportOrders
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
            panel = new Panel();
            buttonToPdf = new Button();
            buttonMake = new Button();
            label2 = new Label();
            label1 = new Label();
            dateTimePickerTo = new DateTimePicker();
            dateTimePickerFrom = new DateTimePicker();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Controls.Add(buttonToPdf);
            panel.Controls.Add(buttonMake);
            panel.Controls.Add(label2);
            panel.Controls.Add(label1);
            panel.Controls.Add(dateTimePickerTo);
            panel.Controls.Add(dateTimePickerFrom);
            panel.Dock = DockStyle.Top;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(1112, 51);
            panel.TabIndex = 0;
            // 
            // buttonToPdf
            // 
            buttonToPdf.Location = new Point(894, 10);
            buttonToPdf.Name = "buttonToPdf";
            buttonToPdf.Size = new Size(157, 29);
            buttonToPdf.TabIndex = 5;
            buttonToPdf.Text = "В Pdf";
            buttonToPdf.UseVisualStyleBackColor = true;
            buttonToPdf.Click += ButtonToPdf_Click;
            // 
            // buttonMake
            // 
            buttonMake.Location = new Point(612, 10);
            buttonMake.Name = "buttonMake";
            buttonMake.Size = new Size(157, 29);
            buttonMake.TabIndex = 4;
            buttonMake.Text = "Сформировать";
            buttonMake.UseVisualStyleBackColor = true;
            buttonMake.Click += ButtonMake_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(263, 17);
            label2.Name = "label2";
            label2.Size = new Size(27, 20);
            label2.TabIndex = 3;
            label2.Text = "по";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 17);
            label1.Name = "label1";
            label1.Size = new Size(18, 20);
            label1.TabIndex = 2;
            label1.Text = "С";
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Location = new Point(313, 12);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(169, 27);
            dateTimePickerTo.TabIndex = 1;
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Location = new Point(65, 12);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(176, 27);
            dateTimePickerFrom.TabIndex = 0;
            // 
            // FormReportOrders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1112, 450);
            Controls.Add(panel);
            Name = "FormReportOrders";
            Text = "Заказы";
            Load += FormReportOrders_Load;
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private Button buttonMake;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePickerTo;
        private DateTimePicker dateTimePickerFrom;
        private Button buttonToPdf;
    }
}
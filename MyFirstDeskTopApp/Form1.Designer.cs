namespace MyFirstDeskTopApp
{
    partial class MainFrame
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
            panel1 = new Panel();
            InsertBtn = new Button();
            Form1DataGrid = new DataGridView();
            ReloadData = new Button();
            ((System.ComponentModel.ISupportInitialize)Form1DataGrid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(1260, 768);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(219, 94);
            panel1.TabIndex = 0;
            // 
            // InsertBtn
            // 
            InsertBtn.Location = new Point(474, 28);
            InsertBtn.Margin = new Padding(3, 2, 3, 2);
            InsertBtn.Name = "InsertBtn";
            InsertBtn.Size = new Size(173, 67);
            InsertBtn.TabIndex = 1;
            InsertBtn.Text = "Insert Record";
            InsertBtn.UseVisualStyleBackColor = true;
            InsertBtn.Click += InsertBtn_Click;
            // 
            // Form1DataGrid
            // 
            Form1DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Form1DataGrid.Location = new Point(85, 141);
            Form1DataGrid.Name = "Form1DataGrid";
            Form1DataGrid.RowTemplate.Height = 25;
            Form1DataGrid.Size = new Size(359, 228);
            Form1DataGrid.TabIndex = 2;
            // 
            // ReloadData
            // 
            ReloadData.Location = new Point(474, 123);
            ReloadData.Margin = new Padding(3, 2, 3, 2);
            ReloadData.Name = "ReloadData";
            ReloadData.Size = new Size(173, 67);
            ReloadData.TabIndex = 3;
            ReloadData.Text = "Load Record";
            ReloadData.UseVisualStyleBackColor = true;
            ReloadData.Click += ReloadData_Click;
            // 
            // MainFrame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(695, 465);
            Controls.Add(ReloadData);
            Controls.Add(Form1DataGrid);
            Controls.Add(InsertBtn);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainFrame";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)Form1DataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button InsertBtn;
        private DataGridView Form1DataGrid;
        private Button ReloadData;
    }
}
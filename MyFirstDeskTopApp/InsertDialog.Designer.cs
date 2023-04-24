namespace MyFirstDeskTopApp
{
    partial class InsertDialog
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
            BuyerNameLabel = new Label();
            Add1label = new Label();
            PICNameLable = new Label();
            BuyerContactNoLabel = new Label();
            label4 = new Label();
            BuyerName = new TextBox();
            PICName = new TextBox();
            BuyerContact = new TextBox();
            BuyerAdd1 = new TextBox();
            BuyerAdd2 = new TextBox();
            InsertDataBtn = new Button();
            CancelBtn = new Button();
            SuspendLayout();
            // 
            // BuyerNameLabel
            // 
            BuyerNameLabel.AutoSize = true;
            BuyerNameLabel.Location = new Point(87, 49);
            BuyerNameLabel.Name = "BuyerNameLabel";
            BuyerNameLabel.Size = new Size(86, 20);
            BuyerNameLabel.TabIndex = 0;
            BuyerNameLabel.Text = "BuyerName";
            BuyerNameLabel.Click += label1_Click;
            // 
            // Add1label
            // 
            Add1label.AutoSize = true;
            Add1label.Location = new Point(87, 177);
            Add1label.Name = "Add1label";
            Add1label.Size = new Size(45, 20);
            Add1label.TabIndex = 1;
            Add1label.Text = "Add1";
            // 
            // PICNameLable
            // 
            PICNameLable.AutoSize = true;
            PICNameLable.Location = new Point(87, 89);
            PICNameLable.Name = "PICNameLable";
            PICNameLable.Size = new Size(70, 20);
            PICNameLable.TabIndex = 2;
            PICNameLable.Text = "PICName";
            PICNameLable.Click += label2_Click;
            // 
            // BuyerContactNoLabel
            // 
            BuyerContactNoLabel.AutoSize = true;
            BuyerContactNoLabel.Location = new Point(87, 130);
            BuyerContactNoLabel.Name = "BuyerContactNoLabel";
            BuyerContactNoLabel.Size = new Size(117, 20);
            BuyerContactNoLabel.TabIndex = 3;
            BuyerContactNoLabel.Text = "BuyerContactNo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(87, 220);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 4;
            label4.Text = "Add2";
            // 
            // BuyerName
            // 
            BuyerName.Location = new Point(246, 46);
            BuyerName.Name = "BuyerName";
            BuyerName.Size = new Size(279, 27);
            BuyerName.TabIndex = 5;
            // 
            // PICName
            // 
            PICName.Location = new Point(246, 86);
            PICName.Name = "PICName";
            PICName.Size = new Size(279, 27);
            PICName.TabIndex = 6;
            // 
            // BuyerContact
            // 
            BuyerContact.Location = new Point(246, 130);
            BuyerContact.Name = "BuyerContact";
            BuyerContact.Size = new Size(279, 27);
            BuyerContact.TabIndex = 7;
            // 
            // BuyerAdd1
            // 
            BuyerAdd1.Location = new Point(246, 177);
            BuyerAdd1.Name = "BuyerAdd1";
            BuyerAdd1.Size = new Size(279, 27);
            BuyerAdd1.TabIndex = 8;
            // 
            // BuyerAdd2
            // 
            BuyerAdd2.Location = new Point(246, 220);
            BuyerAdd2.Name = "BuyerAdd2";
            BuyerAdd2.Size = new Size(279, 27);
            BuyerAdd2.TabIndex = 9;
            // 
            // InsertDataBtn
            // 
            InsertDataBtn.Location = new Point(172, 291);
            InsertDataBtn.Name = "InsertDataBtn";
            InsertDataBtn.Size = new Size(94, 29);
            InsertDataBtn.TabIndex = 10;
            InsertDataBtn.Text = "Add User";
            InsertDataBtn.UseVisualStyleBackColor = true;
            InsertDataBtn.Click += InsertDataBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(369, 291);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(94, 29);
            CancelBtn.TabIndex = 11;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            // 
            // InsertDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 345);
            Controls.Add(CancelBtn);
            Controls.Add(InsertDataBtn);
            Controls.Add(BuyerAdd2);
            Controls.Add(BuyerAdd1);
            Controls.Add(BuyerContact);
            Controls.Add(PICName);
            Controls.Add(BuyerName);
            Controls.Add(label4);
            Controls.Add(BuyerContactNoLabel);
            Controls.Add(PICNameLable);
            Controls.Add(Add1label);
            Controls.Add(BuyerNameLabel);
            Name = "InsertDialog";
            Text = "Insert Buyer";
            Load += InsertDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button InsertDataBtn;
        private Label BuyerNameLabel;
        private Label Add1label;
        private Label PICNameLable;
        private Label BuyerContactNoLabel;
        private Label label4;
        private TextBox BuyerName;
        private TextBox PICName;
        private TextBox BuyerContact;
        private TextBox BuyerAdd1;
        private TextBox BuyerAdd2;
        private Button CancelBtn;
    }
}
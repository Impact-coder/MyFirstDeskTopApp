namespace MyFirstDeskTopApp
{
    partial class Form2
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
            DemoBtn = new Button();
            SuspendLayout();
            // 
            // DemoBtn
            // 
            DemoBtn.Location = new Point(301, 60);
            DemoBtn.Name = "DemoBtn";
            DemoBtn.Size = new Size(94, 29);
            DemoBtn.TabIndex = 0;
            DemoBtn.Text = "Demo Btn";
            DemoBtn.UseVisualStyleBackColor = true;
            DemoBtn.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DemoBtn);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private Button DemoBtn;
    }
}
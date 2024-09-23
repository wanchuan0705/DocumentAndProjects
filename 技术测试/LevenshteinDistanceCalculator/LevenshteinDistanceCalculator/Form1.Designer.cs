namespace LevenshteinDistanceCalculator
{
    partial class Form1
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
            btnSelectFile1 = new Button();
            btnSelectFile2 = new Button();
            lblResult = new Label();
            btnCalculate = new Button();
            txtFile1 = new TextBox();
            txtFile2 = new TextBox();
            SuspendLayout();
            // 
            // btnSelectFile1
            // 
            btnSelectFile1.Location = new Point(110, 64);
            btnSelectFile1.Name = "btnSelectFile1";
            btnSelectFile1.Size = new Size(97, 44);
            btnSelectFile1.TabIndex = 0;
            btnSelectFile1.Text = "Select File 1";
            btnSelectFile1.UseVisualStyleBackColor = true;
            btnSelectFile1.Click += btnSelectFile1_Click;
            // 
            // btnSelectFile2
            // 
            btnSelectFile2.Location = new Point(110, 123);
            btnSelectFile2.Name = "btnSelectFile2";
            btnSelectFile2.Size = new Size(97, 41);
            btnSelectFile2.TabIndex = 1;
            btnSelectFile2.Text = "Select File 2";
            btnSelectFile2.UseVisualStyleBackColor = true;
            btnSelectFile2.Click += btnSelectFile2_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(129, 271);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(43, 17);
            lblResult.TabIndex = 2;
            lblResult.Text = "Result";
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(110, 184);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(83, 40);
            btnCalculate.TabIndex = 5;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // txtFile1
            // 
            txtFile1.Location = new Point(282, 79);
            txtFile1.Name = "txtFile1";
            txtFile1.Size = new Size(100, 23);
            txtFile1.TabIndex = 6;
            txtFile1.Text = "Select File 1";
            // 
            // txtFile2
            // 
            txtFile2.Location = new Point(282, 132);
            txtFile2.Name = "txtFile2";
            txtFile2.Size = new Size(100, 23);
            txtFile2.TabIndex = 7;
            txtFile2.Text = "Select File 2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtFile2);
            Controls.Add(txtFile1);
            Controls.Add(btnCalculate);
            Controls.Add(lblResult);
            Controls.Add(btnSelectFile2);
            Controls.Add(btnSelectFile1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSelectFile1;
        private Button btnSelectFile2;
        private Label lblResult;
        private Button btnCalculate;
        private TextBox txtFile1;
        private TextBox txtFile2;
    }
}

namespace ResponsiveUIWinForm {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.startCalculcationButton = new System.Windows.Forms.Button();
            this.calculationResultLabel = new System.Windows.Forms.Label();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startCalculcationButton
            // 
            this.startCalculcationButton.Location = new System.Drawing.Point(106, 99);
            this.startCalculcationButton.Name = "startCalculcationButton";
            this.startCalculcationButton.Size = new System.Drawing.Size(75, 23);
            this.startCalculcationButton.TabIndex = 0;
            this.startCalculcationButton.Text = "button1";
            this.startCalculcationButton.UseVisualStyleBackColor = true;
            this.startCalculcationButton.Click += new System.EventHandler(this.startCalculcationButton_Click);
            // 
            // calculationResultLabel
            // 
            this.calculationResultLabel.AutoSize = true;
            this.calculationResultLabel.Location = new System.Drawing.Point(92, 165);
            this.calculationResultLabel.Name = "calculationResultLabel";
            this.calculationResultLabel.Size = new System.Drawing.Size(35, 13);
            this.calculationResultLabel.TabIndex = 1;
            this.calculationResultLabel.Text = "label1";
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(144, 206);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(100, 20);
            this.numberTextBox.TabIndex = 2;
            this.numberTextBox.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.calculationResultLabel);
            this.Controls.Add(this.startCalculcationButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startCalculcationButton;
        private System.Windows.Forms.Label calculationResultLabel;
        private System.Windows.Forms.TextBox numberTextBox;
    }
}



namespace RoboMate.View
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
            this.label2 = new System.Windows.Forms.Label();
            this.ramCheckBox = new System.Windows.Forms.CheckBox();
            this.disappearCheckBox = new System.Windows.Forms.CheckBox();
            this.idleCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.followCheckBox = new System.Windows.Forms.CheckBox();
            this.cpuCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sitCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.uploadFeedbackLabel = new System.Windows.Forms.Label();
            this.ramTextBox = new System.Windows.Forms.NumericUpDown();
            this.cpuTextBox = new System.Windows.Forms.NumericUpDown();
            this.idleTextBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ramTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idleTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "RAM usage threshold (%): ";
            // 
            // ramCheckBox
            // 
            this.ramCheckBox.AutoSize = true;
            this.ramCheckBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ramCheckBox.Location = new System.Drawing.Point(27, 16);
            this.ramCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ramCheckBox.Name = "ramCheckBox";
            this.ramCheckBox.Size = new System.Drawing.Size(133, 32);
            this.ramCheckBox.TabIndex = 2;
            this.ramCheckBox.Text = "RAM usage";
            this.ramCheckBox.UseVisualStyleBackColor = true;
            // 
            // disappearCheckBox
            // 
            this.disappearCheckBox.AutoSize = true;
            this.disappearCheckBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.disappearCheckBox.Location = new System.Drawing.Point(27, 145);
            this.disappearCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.disappearCheckBox.Name = "disappearCheckBox";
            this.disappearCheckBox.Size = new System.Drawing.Size(199, 32);
            this.disappearCheckBox.TabIndex = 3;
            this.disappearCheckBox.Text = "Random disappear";
            this.disappearCheckBox.UseVisualStyleBackColor = true;
            // 
            // idleCheckBox
            // 
            this.idleCheckBox.AutoSize = true;
            this.idleCheckBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.idleCheckBox.Location = new System.Drawing.Point(27, 187);
            this.idleCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.idleCheckBox.Name = "idleCheckBox";
            this.idleCheckBox.Size = new System.Drawing.Size(174, 32);
            this.idleCheckBox.TabIndex = 4;
            this.idleCheckBox.Text = "Bored when idle";
            this.idleCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Idle after (s): ";
            // 
            // followCheckBox
            // 
            this.followCheckBox.AutoSize = true;
            this.followCheckBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.followCheckBox.Location = new System.Drawing.Point(27, 248);
            this.followCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.followCheckBox.Name = "followCheckBox";
            this.followCheckBox.Size = new System.Drawing.Size(155, 32);
            this.followCheckBox.TabIndex = 6;
            this.followCheckBox.Text = "Follow mouse";
            this.followCheckBox.UseVisualStyleBackColor = true;
            // 
            // cpuCheckBox
            // 
            this.cpuCheckBox.AutoSize = true;
            this.cpuCheckBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cpuCheckBox.Location = new System.Drawing.Point(27, 79);
            this.cpuCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cpuCheckBox.Name = "cpuCheckBox";
            this.cpuCheckBox.Size = new System.Drawing.Size(127, 32);
            this.cpuCheckBox.TabIndex = 7;
            this.cpuCheckBox.Text = "CPU usage";
            this.cpuCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "CPU usage threshold (%):";
            // 
            // sitCheckBox
            // 
            this.sitCheckBox.AutoSize = true;
            this.sitCheckBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sitCheckBox.Location = new System.Drawing.Point(27, 291);
            this.sitCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sitCheckBox.Name = "sitCheckBox";
            this.sitCheckBox.Size = new System.Drawing.Size(194, 32);
            this.sitCheckBox.TabIndex = 9;
            this.sitCheckBox.Text = "Sit on top window";
            this.sitCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(232, 368);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(86, 31);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(27, 332);
            this.uploadButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(86, 55);
            this.uploadButton.TabIndex = 14;
            this.uploadButton.Text = "Upload new tileset";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // uploadFeedbackLabel
            // 
            this.uploadFeedbackLabel.AutoSize = true;
            this.uploadFeedbackLabel.Location = new System.Drawing.Point(14, 391);
            this.uploadFeedbackLabel.Name = "uploadFeedbackLabel";
            this.uploadFeedbackLabel.Size = new System.Drawing.Size(135, 20);
            this.uploadFeedbackLabel.TabIndex = 15;
            this.uploadFeedbackLabel.Text = "Successfull upload!\r\n";
            // 
            // ramTextBox
            // 
            this.ramTextBox.Location = new System.Drawing.Point(240, 51);
            this.ramTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ramTextBox.Name = "ramTextBox";
            this.ramTextBox.Size = new System.Drawing.Size(78, 27);
            this.ramTextBox.TabIndex = 16;
            // 
            // cpuTextBox
            // 
            this.cpuTextBox.Location = new System.Drawing.Point(240, 121);
            this.cpuTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cpuTextBox.Name = "cpuTextBox";
            this.cpuTextBox.Size = new System.Drawing.Size(78, 27);
            this.cpuTextBox.TabIndex = 17;
            // 
            // idleTextBox
            // 
            this.idleTextBox.Location = new System.Drawing.Point(240, 221);
            this.idleTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.idleTextBox.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.idleTextBox.Name = "idleTextBox";
            this.idleTextBox.Size = new System.Drawing.Size(78, 27);
            this.idleTextBox.TabIndex = 18;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 415);
            this.Controls.Add(this.idleTextBox);
            this.Controls.Add(this.cpuTextBox);
            this.Controls.Add(this.ramTextBox);
            this.Controls.Add(this.uploadFeedbackLabel);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.sitCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cpuCheckBox);
            this.Controls.Add(this.followCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idleCheckBox);
            this.Controls.Add(this.disappearCheckBox);
            this.Controls.Add(this.ramCheckBox);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form2";
            this.Text = "Configure RoboMate";
            ((System.ComponentModel.ISupportInitialize)(this.ramTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idleTextBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ramCheckBox;
        private System.Windows.Forms.CheckBox disappearCheckBox;
        private System.Windows.Forms.CheckBox idleCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox followCheckBox;
        private System.Windows.Forms.CheckBox cpuCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox sitCheckBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Label uploadFeedbackLabel;
        private System.Windows.Forms.NumericUpDown ramTextBox;
        private System.Windows.Forms.NumericUpDown cpuTextBox;
        private System.Windows.Forms.NumericUpDown idleTextBox;
    }
}
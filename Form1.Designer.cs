namespace WinFormsApp1
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
            buttonDownload = new Button();
            pictureBox = new PictureBox();
            textBoxBrightness = new TextBox();
            buttonBrightness = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // buttonDownload
            // 
            buttonDownload.Location = new Point(15, 9);
            buttonDownload.Name = "buttonDownload";
            buttonDownload.Size = new Size(154, 46);
            buttonDownload.TabIndex = 0;
            buttonDownload.Text = "Загрузить картинку";
            buttonDownload.UseVisualStyleBackColor = true;
            buttonDownload.Click += buttonDownload_Click;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(336, 16);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(400, 400);
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            // 
            // textBoxBrightness
            // 
            textBoxBrightness.Location = new Point(16, 74);
            textBoxBrightness.Name = "textBoxBrightness";
            textBoxBrightness.Size = new Size(125, 27);
            textBoxBrightness.TabIndex = 3;
            textBoxBrightness.Text = "50";
            // 
            // buttonBrightness
            // 
            buttonBrightness.Location = new Point(147, 73);
            buttonBrightness.Name = "buttonBrightness";
            buttonBrightness.Size = new Size(94, 29);
            buttonBrightness.TabIndex = 4;
            buttonBrightness.Text = "Изменить";
            buttonBrightness.UseVisualStyleBackColor = true;
            buttonBrightness.Click += buttonBrightness_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonBrightness);
            Controls.Add(textBoxBrightness);
            Controls.Add(pictureBox);
            Controls.Add(buttonDownload);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonDownload;
        private PictureBox pictureBox;
        private TextBox textBoxBrightness;
        private Button buttonBrightness;
    }
}

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
            labelBrightness = new Label();
            labelContrast = new Label();
            buttonContrast = new Button();
            textContrast = new TextBox();
            labelBinarization = new Label();
            buttonBinarization = new Button();
            textBoxBinarization = new TextBox();
            buttonConvert = new Button();
            buttonNegative = new Button();
            buttonReset = new Button();
            pictureBoxHistogram = new PictureBox();
            buttonShowHistogram = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHistogram).BeginInit();
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
            pictureBox.Location = new Point(570, 9);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(500, 500);
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            // 
            // textBoxBrightness
            // 
            textBoxBrightness.Location = new Point(198, 62);
            textBoxBrightness.Name = "textBoxBrightness";
            textBoxBrightness.Size = new Size(125, 27);
            textBoxBrightness.TabIndex = 3;
            textBoxBrightness.Text = "0";
            // 
            // buttonBrightness
            // 
            buttonBrightness.Location = new Point(327, 60);
            buttonBrightness.Name = "buttonBrightness";
            buttonBrightness.Size = new Size(94, 29);
            buttonBrightness.TabIndex = 4;
            buttonBrightness.Text = "Изменить";
            buttonBrightness.UseVisualStyleBackColor = true;
            buttonBrightness.Click += buttonBrightness_Click;
            // 
            // labelBrightness
            // 
            labelBrightness.AutoSize = true;
            labelBrightness.Location = new Point(12, 64);
            labelBrightness.Name = "labelBrightness";
            labelBrightness.Size = new Size(64, 20);
            labelBrightness.TabIndex = 5;
            labelBrightness.Text = "Яркость";
            // 
            // labelContrast
            // 
            labelContrast.AutoSize = true;
            labelContrast.Location = new Point(12, 98);
            labelContrast.Name = "labelContrast";
            labelContrast.Size = new Size(111, 20);
            labelContrast.TabIndex = 8;
            labelContrast.Text = "Контрастность";
            // 
            // buttonContrast
            // 
            buttonContrast.Location = new Point(327, 94);
            buttonContrast.Name = "buttonContrast";
            buttonContrast.Size = new Size(94, 29);
            buttonContrast.TabIndex = 7;
            buttonContrast.Text = "Изменить";
            buttonContrast.UseVisualStyleBackColor = true;
            buttonContrast.Click += buttonContrast_Click;
            // 
            // textContrast
            // 
            textContrast.Location = new Point(198, 95);
            textContrast.Name = "textContrast";
            textContrast.Size = new Size(125, 27);
            textContrast.TabIndex = 6;
            textContrast.Text = "0";
            // 
            // labelBinarization
            // 
            labelBinarization.AutoSize = true;
            labelBinarization.Location = new Point(12, 128);
            labelBinarization.Name = "labelBinarization";
            labelBinarization.Size = new Size(180, 20);
            labelBinarization.TabIndex = 11;
            labelBinarization.Text = "Порог для бинаризации";
            // 
            // buttonBinarization
            // 
            buttonBinarization.Location = new Point(327, 125);
            buttonBinarization.Name = "buttonBinarization";
            buttonBinarization.Size = new Size(94, 29);
            buttonBinarization.TabIndex = 10;
            buttonBinarization.Text = "Изменить";
            buttonBinarization.UseVisualStyleBackColor = true;
            buttonBinarization.Click += buttonBinarization_Click;
            // 
            // textBoxBinarization
            // 
            textBoxBinarization.Location = new Point(198, 125);
            textBoxBinarization.Name = "textBoxBinarization";
            textBoxBinarization.Size = new Size(125, 27);
            textBoxBinarization.TabIndex = 9;
            textBoxBinarization.Text = "0";
            // 
            // buttonConvert
            // 
            buttonConvert.Location = new Point(15, 164);
            buttonConvert.Name = "buttonConvert";
            buttonConvert.Size = new Size(154, 53);
            buttonConvert.TabIndex = 12;
            buttonConvert.Text = "Конвертировать в серый";
            buttonConvert.UseVisualStyleBackColor = true;
            buttonConvert.Click += buttonConvert_Click;
            // 
            // buttonNegative
            // 
            buttonNegative.Location = new Point(15, 223);
            buttonNegative.Name = "buttonNegative";
            buttonNegative.Size = new Size(154, 53);
            buttonNegative.TabIndex = 13;
            buttonNegative.Text = "Негатив";
            buttonNegative.UseVisualStyleBackColor = true;
            buttonNegative.Click += buttonNegative_Click;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(15, 282);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(154, 53);
            buttonReset.TabIndex = 14;
            buttonReset.Text = "Сбросить";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // pictureBoxHistogram
            // 
            pictureBoxHistogram.Location = new Point(15, 410);
            pictureBoxHistogram.Name = "pictureBoxHistogram";
            pictureBoxHistogram.Size = new Size(500, 500);
            pictureBoxHistogram.TabIndex = 15;
            pictureBoxHistogram.TabStop = false;
            // 
            // buttonShowHistogram
            // 
            buttonShowHistogram.Location = new Point(15, 341);
            buttonShowHistogram.Name = "buttonShowHistogram";
            buttonShowHistogram.Size = new Size(154, 53);
            buttonShowHistogram.TabIndex = 16;
            buttonShowHistogram.Text = "Гистограмма";
            buttonShowHistogram.UseVisualStyleBackColor = true;
            buttonShowHistogram.Click += buttonShowHistogram_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 923);
            Controls.Add(buttonShowHistogram);
            Controls.Add(pictureBoxHistogram);
            Controls.Add(buttonReset);
            Controls.Add(buttonNegative);
            Controls.Add(buttonConvert);
            Controls.Add(labelBinarization);
            Controls.Add(buttonBinarization);
            Controls.Add(textBoxBinarization);
            Controls.Add(labelContrast);
            Controls.Add(buttonContrast);
            Controls.Add(textContrast);
            Controls.Add(labelBrightness);
            Controls.Add(buttonBrightness);
            Controls.Add(textBoxBrightness);
            Controls.Add(pictureBox);
            Controls.Add(buttonDownload);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHistogram).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonDownload;
        private PictureBox pictureBox;
        private TextBox textBoxBrightness;
        private Button buttonBrightness;
        private Label labelBrightness;
        private Label labelContrast;
        private Button buttonContrast;
        private TextBox textContrast;
        private Label labelBinarization;
        private Button buttonBinarization;
        private TextBox textBoxBinarization;
        private Button buttonConvert;
        private Button buttonNegative;
        private Button buttonReset;
        private PictureBox pictureBoxHistogram;
        private Button buttonShowHistogram;
    }
}

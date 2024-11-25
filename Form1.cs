using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Bitmap _originalImage; // Оригинальное изображение
        private Bitmap _currentImage;  // Текущее изображение

        public Form1()
        {
            InitializeComponent();
            buttonBrightness.Click += buttonBrightness_Click; // Подписка на событие нажатия кнопки
            buttonContrast.Click += buttonContrast_Click; // Подписка на событие для контрастности
            buttonBinarization.Click += buttonBinarization_Click; // Подписка на событие для бинаризации
            buttonConvert.Click += buttonConvert_Click; // Подписка на событие для конвертации в серый
            buttonNegative.Click += buttonNegative_Click; // Подписка на событие для получения негатива
            buttonReset.Click += buttonReset_Click; // Подписка на событие для сброса эффектов
            buttonShowHistogram.Click += buttonShowHistogram_Click; // Подписка на событие для сброса эффектов
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _originalImage = new Bitmap(openFileDialog.FileName);
                    _currentImage = new Bitmap(_originalImage); // Начинаем с оригинала
                    pictureBox.Image = _currentImage; // Отображаем изображение
                }
            }
        }

        private void buttonBrightness_Click(object sender, EventArgs e)
        {
            if (_originalImage != null)
            {
                if (int.TryParse(textBoxBrightness.Text, out int brightness))
                {
                    brightness = Math.Max(-100, Math.Min(100, brightness));
                    _currentImage = AdjustBrightness(_originalImage, brightness);
                    pictureBox.Image = _currentImage; // Обновляем изображение
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректное число для яркости.");
                }
            }
        }

        private void buttonContrast_Click(object sender, EventArgs e)
        {
            if (_originalImage != null)
            {
                if (int.TryParse(textContrast.Text, out int contrast))
                {
                    contrast = Math.Max(-100, Math.Min(100, contrast));
                    _currentImage = AdjustContrast(_originalImage, contrast);
                    pictureBox.Image = _currentImage; // Обновляем изображение
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректное число для контрастности.");
                }
            }
        }

        private void buttonBinarization_Click(object sender, EventArgs e)
        {
            if (_originalImage != null)
            {
                if (byte.TryParse(textBoxBinarization.Text, out byte threshold))
                {
                    _currentImage = Binarization(_originalImage, threshold);
                    pictureBox.Image = _currentImage; // Обновляем изображение
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректное значение порога.");
                }
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (_originalImage != null)
            {
                _currentImage = ConvertToGrayscale(_originalImage);
                pictureBox.Image = _currentImage; // Обновляем изображение
            }
        }

        private unsafe Bitmap ConvertToGrayscale(Bitmap image)
        {
            Bitmap grayScaleBitmap = new Bitmap(image.Width, image.Height);

            BitmapData originalData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData grayScaleData = grayScaleBitmap.LockBits(new Rectangle(0, 0, grayScaleBitmap.Width, grayScaleBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            byte* originalPtr = (byte*)originalData.Scan0.ToPointer();
            byte* grayScalePtr = (byte*)grayScaleData.Scan0.ToPointer();

            for (int i = 0; i < originalData.Stride * image.Height; i += 4)
            {
                byte gray = (byte)(.299 * originalPtr[i + 2] + .587 * originalPtr[i + 1] + .114 * originalPtr[i]);
                grayScalePtr[i] = gray;         // Blue
                grayScalePtr[i + 1] = gray;       // Green
                grayScalePtr[i + 2] = gray;       // Red 
                grayScalePtr[i + 3] = 255;         // Alpha 
            }

            image.UnlockBits(originalData);
            grayScaleBitmap.UnlockBits(grayScaleData);

            return grayScaleBitmap;
        }

        private void buttonNegative_Click(object sender, EventArgs e)
        {
            if (_originalImage != null)
            {
                _currentImage = GetNegative(_originalImage);
                pictureBox.Image = _currentImage; // Обновляем изображение
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (_originalImage != null)
            {
                _currentImage = new Bitmap(_originalImage); // Возвращаемся к оригиналу
                pictureBox.Image = _currentImage;

                // Сбрасываем значения в текстовых полях (если есть)
                textBoxBrightness.Text = "0";
                textContrast.Text = "0";
                textBoxBinarization.Text = "0";

            }
        }

        private unsafe Bitmap AdjustBrightness(Bitmap image, int brightness)
        {
            Bitmap adjustedImage = new Bitmap(image.Width, image.Height);
            BitmapData originalData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData adjustedData = adjustedImage.LockBits(new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            byte* originalPtr = (byte*)originalData.Scan0.ToPointer();
            byte* adjustedPtr = (byte*)adjustedData.Scan0.ToPointer();

            float b = brightness / 100f;

            for (int i = 0; i < originalData.Stride * image.Height; i += 4)
            {
                int r = Clamp((int)((originalPtr[i]) * (1 + b)));
                int g = Clamp((int)((originalPtr[i + 1]) * (1 + b)));
                int bValue = Clamp((int)((originalPtr[i + 2]) * (1 + b)));

                adjustedPtr[i] = (byte)r;
                adjustedPtr[i + 1] = (byte)g;
                adjustedPtr[i + 2] = (byte)bValue;
                adjustedPtr[i + 3] = 255; // Альфа-канал без изменений
            }

            image.UnlockBits(originalData);
            adjustedImage.UnlockBits(adjustedData);

            return adjustedImage;
        }

        private unsafe Bitmap AdjustContrast(Bitmap image, int contrast)
        {
            Bitmap adjustedImage = new Bitmap(image.Width, image.Height);

            BitmapData originalData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData adjustedData = adjustedImage.LockBits(new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            byte* originalPtr = (byte*)originalData.Scan0.ToPointer();
            byte* adjustedPtr = (byte*)adjustedData.Scan0.ToPointer();

            double factor = (259 * (contrast + 255)) / (255 * (259 - contrast));

            for (int i = 0; i < originalData.Stride * image.Height; i += 4)
            {
                for (int j = 0; j < 3; j++) // RGB компоненты
                {
                    double newValue = factor * ((originalPtr[i + j]) - 128) + 128;
                    adjustedPtr[i + j] = (byte)Clamp((int)newValue);
                }

                adjustedPtr[i + 3] = originalPtr[i + 3]; // Альфа-канал без изменений
            }

            image.UnlockBits(originalData);
            adjustedImage.UnlockBits(adjustedData);

            return adjustedImage;
        }

        private unsafe Bitmap Binarization(Bitmap image, byte threshold)
        {
            Bitmap binarizedImage = new Bitmap(image.Width, image.Height);

            BitmapData originalData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData binarizedData = binarizedImage.LockBits(new Rectangle(0, 0, binarizedImage.Width, binarizedImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            byte* originalPtr = (byte*)originalData.Scan0.ToPointer();
            byte* binarizedPtr = (byte*)binarizedData.Scan0.ToPointer();

            for (int i = 0; i < originalData.Stride * image.Height; i += 4)
            {
                byte grayValue = (byte)((0.299 * originalPtr[i + 2]) + (0.587 * originalPtr[i + 1]) + (0.114 * originalPtr[i]));

                byte binaryValue = grayValue < threshold ? (byte)0 : (byte)255;

                binarizedPtr[i] = binaryValue;         // Blue
                binarizedPtr[i + 1] = binaryValue;         // Green
                binarizedPtr[i + 2] = binaryValue;         // Red
                binarizedPtr[i + 3] = originalPtr[i + 3]; // Альфа-канал без изменений
            }

            image.UnlockBits(originalData);
            binarizedImage.UnlockBits(binarizedData);

            return binarizedImage;
        }

        private unsafe Bitmap GetNegative(Bitmap image)
        {
            Bitmap negativeImage = new Bitmap(image.Width, image.Height);

            BitmapData originalData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData negativeData = negativeImage.LockBits(new Rectangle(0, 0, negativeImage.Width, negativeImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            byte* originalPtr = (byte*)originalData.Scan0.ToPointer();
            byte* negativePtr = (byte*)negativeData.Scan0.ToPointer();

            for (int i = 0; i < originalData.Stride * image.Height; i += 4)
            {
                negativePtr[i] = (byte)(255 - originalPtr[i]);          // Blue
                negativePtr[i + 1] = (byte)(255 - originalPtr[i + 1]);    // Green
                negativePtr[i + 2] = (byte)(255 - originalPtr[i + 2]);    // Red 
                negativePtr[i + 3] = originalPtr[i + 3];                 // Alpha 
            }

            image.UnlockBits(originalData);
            negativeImage.UnlockBits(negativeData);

            return negativeImage;
        }

        private void ResetEffects()
        {
            if (_originalImage != null)
            {
                _currentImage.Dispose();
                _currentImage = new Bitmap(_originalImage);
                pictureBox.Image = _currentImage;

                textBoxBrightness.Text = "0";
                textContrast.Text = "0";
                textBoxBinarization.Text = "128";
            }
        }

        private int Clamp(int value)
        {
            return Math.Max(0, Math.Min(255, value));
        }

        private void buttonShowHistogram_Click(object sender, EventArgs e)
        {
            if (_currentImage != null)
            {
                int[] histogram = CalculateHistogram(_currentImage);
                DrawHistogram(histogram);
            }
        }

        private int[] CalculateHistogram(Bitmap bitmap)
        {
            int[] histogram = new int[256];
            int width = bitmap.Width;
            int height = bitmap.Height;

            // Использование LockBits для повышения скорости доступа к пикселям
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height),
                                                     ImageLockMode.ReadOnly,
                                                     bitmap.PixelFormat);

            unsafe
            {
                byte* ptr = (byte*)bitmapData.Scan0; // Указатель на данных пикселей
                int bytesPerPixel = Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int pixelIndex = (y * bitmapData.Stride) + (x * bytesPerPixel);
                        byte R = ptr[pixelIndex + 2]; // Красный
                        byte G = ptr[pixelIndex + 1]; // Зеленый
                        byte B = ptr[pixelIndex]; // Синий

                        byte brightness = (byte)((0.299 * R) + (0.587 * G) + (0.114 * B));
                        histogram[brightness]++;
                    }
                }
            }

            // Освобождение ресурсов
            bitmap.UnlockBits(bitmapData);

            return histogram;
        }

        private void DrawHistogram(int[] histogram)
        {
            int histogramWidth = pictureBoxHistogram.Width;
            int histogramHeight = pictureBoxHistogram.Height;

            Bitmap histogramBitmap = new Bitmap(histogramWidth, histogramHeight);
            using (Graphics g = Graphics.FromImage(histogramBitmap))
            {
                g.Clear(Color.White);
                int maxFrequency = histogram.Max(); // Находим максимальную частоту

                for (int i = 0; i < histogram.Length; i++)
                {
                    int barHeight = (int)((double)histogram[i] / maxFrequency * histogramHeight);
                    g.FillRectangle(Brushes.Blue, i * (histogramWidth / histogram.Length), histogramHeight - barHeight, histogramWidth / histogram.Length, barHeight);
                }
            }

            pictureBoxHistogram.Image = histogramBitmap;
        }


    }
}
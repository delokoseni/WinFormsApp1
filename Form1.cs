using System.Drawing.Imaging;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Bitmap _originalImage; // Оригинальное изображение
        private Bitmap _currentImage;

        public Form1()
        {
            InitializeComponent();
            buttonBrightness.Click += buttonBrightness_Click; // Подписка на событие нажатия кнопки
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
                // Проверяем, является ли введенное значение числом
                if (int.TryParse(textBoxBrightness.Text, out int brightness))
                {
                    // Ограничиваем значение яркости в диапазоне от -100 до 100
                    brightness = Math.Max(-100, Math.Min(100, brightness));

                    // Изменяем яркость изображения
                    _currentImage = AdjustBrightness(_originalImage, brightness);
                    pictureBox.Image = _currentImage; // Обновляем изображение
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректное число для яркости.");
                }
            }
        }

        private unsafe Bitmap AdjustBrightness(Bitmap image, int brightness)
        {
            // Создаем новое изображение с теми же размерами
            Bitmap adjustedImage = new Bitmap(image.Width, image.Height);

            // Получаем доступ к пикселям исходного изображения
            BitmapData originalData = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            // Получаем доступ к пикселям нового изображения
            BitmapData adjustedData = adjustedImage.LockBits(
                new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);

            // Указатель на начало данных оригинального изображения
            byte* originalPtr = (byte*)originalData.Scan0.ToPointer();

            // Указатель на начало данных измененного изображения
            byte* adjustedPtr = (byte*)adjustedData.Scan0.ToPointer();

            // Преобразуем значение яркости в диапазон от -1 до 1
            float b = brightness / 100f;

            // Проходим по всем пикселям
            for (int i = 0; i < originalData.Stride * image.Height; i += 4)
            {
                // Получаем значения RGB для текущего пикселя
                int r = Clamp((int)((originalPtr[i]) * (1 + b)));
                int g = Clamp((int)((originalPtr[i + 1]) * (1 + b)));
                int bValue = Clamp((int)((originalPtr[i + 2]) * (1 + b)));

                // Устанавливаем новые значения RGB для изменённого пикселя
                adjustedPtr[i] = (byte)r;
                adjustedPtr[i + 1] = (byte)g;
                adjustedPtr[i + 2] = (byte)bValue;
                adjustedPtr[i + 3] = 255; // Оставляем альфа-канал без изменений
            }

            // Освобождаем заблокированные ресурсы
            image.UnlockBits(originalData);
            adjustedImage.UnlockBits(adjustedData);

            return adjustedImage;
        }

        private int Clamp(int value)
        {
            return Math.Max(0, Math.Min(255, value));
        }
    }
}
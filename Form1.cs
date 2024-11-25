using System.Drawing.Imaging;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Bitmap _originalImage; // ������������ �����������
        private Bitmap _currentImage;

        public Form1()
        {
            InitializeComponent();
            buttonBrightness.Click += buttonBrightness_Click; // �������� �� ������� ������� ������
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _originalImage = new Bitmap(openFileDialog.FileName);
                    _currentImage = new Bitmap(_originalImage); // �������� � ���������
                    pictureBox.Image = _currentImage; // ���������� �����������
                }
            }
        }

        private void buttonBrightness_Click(object sender, EventArgs e)
        {
            if (_originalImage != null)
            {
                // ���������, �������� �� ��������� �������� ������
                if (int.TryParse(textBoxBrightness.Text, out int brightness))
                {
                    // ������������ �������� ������� � ��������� �� -100 �� 100
                    brightness = Math.Max(-100, Math.Min(100, brightness));

                    // �������� ������� �����������
                    _currentImage = AdjustBrightness(_originalImage, brightness);
                    pictureBox.Image = _currentImage; // ��������� �����������
                }
                else
                {
                    MessageBox.Show("����������, ������� ���������� ����� ��� �������.");
                }
            }
        }

        private unsafe Bitmap AdjustBrightness(Bitmap image, int brightness)
        {
            // ������� ����� ����������� � ���� �� ���������
            Bitmap adjustedImage = new Bitmap(image.Width, image.Height);

            // �������� ������ � �������� ��������� �����������
            BitmapData originalData = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            // �������� ������ � �������� ������ �����������
            BitmapData adjustedData = adjustedImage.LockBits(
                new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);

            // ��������� �� ������ ������ ������������� �����������
            byte* originalPtr = (byte*)originalData.Scan0.ToPointer();

            // ��������� �� ������ ������ ����������� �����������
            byte* adjustedPtr = (byte*)adjustedData.Scan0.ToPointer();

            // ����������� �������� ������� � �������� �� -1 �� 1
            float b = brightness / 100f;

            // �������� �� ���� ��������
            for (int i = 0; i < originalData.Stride * image.Height; i += 4)
            {
                // �������� �������� RGB ��� �������� �������
                int r = Clamp((int)((originalPtr[i]) * (1 + b)));
                int g = Clamp((int)((originalPtr[i + 1]) * (1 + b)));
                int bValue = Clamp((int)((originalPtr[i + 2]) * (1 + b)));

                // ������������� ����� �������� RGB ��� ���������� �������
                adjustedPtr[i] = (byte)r;
                adjustedPtr[i + 1] = (byte)g;
                adjustedPtr[i + 2] = (byte)bValue;
                adjustedPtr[i + 3] = 255; // ��������� �����-����� ��� ���������
            }

            // ����������� ��������������� �������
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
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MemeMaker
{
    public partial class MainWindow : Window
    {
        private string filePath = @"C:/Users/" + Environment.GetEnvironmentVariable("UserName") + "/Desktop/meme.png";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            RenderTargetBitmap bitmap = new RenderTargetBitmap((int)Meme.ActualWidth, (int)Meme.ActualHeight, 96, 96, PixelFormats.Pbgra32);

            bitmap.Render(Meme);
            BitmapFrame frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);

            using (FileStream stream = File.Create(filePath))
            {
                encoder.Save(stream);
            }

            MessageBox.Show("El meme se exporto correctamente");
        }
    }
}

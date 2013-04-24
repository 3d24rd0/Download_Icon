using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Download_Icon
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ico temp;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            temp = new Ico(url.Text);
            icono.Source = temp.imagen;
            this.Icon = temp.imagen;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
               Microsoft.Win32.SaveFileDialog dialogo1 = new Microsoft.Win32.SaveFileDialog();
                    // dialogo1.ShowDialog();
                    dialogo1.AddExtension = false;
                    dialogo1.FileName = temp.host + ".ico";

                    if (dialogo1.ShowDialog() == true)
                    {
                        FileStream stream5 = new FileStream(dialogo1.FileName, FileMode.Create);
                        TiffBitmapEncoder encoder5 = new TiffBitmapEncoder();
                        encoder5.Frames.Add(BitmapFrame.Create(temp.imagen));
                        encoder5.Save(stream5);
                        stream5.Close();
                    }
        }

    }
}

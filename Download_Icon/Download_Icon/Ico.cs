using System;
using System.Windows.Media.Imaging;

namespace Download_Icon
{
    class Ico
    {
        public BitmapImage imagen { get; set; }
        private String ruta { get; set; }
        public String host { get; set; }
        public Ico(String ruta)
        {
            this.ruta = ruta;
            Dowload_ico();
        }
        private void Dowload_ico()
        {
            Uri a = new Uri(ruta, UriKind.RelativeOrAbsolute);
            host = a.Host;
            System.Windows.Media.Imaging.BitmapImage temp = new System.Windows.Media.Imaging.BitmapImage();
            ruta = ruta + "/favicon.ico";
            temp.BeginInit();
            temp.UriSource = new Uri(ruta, UriKind.RelativeOrAbsolute);
            temp.EndInit();
            imagen = temp;
        }
    }
}

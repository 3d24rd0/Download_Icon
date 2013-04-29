using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
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
            string rutatemp;
            if (ruta.StartsWith("http"))
            {
                this.ruta = ruta;
            }
            else
            {
                this.ruta = "http://" + ruta;
            }
            Uri a = new Uri(ruta, UriKind.RelativeOrAbsolute);
            host = a.Host;
            System.Windows.Media.Imaging.BitmapImage temp = new System.Windows.Media.Imaging.BitmapImage();
                using (WebClient client = new WebClient())
                {
                    string htmlCode = client.DownloadString(a);
                    String patch = null;
                    String urlaux = null;
                    foreach (Match match in Regex.Matches(htmlCode, "<base href=\"(.*?.*)\""))
                    {
                        urlaux = match.Groups[1].Value;
                    }
                    int cont = 0;
                    foreach (Match match in Regex.Matches(htmlCode, "<link rel=\"shortcut icon\" href=\"(.*?.*)\""))
                    {
                        patch = match.Groups[1].Value;
                        if (patch.StartsWith("http"))
                        {
                            rutatemp = patch;
                        }
                        else 
                        {
                            if (urlaux != null)
                            {
                                rutatemp = urlaux + "/" + patch;
                            }
                            else
                            {
                                rutatemp = ruta + "/" + patch;
                            }
                        }
                        a = new Uri(rutatemp, UriKind.RelativeOrAbsolute);
                        temp.BeginInit();
                        temp.DecodePixelWidth = 30;
                        temp.UriSource = a;
                        temp.EndInit();
                        cont++;
                    }
                    if (cont == 0)
                    {
                        foreach (Match match in Regex.Matches(htmlCode, "<link rel=\"icon\" href=\"(.*?.*)\""))
                        {
                            patch = match.Groups[1].Value;
                            if (patch.StartsWith("http"))
                            {
                                rutatemp = patch;
                            }
                            else
                            {
                                if (urlaux != null)
                                {
                                    rutatemp = urlaux + "/" + patch;
                                }
                                else
                                {
                                    rutatemp = ruta + "/" + patch;
                                }
                            }
                            a = new Uri(rutatemp, UriKind.RelativeOrAbsolute);
                            temp.BeginInit();
                            temp.DecodePixelWidth = 30;
                            temp.UriSource = a;
                            temp.EndInit();
                            cont++;
                        }
                    }
                    if (cont == 0)
                    {
                        rutatemp = ruta + "/favicon.ico";
                        temp.BeginInit();
                        temp.UriSource = new Uri(rutatemp, UriKind.RelativeOrAbsolute);
                        temp.EndInit();
                    }
                 }

             imagen = temp;
        }
    }
}

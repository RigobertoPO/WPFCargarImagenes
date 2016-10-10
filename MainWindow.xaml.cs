using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCargarImagenes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubirButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
             fd.Filter = "Archivos de imágen (.jpg)|*.jpg|All Files (*.*)|*.*";
             fd.Multiselect = false;
            bool? checarOK = fd.ShowDialog();
            if (checarOK == true)
           {
                 string archivoOrigen = fd.FileName;
                 //string rutaDestino = @"C:\";
                 string rutaAplicacion= System.Reflection.Assembly.GetExecutingAssembly().Location;
                int tamañoRuta=rutaAplicacion.Length;
                string rutaDestino = rutaAplicacion.Substring(0, tamañoRuta - 21);
                 string archivoDestino =  System.IO.Path.Combine(rutaDestino, fd.SafeFileName);
                 if(!System.IO.Directory.Exists(rutaDestino))
                   {
                    System.IO.Directory.CreateDirectory(rutaDestino);
                   }
                System.IO.File.Copy(archivoOrigen, archivoDestino, true);
            }
        }
    }
}

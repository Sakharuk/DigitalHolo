using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Drawing;
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
using DigitalHolo.Entities;
using DigitalHolo.Repositories;
using DigitalHolo.Converters;
using System.IO;
using Accord.Imaging.Converters;

namespace DigitalHolo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OutputImage inputInterferogramImage = new OutputImage();
        List<List<Complex>> interferogram = new List<List<Complex>>();

        public MainWindow()
        {
            InitializeComponent();
            inputInterferogramTab.DataContext = inputInterferogramImage;
        }
               
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string filePath ="";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.bmp, *.tiff)|*.bmp; *.tiff|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Assembly.GetExecutingAssembly().Location;

            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
            }

            tabName.Text = filePath;

            ReadImageToEntity(filePath);

            inputInterferogramImage.Data = new InterferogramRepository().ConvertInterferogramToByte(interferogram);
            
        }

        private void ReadImageToEntity(string filePath)
        {
            Bitmap image = new Bitmap(filePath);

            ImageToMatrix conv = new ImageToMatrix();
            double[,] res;
            conv.Convert(image, out res);
                     
            for (var i = 0; i < image.Height; i++)
            {
                interferogram.Add(new List<Complex>());

                for(var j = 0; j < image.Width; j++)
                {
                    var k = (i + 1) * j;
                    interferogram[i].Add(new Complex { Real = res[i , j] });
                }
            }
        }      
    }
}

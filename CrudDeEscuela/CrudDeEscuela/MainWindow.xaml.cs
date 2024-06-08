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

namespace CrudDeEscuela
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAlumnos_Click(object sender, RoutedEventArgs e)
        {
            ManejoDeAlumnos alumnos = new ManejoDeAlumnos();
            alumnos.Show();
            this.Close();
        }

        private void BtnCarreras_Click(object sender, RoutedEventArgs e)
        {
            ManejoDeCarreras carreras = new ManejoDeCarreras();
            carreras.Show();
            this.Close();
        }

        private void BtnNotas_Click(object sender, RoutedEventArgs e)
        {
            ManejoDePromedioDeNotas notas = new ManejoDePromedioDeNotas();
            notas.Show();
            this.Close();
        }

        private void BtnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            ManejoDeUsuarios usuarios = new ManejoDeUsuarios();
            usuarios.Show();
            this.Close();
        }
    }
}

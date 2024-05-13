using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Partidos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Juego> Juegos = new List<Juego>();
            Juegos.Add(new Juego { EquipoUno = "Barcelona", EquipoDos = "Real Madrid", PuntajeUno = 3, PuntajeDos = 2, Progreso = 85 });
            Juegos.Add(new Juego { EquipoUno = "PSG", EquipoDos = "Bayer Munich", PuntajeUno = 3, PuntajeDos = 5, Progreso = 55 });
            Juegos.Add(new Juego { EquipoUno = "BVB Dormunt", EquipoDos = "As Roma", PuntajeUno = 0, PuntajeDos = 1, Progreso = 25 });
            Juegos.Add(new Juego { EquipoUno = "Man United", EquipoDos = "Ajax", PuntajeUno = 1, PuntajeDos = 1, Progreso = 15 });

            lbJuego.ItemsSource = Juegos;
        }

        private void Boton_Click(object sender, RoutedEventArgs e)
        {
            if(lbJuego.SelectedItem != null)
            {
                MessageBox.Show($"Juego Seleccionado: {(lbJuego.SelectedItem as Juego).EquipoUno} " +
                    $"{(lbJuego.SelectedItem as Juego).PuntajeUno} {(lbJuego.SelectedItem as Juego).EquipoDos} " +
                    $"{(lbJuego.SelectedItem as Juego).PuntajeDos}");
            }
        }

        // Primera forma de guardar informacion de los partidos a un archivo de texto
        // cuando seleccionemos un juego y le demos al boton de guardar, toda la informacion
        // que se encuentra en la validacion del if si es verdadera, se guardara en un archivo de texto
        // que nosotros hayamos creado gracias a la clase StreamWriter
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // condicion para validar la seleccion de un partido para que se pueda guardar en un archivo de texto
            // en este caso el objeto a guardar no puede ser nulo
            if (lbJuego.SelectedItem != null)
            {
                // esto sera lo que guardara en el archivo de texto si el objeto(partido) no es nulo
                var partidoSeleccionado = $"Has seleccionado este partido: {(lbJuego.SelectedItem as Juego).EquipoUno} " +
                    $"{(lbJuego.SelectedItem as Juego).PuntajeUno} {(lbJuego.SelectedItem as Juego).EquipoDos} " +
                    $"{(lbJuego.SelectedItem as Juego).PuntajeDos}";

                MessageBox.Show($"{partidoSeleccionado}\n\nEsta informacion se guardara en un archivo de texto en la carpeta que contiene este proyecto.");

                // Guarda la información en un archivo de texto, indicandole el path del archivo que nosotros hemos creado en nuestro pc
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\ruben\OneDrive\Desktop\Semana11\Partidos\PartidosEnTexto.txt", true))
                {
                    file.WriteLine(partidoSeleccionado);
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un partido para poder generar un archivo de texto.");
            }
        }

        // Otra forma de guardar el archivo de texto pero esta vez con un cuadro de dialogo
        // que le ayudara al usuario saber en donde lo querra guardar y con que nombre dentro de su pc
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // condicion para validar la seleccion de un partido para que se pueda guardar en un archivo de texto
            // en este caso el objeto a guardar no puede ser nulo
            if (lbJuego.SelectedItem != null)
            {
                // esto sera lo que guardara en el archivo de texto si el objeto(partido) no es nulo
                var partidoSeleccionado = $"Has seleccionado este partido: {(lbJuego.SelectedItem as Juego).EquipoUno} " +
                    $"{(lbJuego.SelectedItem as Juego).PuntajeUno} {(lbJuego.SelectedItem as Juego).EquipoDos} " +
                    $"{(lbJuego.SelectedItem as Juego).PuntajeDos}";

                // nos aparecera un mensaje flotante con la informacion del partido antes de poder guardarlo
                MessageBox.Show($"{partidoSeleccionado}\n\nAhora puedes guardar esta informacion en un archivo de texto.");

                // Crear cuadro de diálogo para seleccionar archivos dentro de nuestra pc
                SaveFileDialog dlg = new SaveFileDialog();

                dlg.FileName = "PartidoSeleccionado"; // Nombre que tendra por defecto el archivo de texto
                
                dlg.DefaultExt = ".txt"; // Extensión para un archivo de texto
                
                dlg.Filter = "Text documents (.txt)|*.txt"; // Hacemos un filtro de archivos de tipo texto para mostrar solo archivos .txt al momento de guardarlo

                // Mostrar cuadro de diálogo que nos indicara en que carpeta o en que ubicacion guardaremos el archivo de los partidos
                bool? result = dlg.ShowDialog();

                // Si el usuario selecciona un archivo de texto cualquiera para almacenar el partido, este guarda la información del partido en el archivo seleccionado
                if (result == true)
                {
                    // Guarda la información en el archivo seleccionado
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(dlg.FileName, true))
                    {
                        // escribe una linea de texto en el archivo generado o seleccionado
                        file.WriteLine(partidoSeleccionado);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un partido para poder generar un archivo de texto.");
            }
        }
    }
}
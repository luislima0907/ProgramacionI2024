using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace CrudDeEscuela
{
    /// <summary>
    /// Lógica de interacción para ActualizarUsuarios.xaml
    /// </summary>
    public partial class ActualizarUsuarios : Window
    {
        // esta variable nos servira para guardar el id del usuario que venga desde otro formulario
        private int IdDelUsuarioDesdeOtraVentana;
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ActualizarUsuarios(int idUsuario)
        {
            InitializeComponent();
            IdDelUsuarioDesdeOtraVentana = idUsuario;

            // creamos una string de esta forma para poner dentro la cadena de conexion a nuestra base de datos
            // para crear la conexion se necesita el nombre del proyecto luego el metodo properties para acceder a sus propiedades
            // luego el metodo Settings para acceder a sus configuraciones y de ultimo el nombre que nos dio sql server al momento de crear la base de datos
            string miConexion = ConfigurationManager.ConnectionStrings["CrudDeEscuela.Properties.Settings.Sistema_De_EscuelaConnectionString"].ConnectionString;

            // instanciamos la conexion a nuestra base de datos, con el constructor
            // del parametro con la cadena de conexion
            miConexionSql = new SqlConnection(miConexion);
        }

        private void BtnActualizarUsuario_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres actualizar la informacion del usuario?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    // creamos una consulta parametrica para hacer posible la actualizacion de un registro
                    string consulta = $"UPDATE Usuario SET Nombre = @Nombre WHERE Id = {IdDelUsuarioDesdeOtraVentana}";// usamos el id que trajimos desde otra ventana
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("@Nombre", TxtActualizaUsuario.Text);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    MessageBox.Show($"Has actualizado al usuario con exito");
                    TxtActualizaUsuario.Text = "";
                    // this hace referencia a los objetos de una clase
                    this.Close();
                }
            }
        }

        private void BtnRegresarAVentanaUsuario_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

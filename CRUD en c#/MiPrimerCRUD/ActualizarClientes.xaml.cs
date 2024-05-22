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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MiPrimerCRUD
{
    /// <summary>
    /// Lógica de interacción para ActualizarClientes.xaml
    /// </summary>
    public partial class ActualizarClientes : Window
    {
        // esta variable nos servira para guardar el id del cliente que venga desde otro formulario
        private int IdDelClienteDesdeOtraVentana;
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;

        // al momento de iniciar el formulario, el constructor recibira el id del cliente como parametro para su estado inicial
        public ActualizarClientes(int IdCliente)
        {
            InitializeComponent();
            IdDelClienteDesdeOtraVentana = IdCliente;

            // creamos una string de esta forma para poner dentro la cadena de conexion a nuestra base de datos
            // para crear la conexion se necesita el nombre del proyecto luego el metodo properties para acceder a sus propiedades
            // luego el metodo Settings para acceder a sus configuraciones y de ultimo el nombre que nos dio sql server al momento de crear la base de datos
            string miConexion = ConfigurationManager.ConnectionStrings["MiPrimerCRUD.Properties.Settings.GestionDePedidosConnectionString"].ConnectionString;

            // instanciamos la conexion a nuestra base de datos, con el constructor
            // del parametro con la cadena de conexion
            miConexionSql = new SqlConnection(miConexion);

        }

        private void BtnActualizarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para hacer posible la actualizacion de un registro
                string consulta = $"UPDATE Cliente SET Nombre = @Nombre, Direccion = @Direccion, Poblacion = @Poblacion, Telefono = @Telefono WHERE Id = {IdDelClienteDesdeOtraVentana}";// usamos el id que trajimos desde otra ventana
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("@Nombre", TxtActualizaCliente.Text);
                miComandoSql.Parameters.AddWithValue("@Direccion", TxtActualizaDireccionCliente.Text);
                miComandoSql.Parameters.AddWithValue("@Poblacion", TxtActualizaPoblacionCliente.Text);
                miComandoSql.Parameters.AddWithValue("@Telefono", TxtActualizaTelefonoCliente.Text);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                MessageBox.Show($"Has actualizado al cliente con exito");
                TxtActualizaCliente.Text = "";
                // this hace referencia a los objetos de una clase
                this.Close();
            }
        }
    }
}

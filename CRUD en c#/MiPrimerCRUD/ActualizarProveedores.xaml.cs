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

namespace MiPrimerCRUD
{
    /// <summary>
    /// Lógica de interacción para ActualizarProveedores.xaml
    /// </summary>
    public partial class ActualizarProveedores : Window
    {
        private int IdDelProveedorDesdeOtraVentana;
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ActualizarProveedores(int idProveedor)
        {
            InitializeComponent();
            IdDelProveedorDesdeOtraVentana = idProveedor;
            // creamos una string de esta forma para poner dentro la cadena de conexion a nuestra base de datos
            // para crear la conexion se necesita el nombre del proyecto luego el metodo properties para acceder a sus propiedades
            // luego el metodo Settings para acceder a sus configuraciones y de ultimo el nombre que nos dio sql server al momento de crear la base de datos
            string miConexion = ConfigurationManager.ConnectionStrings["MiPrimerCRUD.Properties.Settings.GestionDePedidosConnectionString"].ConnectionString;

            // instanciamos la conexion a nuestra base de datos, con el constructor
            // del parametro con la cadena de conexion
            miConexionSql = new SqlConnection(miConexion);
        }

        private void BtnActualizarProveedor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para hacer posible la actualizacion de un registro
                string consulta = $"UPDATE Proveedor SET Nombre = @Nombre, Direccion = @Direccion, Telefono = @Telefono WHERE Id = {IdDelProveedorDesdeOtraVentana}";// usamos el id que trajimos desde otra ventana
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("@Nombre", TxtActualizaProveedor.Text);
                miComandoSql.Parameters.AddWithValue("@Direccion", TxtActualizaDireccionProveedor.Text);
                miComandoSql.Parameters.AddWithValue("@Telefono", TxtActualizaTelefonoProveedor.Text);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                MessageBox.Show($"Has actualizado al proveedor con exito");
                TxtActualizaProveedor.Text = "";
                TxtActualizaDireccionProveedor.Text = "";
                TxtActualizaTelefonoProveedor.Text = "";
                // this hace referencia a los objetos de una clase
                this.Close();
            }
        }
    }
}

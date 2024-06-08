using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    /// Lógica de interacción para ActualizarProducto.xaml
    /// </summary>
    public partial class ActualizarProducto : Window
    {
        // esta variable nos servira para guardar el id del producto que venga desde otro formulario
        private int IdDelProductoDesdeOtraVentana;
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;

        public ActualizarProducto(int IdProducto)
        {
            InitializeComponent();

            IdDelProductoDesdeOtraVentana = IdProducto;

            // creamos una string de esta forma para poner dentro la cadena de conexion a nuestra base de datos
            // para crear la conexion se necesita el nombre del proyecto luego el metodo properties para acceder a sus propiedades
            // luego el metodo Settings para acceder a sus configuraciones y de ultimo el nombre que nos dio sql server al momento de crear la base de datos
            string miConexion = ConfigurationManager.ConnectionStrings["MiPrimerCRUD.Properties.Settings.GestionDePedidosConnectionString"].ConnectionString;

            // instanciamos la conexion a nuestra base de datos, con el constructor
            // del parametro con la cadena de conexion
            miConexionSql = new SqlConnection(miConexion);

            try
            {
                // creamos una consulta para nuestra base de datos
                string consulta = "SELECT Nombre FROM Proveedor";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                // Creamos un DataTable para almacenar los resultados de la consulta
                DataTable dtProveedores = new DataTable();

                using (miAdaptadorSql)
                {
                    // Llenamos el DataTable con los resultados de la consulta
                    miAdaptadorSql.Fill(dtProveedores);

                    // Recorremos cada fila del DataTable
                    foreach (DataRow row in dtProveedores.Rows)
                    {
                        // Agregamos el nombre de la categoría al ComboBox
                        cboProveedores.Items.Add(row["Nombre"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void BtnActualizarProducto_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres actualizar la informacion del producto?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    // creamos una consulta parametrica para hacer posible la actualizacion de un registro
                    string consulta = $"UPDATE Articulo SET Seccion = @Seccion, NombreDelArticulo = @NombreDelArticulo, Precio = @Precio, PaisDeOrigen = @PaisDeOrigen, Proveedor = @Proveedor, Cantidad = @Cantidad WHERE Id = {IdDelProductoDesdeOtraVentana}";
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("@Seccion", TxtActualizaSeccionProducto.Text);
                    miComandoSql.Parameters.AddWithValue("@NombreDelArticulo", TxtActualizaProducto.Text);
                    miComandoSql.Parameters.AddWithValue("@Precio", TxtActualizaPrecioProducto.Text);
                    //miComandoSql.Parameters.AddWithValue("@Fecha", TxtActualizaFechaProducto.Text);
                    miComandoSql.Parameters.AddWithValue("@PaisDeOrigen", TxtActualizaOrigenProducto.Text);
                    miComandoSql.Parameters.AddWithValue("@Proveedor", cboProveedores.SelectedValue);
                    miComandoSql.Parameters.AddWithValue("@Cantidad", TxtActualizaCantidadProducto.Text);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    MessageBox.Show($"Has actualizado el producto con exito");
                    TxtActualizaSeccionProducto.Text = "";
                    TxtActualizaProducto.Text = "";
                    TxtActualizaPrecioProducto.Text = "";
                    //TxtActualizaFechaProducto.Text = "";
                    TxtActualizaOrigenProducto.Text = "";
                    cboProveedores.SelectedValue = null;
                    TxtActualizaCantidadProducto.Text = "";
                    // this hace referencia a los objetos de una clase
                    this.Close();
                }
            }
        }

        private void BtnRegresaAVentanaProducto_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

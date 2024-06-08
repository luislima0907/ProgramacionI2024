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
    /// Lógica de interacción para ActualizarVentas.xaml
    /// </summary>
    public partial class ActualizarVentas : Window
    {
        // esta variable nos servira para guardar el id de la venta que venga desde otro formulario
        private int IdDeLaVentaDesdeOtraVentana;
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;

        // al momento de iniciar el formulario, el constructor recibira el id de la venta como parametro para su estado inicial
        public ActualizarVentas(int idVenta)
        {
            InitializeComponent();
            IdDeLaVentaDesdeOtraVentana = idVenta;

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
                string consulta = "SELECT FormaDePago FROM Venta";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                // Creamos un DataTable para almacenar los resultados de la consulta
                DataTable dtFormaDePago = new DataTable();

                using (miAdaptadorSql)
                {
                    // Llenamos el DataTable con los resultados de la consulta
                    miAdaptadorSql.Fill(dtFormaDePago);

                    // Recorremos cada fila del DataTable
                    foreach (DataRow row in dtFormaDePago.Rows)
                    {
                        // Agregamos el nombre de la categoría al ComboBox
                        cboFormaDePago.Items.Add(row["FormaDePago"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                // creamos una consulta para nuestra base de datos
                string consulta = "SELECT NombreDelArticulo FROM Articulo";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                // Creamos un DataTable para almacenar los resultados de la consulta
                DataTable dtProducto = new DataTable();

                using (miAdaptadorSql)
                {
                    // Llenamos el DataTable con los resultados de la consulta
                    miAdaptadorSql.Fill(dtProducto);

                    // Recorremos cada fila del DataTable
                    foreach (DataRow row in dtProducto.Rows)
                    {
                        // Agregamos el nombre de la categoría al ComboBox
                        cboProducto.Items.Add(row["NombreDelArticulo"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                // creamos una consulta para nuestra base de datos
                string consulta = "SELECT Id FROM Cliente";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                // Creamos un DataTable para almacenar los resultados de la consulta
                DataTable dtIdCliente = new DataTable();

                using (miAdaptadorSql)
                {
                    // Llenamos el DataTable con los resultados de la consulta
                    miAdaptadorSql.Fill(dtIdCliente);

                    // Recorremos cada fila del DataTable
                    foreach (DataRow row in dtIdCliente.Rows)
                    {
                        // Agregamos el nombre de la categoría al ComboBox
                        cboIdCliente.Items.Add(row["Id"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnActualizarVenta_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres actualizar la informacion de la venta?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    // creamos una consulta parametrica para hacer posible la actualizacion de un registro
                    string consulta = $"UPDATE Venta SET CodigoDelCliente = @CodigoDelCliente, NombreDelCliente = @NombreDelCliente, FormaDePago = @FormaDePago, NombreDelProducto = @NombreDelProducto, CantidadDelProducto = @CantidadDelProducto, PrecioDelProducto = @PrecioDelProducto, Monto = @Monto, SubTotal = @SubTotal, MontoDeCambio = @MontoDeCambio WHERE Id = {IdDeLaVentaDesdeOtraVentana}";// usamos el id que trajimos desde otra ventana
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("@CodigoDelCliente", cboIdCliente.SelectedValue);
                    miComandoSql.Parameters.AddWithValue("@NombreDelCliente", txtNombreDelCliente.Text);
                    miComandoSql.Parameters.AddWithValue("@FormaDePago", cboFormaDePago.SelectedValue);
                    miComandoSql.Parameters.AddWithValue("@NombreDelProducto", cboProducto.SelectedValue);
                    miComandoSql.Parameters.AddWithValue("@CantidadDelProducto", txtCantidadDelProducto.Text);
                    miComandoSql.Parameters.AddWithValue("@PrecioDelProducto", txtPrecioDelProducto.Text);
                    miComandoSql.Parameters.AddWithValue("@Monto", txtMontoPago.Text);
                    miComandoSql.Parameters.AddWithValue("@SubTotal", txtSubTotal.Text);
                    miComandoSql.Parameters.AddWithValue("@MontoDeCambio", txtMontoCambio.Text);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    MessageBox.Show($"Has actualizado la venta con exito");
                    //TxtActualizaCliente.Text = "";
                    // this hace referencia a los objetos de una clase
                    this.Close();
                }
            }
        }

        private void cboIdCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Obtenemos el id del alumno seleccionado
            string IdDelClienteSeleccionado = cboIdCliente.SelectedItem.ToString();

            try
            {
                // Creamos una consulta para obtener los cursos de la carrera seleccionada
                string consulta = $"SELECT Nombre FROM Cliente WHERE Id = '{IdDelClienteSeleccionado}'";

                // Ejecutamos la consulta
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                DataTable dtClientes = new DataTable();
                miAdaptadorSql.Fill(dtClientes);

                // Verificamos que la consulta haya devuelto al menos un resultado
                if (dtClientes.Rows.Count > 0)
                {
                    // Asignamos los nombres de los cursos a los campos de texto
                    txtNombreDelCliente.Text = dtClientes.Rows[0]["Nombre"].ToString();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void cboProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Obtenemos el nombre del producto seleccionado
            string nombreDelProductoSeleccionado = cboProducto.SelectedItem.ToString();

            try
            {
                // Creamos una consulta para obtener el precio del producto seleccionado
                string consulta = $"SELECT Precio FROM Articulo WHERE NombreDelArticulo = '{nombreDelProductoSeleccionado}'";

                // Ejecutamos la consulta
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                DataTable dtProducto = new DataTable();
                miAdaptadorSql.Fill(dtProducto);

                // Mostramos el precio del producto en el campo de texto
                txtPrecioDelProducto.Text = dtProducto.Rows[0]["Precio"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtCantidadDelProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Verificar si el TextBox está vacío
                if (string.IsNullOrWhiteSpace(txtCantidadDelProducto.Text))
                {
                    return;
                }

                // Validar que solo se puedan escribir números
                int cantidad;
                if (!int.TryParse(txtCantidadDelProducto.Text, out cantidad))
                {
                    MessageBox.Show("Por favor, ingresa solo números.");
                    txtCantidadDelProducto.Text = "";
                    return;
                }

                // Validar que la cantidad no sea menor a 0
                if (cantidad < 0)
                {
                    MessageBox.Show("La cantidad no puede ser menor a 0.");
                    txtCantidadDelProducto.Text = "";
                    return;
                }

                // Obtenemos el nombre del producto seleccionado
                string nombreDelProductoSeleccionado = cboProducto.SelectedItem.ToString();

                try
                {
                    // Creamos una consulta para obtener la cantidad del producto seleccionado
                    string consulta = $"SELECT Cantidad FROM Articulo WHERE NombreDelArticulo = '{nombreDelProductoSeleccionado}'";

                    // Ejecutamos la consulta
                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtProducto = new DataTable();
                    miAdaptadorSql.Fill(dtProducto);

                    // Obtenemos la cantidad del producto en la base de datos
                    int cantidadEnBaseDeDatos = int.Parse(dtProducto.Rows[0]["Cantidad"].ToString());

                    // Validar que la cantidad ingresada no sea mayor a la cantidad del producto en la base de datos
                    if (cantidad > cantidadEnBaseDeDatos)
                    {
                        MessageBox.Show("La cantidad ingresada es mayor a la cantidad del producto disponible.");
                        txtCantidadDelProducto.Text = "";
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                try
                {
                    // Creamos una consulta para obtener el precio del producto seleccionado
                    string consulta = $"SELECT Precio FROM Articulo WHERE NombreDelArticulo = '{nombreDelProductoSeleccionado}'";

                    // Ejecutamos la consulta
                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtProducto = new DataTable();
                    miAdaptadorSql.Fill(dtProducto);

                    // Obtenemos el precio del producto
                    decimal precio = decimal.Parse(dtProducto.Rows[0]["Precio"].ToString());

                    // Calculamos el subtotal y lo mostramos en el campo de texto
                    decimal subTotal = cantidad * precio;
                    txtSubTotal.Text = subTotal.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void txtMontoPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Validar que solo se puedan escribir números
                decimal monto;
                if (!decimal.TryParse(txtMontoPago.Text, out monto))
                {
                    MessageBox.Show("Por favor, ingresa solo números.");
                    txtMontoPago.Text = "";
                    return;
                }

                // Obtenemos el subtotal
                decimal subtotal = decimal.Parse(txtSubTotal.Text);

                // Validar que el monto ingresado sea mayor o igual al subtotal
                if (monto < subtotal)
                {
                    MessageBox.Show("El monto ingresado es menor al subtotal.");
                    txtMontoPago.Text = "";
                    return;
                }

                // Calcular el cambio y mostrarlo en el campo de texto
                decimal cambio = monto - subtotal;
                txtMontoCambio.Text = cambio.ToString();
            }
        }

        private void BtnRegresarAVentanaVentas_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

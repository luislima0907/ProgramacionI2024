using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    /// Lógica de interacción para ManejoDeLasVentas.xaml
    /// </summary>
    public partial class ManejoDeLasVentas : Window
    {
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ManejoDeLasVentas()
        {
            InitializeComponent();
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

            muestraDeVentas();
        }

        private void muestraDeVentas()
        {
            try
            {
                // creamos una consulta calculada con concat para nuestra base de datos
                // concat nos sirve para concatenar la informacion de las columnas en una fila
                string consulta = "SELECT *, CONCAT('Id del Cliente: ', CodigoDelCliente, '   Fecha: ', FechaDelPedido, '   Forma de pago: ', FormaDePago, '   Nombre del producto: ', NombreDelProducto, '   Cantidad del Producto: ', CantidadDelProducto, '   Precio del Producto: ', PrecioDelProducto, '   Monto de Pago: ', Monto, '   SubTotal: ', SubTotal, '   Monto de Cambio: ', MontoDeCambio) AS InformacionCompletaDeLaVenta FROM Venta";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable tablaDeVentas = new DataTable();
                    miAdaptadorSql.Fill(tablaDeVentas);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ListaDeVentas.DisplayMemberPath = "InformacionCompletaDeLaVenta";

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeVentas.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeVentas.ItemsSource = tablaDeVentas.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnBorrarVenta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para hacer posible la eliminacion de un registro
                string consulta = "DELETE FROM Venta WHERE Id=@IdVenta";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("IdVenta", ListaDeVentas.SelectedValue);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeVentas();
                MessageBox.Show($"Has borrado la venta con exito");
            }
        }

        private void BtnRegresarAlInicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }

        private void BtnInsertarVenta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para insertar un registro
                string consulta = "INSERT INTO VENTA(CodigoDelCliente,FormaDePago,NombreDelProducto,Monto,CantidadDelProducto,SubTotal,PrecioDelProducto,MontoDeCambio) VALUES(@CodigoDelCliente,@FormaDePago,@NombreDelProducto,@Monto,@CantidadDelProducto,@SubTotal,@PrecioDelProducto,@MontoDeCambio)";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("CodigoDelCliente", cboIdCliente.SelectedValue);
                miComandoSql.Parameters.AddWithValue("FormaDePago", cboFormaDePago.SelectedValue);
                miComandoSql.Parameters.AddWithValue("NombreDelProducto", cboProducto.SelectedValue);
                //miComandoSql.Parameters.AddWithValue("Fecha", TxtInsertarFechaProducto.Text);
                miComandoSql.Parameters.AddWithValue("Monto", txtMontoPago.Text);
                miComandoSql.Parameters.AddWithValue("CantidadDelProducto", txtCantidadDelProducto.Text);
                miComandoSql.Parameters.AddWithValue("SubTotal", txtSubTotal.Text);
                miComandoSql.Parameters.AddWithValue("PrecioDelProducto", txtPrecioDelProducto.Text);
                miComandoSql.Parameters.AddWithValue("MontoDeCambio", txtMontoCambio.Text);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeVentas();
                MessageBox.Show($"Has insertado una venta con exito");
                cboProducto.SelectedValue = null;
                cboIdCliente.SelectedValue = null;
                cboFormaDePago.SelectedValue = null;
                txtMontoPago.Text = "";
                txtCantidadDelProducto.Text = "";
                txtSubTotal.Text = "";
                txtPrecioDelProducto.Text = "";
                txtMontoCambio.Text = "";
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

        private void txtCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
        //    // Verificar si el TextBox está vacío
        //    if (string.IsNullOrWhiteSpace(txtCantidadDelProducto.Text))
        //    {
        //        return;
        //    }

        //    // Validar que solo se puedan escribir números
        //    int cantidad;
        //    if (!int.TryParse(txtCantidadDelProducto.Text, out cantidad))
        //    {
        //        MessageBox.Show("Por favor, ingresa solo números.");
        //        txtCantidadDelProducto.Text = "";
        //        return;
        //    }

        //    // Validar que la cantidad no sea menor a 0
        //    if (cantidad < 0)
        //    {
        //        MessageBox.Show("La cantidad no puede ser menor a 0.");
        //        txtCantidadDelProducto.Text = "";
        //        return;
        //    }

        //    // Obtenemos el nombre del producto seleccionado
        //    string nombreDelProductoSeleccionado = cboProducto.SelectedItem.ToString();

        //    try
        //    {
        //        // Creamos una consulta para obtener la cantidad del producto seleccionado
        //        string consulta = $"SELECT Cantidad FROM Articulo WHERE NombreDelArticulo = '{nombreDelProductoSeleccionado}'";

        //        // Ejecutamos la consulta
        //        SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
        //        DataTable dtProducto = new DataTable();
        //        miAdaptadorSql.Fill(dtProducto);

        //        // Obtenemos la cantidad del producto en la base de datos
        //        int cantidadEnBaseDeDatos = int.Parse(dtProducto.Rows[0]["Cantidad"].ToString());

        //        // Validar que la cantidad ingresada no sea mayor a la cantidad del producto en la base de datos
        //        if (cantidad > cantidadEnBaseDeDatos)
        //        {
        //            MessageBox.Show("La cantidad ingresada es mayor a la cantidad del producto disponible.");
        //            txtCantidadDelProducto.Text = "";
        //            return;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

        //    try
        //    {
        //        // Creamos una consulta para obtener el precio del producto seleccionado
        //        string consulta = $"SELECT Precio FROM Articulo WHERE NombreDelArticulo = '{nombreDelProductoSeleccionado}'";

        //        // Ejecutamos la consulta
        //        SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
        //        DataTable dtProducto = new DataTable();
        //        miAdaptadorSql.Fill(dtProducto);

        //        // Obtenemos el precio del producto
        //        decimal precio = decimal.Parse(dtProducto.Rows[0]["Precio"].ToString());

        //        // Calculamos el subtotal y lo mostramos en el campo de texto
        //        decimal subTotal = cantidad * precio;
        //        txtSubTotal.Text = subTotal.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        }

        private void txtMontoPago_TextChanged(object sender, TextChangedEventArgs e)
        {
        //    // Validar que solo se puedan escribir números
        //    int monto;
        //    if (!int.TryParse(txtMontoPago.Text, out monto))
        //    {
        //        MessageBox.Show("Por favor, ingresa solo números.");
        //        txtMontoPago.Text = "";
        //        return;
        //    }

        //    // Obtenemos el subtotal
        //    int subtotal = int.Parse(txtSubTotal.Text);

        //    // Validar que el monto ingresado sea mayor o igual al subtotal
        //    if (monto < subtotal)
        //    {
        //        MessageBox.Show("El monto ingresado es menor al subtotal.");
        //        txtMontoPago.Text = "";
        //        return;
        //    }

        //    // Calcular el cambio y mostrarlo en el campo de texto
        //    int cambio = monto - subtotal;
        //    txtMontoCambio.Text = cambio.ToString();
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

        private void BtnGenerarReporteEnTexto_Click(object sender, RoutedEventArgs e)
        {
            if (ListaDeVentas.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)ListaDeVentas.SelectedItem;
                string informacionCompletaDeLaVentaSeleccionada = drv["InformacionCompletaDeLaVenta"].ToString();

                try
                {
                    string consulta = $"SELECT * FROM Venta WHERE CONCAT('Id del Cliente: ', CodigoDelCliente,  '   Fecha de la venta: ', FechaDelPedido, '   Forma de Pago: ', FormaDePago, '   Nombre del producto: ', NombreDelProducto, '   Cantidad del producto: ', CantidadDelProducto, '   Precio del producto: ', PrecioDelProducto, '   Monto de pago: ', Monto, '   SubTotal: ', SubTotal, '   Monto de Cambio: ', MontoDeCambio) = '{informacionCompletaDeLaVentaSeleccionada}'";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtVenta = new DataTable();
                    miAdaptadorSql.Fill(dtVenta);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(informacionCompletaDeLaVentaSeleccionada);

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDeLaVentaSeleccionada.txt", sb.ToString());

                    MessageBox.Show("El reporte de la venta seleccionada ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                try
                {
                    string consulta = "SELECT *, CONCAT('Id del Cliente: ', CodigoDelCliente,  '   Fecha de la venta: ', FechaDelPedido, '   Forma de Pago: ', FormaDePago, '   Nombre del producto: ', NombreDelProducto, '   Cantidad del producto: ', CantidadDelProducto, '   Precio del producto: ', PrecioDelProducto, '   Monto de pago: ', Monto, '   SubTotal: ', SubTotal, '   Monto de Cambio: ', MontoDeCambio) AS InformacionCompletaDeLaVenta FROM Venta";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtVenta = new DataTable();
                    miAdaptadorSql.Fill(dtVenta);

                    StringBuilder sb = new StringBuilder();

                    foreach (DataRow row in dtVenta.Rows)
                    {
                        sb.AppendLine(row["InformacionCompletaDeLaVenta"].ToString());
                    }

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDeVentas.txt", sb.ToString());

                    MessageBox.Show("El reporte de ventas ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}

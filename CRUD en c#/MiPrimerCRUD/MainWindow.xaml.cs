using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Data.SqlClient;
using System.Data;

namespace MiPrimerCRUD
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public MainWindow()
        {
            InitializeComponent();
            // creamos una string de esta forma para poner dentro la cadena de conexion a nuestra base de datos
            // para crear la conexion se necesita el nombre del proyecto luego el metodo properties para acceder a sus propiedades
            // luego el metodo Settings para acceder a sus configuraciones y de ultimo el nombre que nos dio sql server al momento de crear la base de datos
            string miConexion = ConfigurationManager.ConnectionStrings["MiPrimerCRUD.Properties.Settings.GestionDePedidosConnectionString"].ConnectionString;

            // instanciamos la conexion a nuestra base de datos, con el constructor
            // del parametro con la cadena de conexion
            miConexionSql = new SqlConnection(miConexion);

            muestraDeLosClientes();
            muestraDeVentas();
            muestraDeLosProductos();

        }

        // creamos un metodo para llamar los registros de nuestros clientes
        private void muestraDeLosClientes()
        {
            try
            {
                // creamos una consulta calculada con concat para nuestra base de datos
                // concat nos sirve para concatenar la informacion de las columnas en una fila
                string consulta = "SELECT *, CONCAT('Nombre: ', Nombre, ' Direccion: ', Direccion, ' Poblacion ', Poblacion, ' Telefono ', Telefono) AS InformacionCompletaDelCliente FROM Cliente";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable tablaDeClientes = new DataTable();
                    miAdaptadorSql.Fill(tablaDeClientes);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ListaDeClientes.DisplayMemberPath = "InformacionCompletaDelCliente";

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeClientes.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeClientes.ItemsSource = tablaDeClientes.DefaultView;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // creamos un metodo para llamar los registros de nuestros productos
        private void muestraDeLosProductos()
        {
            try
            {
                // creamos una consulta calculada con concat para nuestra base de datos
                // concat nos sirve para concatenar la informacion de las columnas en una fila
                string consulta = "SELECT *, CONCAT('Categoria: ', Seccion, ' Nombre: ', NombreDelArticulo, ' Precio: ', Precio, ' Fecha: ', Fecha, ' Origen: ', PaisDeOrigen) AS InformacionCompletaDelProducto FROM Articulo";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable tablaDeProductos = new DataTable();
                    miAdaptadorSql.Fill(tablaDeProductos);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ListaDeProductos.DisplayMemberPath = "InformacionCompletaDelProducto";

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeProductos.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeProductos.ItemsSource = tablaDeProductos.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void muestraDeVentas()
        {
            try
            {
                // creamos una consulta calculada con concat para nuestra base de datos
                // concat nos sirve para concatenar la informacion de las columnas en una fila
                string consulta = "SELECT *, CONCAT('Id del Cliente: ', CodigoDelCliente, ' Fecha: ', FechaDelPedido, ' Forma de pago: ', FormaDePago, ' Nombre del producto: ', NombreDelProducto, ' Monto Total: ', Monto) AS InformacionCompletaDeLaVenta FROM Venta";

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

        // este es un metodo opcional para mostrar las ventas por cada cliente
        //private void ListaDeClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //MessageBox.Show("Has hecho click en un cliente");
        //    muestraDeVentasPorCliente();
        //}

        //private void muestraDeVentasPorCliente()
        //{
        //    try
        //    {
        //        // creamos una consulta parametrica, es decir, una consulta que reciba un parametro para hacer posible la consulta
        //        // en este caso el parametro seria el nombre del cliente seleccionado al momento de darle click.
        //        // hacemos una consulta con inner join para relacionar los campos que tengan llaves foraneas y asi poder mostralos en la lista de ventas
        //        string consulta = "SELECT * FROM Venta V INNER JOIN Cliente C ON C.Id = V.CodigoDelCliente" +
        //            " WHERE C.Id = @IdCliente";

        //        // lo que hacemos con sqlComand es crear un objeto capaz de hacer consultas parametricas en nuestra base de datos
        //        SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);

        //        // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
        //        // y que lo ejecute en la conexion hacia nuestra base de datos
        //        SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(miComandoSql);

        //        using (miAdaptadorSql)
        //        {
        //            // lo que hacemos aqui es de que asignamos de donde viene el dato que seleccionamos para decirle de donde viene el parametro
        //            // de nuestra base de datos
        //            miComandoSql.Parameters.AddWithValue("@IdCliente", ListaDeClientes.SelectedValue);

        //            DataTable tablaDeVentas = new DataTable();
        //            miAdaptadorSql.Fill(tablaDeVentas);

        //            // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
        //            ListaDeVentasPorCliente.DisplayMemberPath = "FechaDelPedido";

        //            // seleccionamos el elemento de la tabla segun su id
        //            ListaDeVentasPorCliente.SelectedValuePath = "Id";

        //            // Especificamos de donde viene la informacion para llenarla en el listbox
        //            ListaDeVentasPorCliente.ItemsSource = tablaDeVentas.DefaultView;

        //        }
        //    }
        //    catch (Exception ex) 
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void ListaDeClientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    muestraDeVentasPorCliente();
        //}


        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void BtnBorrarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para hacer posible la eliminacion de un registro
                string consulta = "DELETE FROM Cliente WHERE Id = @IdCliente";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("IdCliente", ListaDeClientes.SelectedValue);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLosClientes();
                MessageBox.Show($"Has borrado ese cliente con exito");
            }
        }

        private void BtnInsertarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para hacer insertar un registro
                string consulta = "INSERT INTO CLIENTE(Nombre,Direccion,Poblacion,Telefono) VALUES(@Nombre,@Direccion,@Poblacion,@Telefono)";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("Nombre", TxtInsertarCliente.Text);
                miComandoSql.Parameters.AddWithValue("Direccion", TxtInsertarDireccionCliente.Text);
                miComandoSql.Parameters.AddWithValue("Poblacion", TxtInsertarPoblacionCliente.Text);
                miComandoSql.Parameters.AddWithValue("Telefono", TxtInsertarTelefonoCliente.Text);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLosClientes();
                MessageBox.Show($"Has insertado el cliente con exito");
                TxtInsertarCliente.Text = "";
                TxtInsertarDireccionCliente.Text = "";
                TxtInsertarPoblacionCliente.Text = "";
                TxtInsertarTelefonoCliente.Text = "";
            }
        }

        private void BtnActualizarCliente_Click(object sender, RoutedEventArgs e)
        {
            ActualizarClientes ventanaActualizar = new ActualizarClientes((int)ListaDeClientes.SelectedValue);

            try
            {
                string consulta = "SELECT Nombre,Direccion,Poblacion,Telefono FROM Cliente WHERE Id = @IdCliente";

                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(miComandoSql);

                using (miAdaptadorSql)
                {
                    miComandoSql.Parameters.AddWithValue("IdCliente", ListaDeClientes.SelectedValue);
                    DataTable tablaDeClientes = new DataTable();
                    miAdaptadorSql.Fill(tablaDeClientes);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ventanaActualizar.TxtActualizaCliente.Text = tablaDeClientes.Rows[0]["Nombre"].ToString();
                    ventanaActualizar.TxtActualizaDireccionCliente.Text = tablaDeClientes.Rows[0]["Direccion"].ToString();
                    ventanaActualizar.TxtActualizaPoblacionCliente.Text = tablaDeClientes.Rows[0]["Poblacion"].ToString();
                    ventanaActualizar.TxtActualizaTelefonoCliente.Text = tablaDeClientes.Rows[0]["Telefono"].ToString();

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeClientes.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeClientes.ItemsSource = tablaDeClientes.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            // ShowDialog lo que nos permite es de que pone la ventana en la que estemos en primer plano a nivel de programa
            // es decir, nos servira al momento de tener dos ventanas abiertas del mismo programa y no queramos que el usuario
            // salga de ahi hasta que la cierre o termine la tarea que se le solicita
            ventanaActualizar.ShowDialog();
            muestraDeLosClientes();
        }

        private void BtnInsertarProducto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para insertar un registro
                string consulta = "INSERT INTO ARTICULO(Seccion,NombreDelArticulo,Precio,PaisDeOrigen) VALUES(@Seccion,@NombreDelArticulo,@Precio,@PaisDeOrigen)";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("Seccion", TxtInsertarSeccionProducto.Text);
                miComandoSql.Parameters.AddWithValue("NombreDelArticulo", TxtInsertarProducto.Text);
                miComandoSql.Parameters.AddWithValue("Precio", TxtInsertarPrecioProducto.Text);
                //miComandoSql.Parameters.AddWithValue("Fecha", TxtInsertarFechaProducto.Text);
                miComandoSql.Parameters.AddWithValue("PaisDeOrigen", TxtInsertarOrigenProducto.Text);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLosProductos();
                MessageBox.Show($"Has insertado un producto con exito");
                TxtInsertarSeccionProducto.Text = "";
                TxtInsertarProducto.Text = "";
                TxtInsertarPrecioProducto.Text = "";
                //TxtInsertarFechaProducto.Text = "";
                TxtInsertarOrigenProducto.Text = "";
            }
        }

        private void BtnBorrarProducto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para hacer posible la eliminacion de un registro
                string consulta = "DELETE FROM Articulo WHERE Id = @IdProducto";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("IdProducto", ListaDeProductos.SelectedValue);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLosProductos();
                MessageBox.Show($"Has borrado el producto con exito");
            }
        }

        private void BtnActualizarProducto_Click(object sender, RoutedEventArgs e)
        {
            ActualizarProducto ventanaActualizar = new ActualizarProducto((int)ListaDeProductos.SelectedValue);

            try
            {
                string consulta = "SELECT Seccion,NombreDelArticulo,Precio,PaisDeOrigen FROM Articulo WHERE Id = @IdProducto";

                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(miComandoSql);

                using (miAdaptadorSql)
                {
                    miComandoSql.Parameters.AddWithValue("IdProducto", ListaDeProductos.SelectedValue);
                    DataTable tablaDeProductos = new DataTable();
                    miAdaptadorSql.Fill(tablaDeProductos);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ventanaActualizar.TxtActualizaSeccionProducto.Text = tablaDeProductos.Rows[0]["Seccion"].ToString();
                    ventanaActualizar.TxtActualizaProducto.Text = tablaDeProductos.Rows[0]["NombreDelArticulo"].ToString();
                    ventanaActualizar.TxtActualizaPrecioProducto.Text = tablaDeProductos.Rows[0]["Precio"].ToString();
                    //ventanaActualizar.TxtActualizaFechaProducto.Text = tablaDeProductos.Rows[0]["Fecha"].ToString();
                    ventanaActualizar.TxtActualizaOrigenProducto.Text = tablaDeProductos.Rows[0]["PaisDeOrigen"].ToString();

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeProductos.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeProductos.ItemsSource = tablaDeProductos.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            // ShowDialog lo que nos permite es de que pone la ventana en la que estemos en primer plano a nivel de programa
            // es decir, nos servira al momento de tener dos ventanas abiertas del mismo programa y no queramos que el usuario
            // salga de ahi hasta que la cierre o termine la tarea que se le solicita
            ventanaActualizar.ShowDialog();
            muestraDeLosProductos();
        }
    }
}

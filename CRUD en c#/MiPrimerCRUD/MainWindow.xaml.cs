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

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            ManejoDeClientes clientes = new ManejoDeClientes();
            this.Close();
            clientes.Show();
        }

        private void BtnProductos_Click(object sender, RoutedEventArgs e)
        {
            ManejoDeProductos productos = new ManejoDeProductos();
            this.Close();
            productos.Show();
        }

        private void BtnVentas_Click(object sender, RoutedEventArgs e)
        {
            ManejoDeLasVentas ventas = new ManejoDeLasVentas();
            this.Close();
            ventas.Show();
        }
    }
}

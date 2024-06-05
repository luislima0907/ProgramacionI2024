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
    /// Lógica de interacción para ManejoDeClientes.xaml
    /// </summary>
    public partial class ManejoDeClientes : Window
    {
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ManejoDeClientes()
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
        }

        // creamos un metodo para llamar los registros de nuestros clientes
        private void muestraDeLosClientes()
        {
            try
            {
                // creamos una consulta calculada con concat para nuestra base de datos
                // concat nos sirve para concatenar la informacion de las columnas en una fila
                string consulta = "SELECT *, CONCAT('Nombre: ', Nombre, '   Direccion: ', Direccion, '   Poblacion: ', Poblacion, '   Telefono: ', Telefono) AS InformacionCompletaDelCliente FROM Cliente";

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

        private void BtnRegresarAlInicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }

        private void BtnGenerarReporteEnTexto_Click(object sender, RoutedEventArgs e)
        {
            if (ListaDeClientes.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)ListaDeClientes.SelectedItem;
                string informacionCompletaDelClienteSeleccionado = drv["InformacionCompletaDelCliente"].ToString();

                try
                {
                    string consulta = $"SELECT * FROM Cliente WHERE CONCAT('Nombre: ', Nombre, '   Direccion: ', Direccion, '   Poblacion: ', Poblacion, '   Telefono: ', Telefono) = '{informacionCompletaDelClienteSeleccionado}'";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtProducto = new DataTable();
                    miAdaptadorSql.Fill(dtProducto);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(informacionCompletaDelClienteSeleccionado);

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDelClienteSeleccionado.txt", sb.ToString());

                    MessageBox.Show("El reporte del cliente seleccionado ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
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
                    string consulta = "SELECT *, CONCAT('Nombre: ', Nombre, '   Direccion: ', Direccion, '   Poblacion: ', Poblacion, '   Telefono: ', Telefono) AS InformacionCompletaDelCliente FROM Cliente";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtClientes = new DataTable();
                    miAdaptadorSql.Fill(dtClientes);

                    StringBuilder sb = new StringBuilder();

                    foreach (DataRow row in dtClientes.Rows)
                    {
                        sb.AppendLine(row["InformacionCompletaDelCliente"].ToString());
                    }

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDeClientes.txt", sb.ToString());

                    MessageBox.Show("El reporte de los clientes ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}

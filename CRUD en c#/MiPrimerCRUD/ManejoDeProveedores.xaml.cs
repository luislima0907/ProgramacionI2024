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
    /// Lógica de interacción para ManejoDeProveedores.xaml
    /// </summary>
    public partial class ManejoDeProveedores : Window
    {
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ManejoDeProveedores()
        {
            InitializeComponent();
            // creamos una string de esta forma para poner dentro la cadena de conexion a nuestra base de datos
            // para crear la conexion se necesita el nombre del proyecto luego el metodo properties para acceder a sus propiedades
            // luego el metodo Settings para acceder a sus configuraciones y de ultimo el nombre que nos dio sql server al momento de crear la base de datos
            string miConexion = ConfigurationManager.ConnectionStrings["MiPrimerCRUD.Properties.Settings.GestionDePedidosConnectionString"].ConnectionString;

            // instanciamos la conexion a nuestra base de datos, con el constructor
            // del parametro con la cadena de conexion
            miConexionSql = new SqlConnection(miConexion);
            muestraDeLosProveedores();
        }

        private void muestraDeLosProveedores()
        {
            try
            {
                // creamos una consulta calculada con concat para nuestra base de datos
                // concat nos sirve para concatenar la informacion de las columnas en una fila
                string consulta = "SELECT *, CONCAT('Nombre: ', Nombre, '   Direccion: ', Direccion, '   Telefono: ', Telefono) AS InformacionCompletaDelProveedor FROM Proveedor";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable tablaDeProveedores = new DataTable();
                    miAdaptadorSql.Fill(tablaDeProveedores);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ListaDeProveedores.DisplayMemberPath = "InformacionCompletaDelProveedor";

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeProveedores.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeProveedores.ItemsSource = tablaDeProveedores.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnActualizarProveedor_Click(object sender, RoutedEventArgs e)
        {
            ActualizarProveedores ventanaActualizar = new ActualizarProveedores((int)ListaDeProveedores.SelectedValue);

            try
            {
                string consulta = "SELECT Nombre,Direccion,Telefono FROM Proveedor WHERE Id = @IdProveedor";

                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(miComandoSql);

                using (miAdaptadorSql)
                {
                    miComandoSql.Parameters.AddWithValue("IdProveedor", ListaDeProveedores.SelectedValue);
                    DataTable tablaDeProveedores = new DataTable();
                    miAdaptadorSql.Fill(tablaDeProveedores);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ventanaActualizar.TxtActualizaProveedor.Text = tablaDeProveedores.Rows[0]["Nombre"].ToString();
                    ventanaActualizar.TxtActualizaDireccionProveedor.Text = tablaDeProveedores.Rows[0]["Direccion"].ToString();
                    ventanaActualizar.TxtActualizaTelefonoProveedor.Text = tablaDeProveedores.Rows[0]["Telefono"].ToString();

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeProveedores.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeProveedores.ItemsSource = tablaDeProveedores.DefaultView;
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
            muestraDeLosProveedores();
        }

        private void BtnBorrarProveedor_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres borrar al proveedor seleccionado?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    // creamos una consulta parametrica para hacer posible la eliminacion de un registro
                    string consulta = "DELETE FROM Proveedor WHERE Id = @IdProveedor";
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("IdProveedor", ListaDeProveedores.SelectedValue);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    muestraDeLosProveedores();
                    MessageBox.Show($"Has borrado ese proveedor con exito");
                }
            }
        }

        private void BtnInsertarProveedor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para hacer insertar un registro
                string consulta = "INSERT INTO PROVEEDOR(Nombre,Direccion,Telefono) VALUES(@Nombre,@Direccion,@Telefono)";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("Nombre", TxtInsertarProveedor.Text);
                miComandoSql.Parameters.AddWithValue("Direccion", TxtInsertarDireccionProveedor.Text);
                miComandoSql.Parameters.AddWithValue("Telefono", TxtInsertarTelefonoProveedor.Text);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLosProveedores();
                MessageBox.Show($"Has insertado el proveedor con exito");
                TxtInsertarProveedor.Text = "";
                TxtInsertarDireccionProveedor.Text = "";
                TxtInsertarTelefonoProveedor.Text = "";
            }
        }

        private void BtnRegresarAlMenuProductos_Click(object sender, RoutedEventArgs e)
        {
            ManejoDeProductos productos = new ManejoDeProductos();
            productos.Show();
            this.Close();
        }

        private void BtnAyuda_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnGenerarReporteEnTexto_Click(object sender, RoutedEventArgs e)
        {
            if (ListaDeProveedores.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)ListaDeProveedores.SelectedItem;
                string informacionCompletaDelProveedorSeleccionado = drv["InformacionCompletaDelProveedor"].ToString();

                try
                {
                    string consulta = $"SELECT * FROM Cliente WHERE CONCAT('Nombre: ', Nombre, '   Direccion: ', Direccion, '   Poblacion: ', Poblacion, '   Telefono: ', Telefono) = '{informacionCompletaDelProveedorSeleccionado}'";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtProveedor = new DataTable();
                    miAdaptadorSql.Fill(dtProveedor);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(informacionCompletaDelProveedorSeleccionado);

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDelProveedorSeleccionado.txt", sb.ToString());

                    MessageBox.Show("El reporte del proveedor seleccionado ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
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
                    string consulta = "SELECT *, CONCAT('Nombre: ', Nombre, '   Direccion: ', Direccion, '   Telefono: ', Telefono) AS InformacionCompletaDelProveedor FROM Proveedor";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtProveedor = new DataTable();
                    miAdaptadorSql.Fill(dtProveedor);

                    StringBuilder sb = new StringBuilder();

                    foreach (DataRow row in dtProveedor.Rows)
                    {
                        sb.AppendLine(row["InformacionCompletaDelProveedor"].ToString());
                    }

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDeProveedores.txt", sb.ToString());

                    MessageBox.Show("El reporte de los proveedores ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}

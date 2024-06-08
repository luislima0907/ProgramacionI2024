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

namespace CrudDeEscuela
{
    /// <summary>
    /// Lógica de interacción para ManejoDeUsuarios.xaml
    /// </summary>
    public partial class ManejoDeUsuarios : Window
    {
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ManejoDeUsuarios()
        {
            InitializeComponent();
            // creamos una string de esta forma para poner dentro la cadena de conexion a nuestra base de datos
            // para crear la conexion se necesita el nombre del proyecto luego el metodo properties para acceder a sus propiedades
            // luego el metodo Settings para acceder a sus configuraciones y de ultimo el nombre que nos dio sql server al momento de crear la base de datos
            string miConexion = ConfigurationManager.ConnectionStrings["CrudDeEscuela.Properties.Settings.Sistema_De_EscuelaConnectionString"].ConnectionString;

            // instanciamos la conexion a nuestra base de datos, con el constructor
            // del parametro con la cadena de conexion
            miConexionSql = new SqlConnection(miConexion);
            muestraDeLosUsuarios();
        }

        private void muestraDeLosUsuarios()
        {
            try
            {
                // creamos una consulta calculada con concat para nuestra base de datos
                // concat nos sirve para concatenar la informacion de las columnas en una fila
                string consulta = "SELECT *, CONCAT('Id del Usuario: ', Id, '   Nombre: ', Nombre) AS InformacionCompletaDelUsuario FROM Usuario";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable tablaDeUsuarios = new DataTable();
                    miAdaptadorSql.Fill(tablaDeUsuarios);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ListaDeUsuarios.DisplayMemberPath = "InformacionCompletaDelUsuario";

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeUsuarios.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeUsuarios.ItemsSource = tablaDeUsuarios.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnInsertarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para hacer insertar un registro
                string consulta = "INSERT INTO USUARIO(Nombre) VALUES(@Nombre)";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("Nombre", TxtInsertarUsuario.Text);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLosUsuarios();
                MessageBox.Show($"Has agregado un usuario con exito");
                TxtInsertarUsuario.Text = "";
            }
        }

        private void BtnBorrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres borrar al usuario seleccionado?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    // creamos una consulta parametrica para hacer posible la eliminacion de un registro
                    string consulta = "DELETE FROM Usuario WHERE Id = @IdUsuario";
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("IdUsuario", ListaDeUsuarios.SelectedValue);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    muestraDeLosUsuarios();
                    MessageBox.Show($"Has borrado un usuario con exito");
                }
            }
        }

        private void BtnActualizarUsuario_Click(object sender, RoutedEventArgs e)
        {

            ActualizarUsuarios ventanaActualizar = new ActualizarUsuarios((int)ListaDeUsuarios.SelectedValue);

            try
            {
                string consulta = "SELECT Nombre FROM Usuario WHERE Id = @IdUsuario";

                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(miComandoSql);

                using (miAdaptadorSql)
                {
                    miComandoSql.Parameters.AddWithValue("IdUsuario", ListaDeUsuarios.SelectedValue);
                    DataTable tablaDeUsuarios = new DataTable();
                    miAdaptadorSql.Fill(tablaDeUsuarios);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ventanaActualizar.TxtActualizaUsuario.Text = tablaDeUsuarios.Rows[0]["Nombre"].ToString();

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeUsuarios.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeUsuarios.ItemsSource = tablaDeUsuarios.DefaultView;
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
            muestraDeLosUsuarios();
        }

        private void BtnAyuda_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnGenerarReporteEnTexto_Click(object sender, RoutedEventArgs e)
        {
            if (ListaDeUsuarios.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)ListaDeUsuarios.SelectedItem;
                string informacionCompletaDelUsuarioSeleccionado = drv["InformacionCompletaDelUsuario"].ToString();

                try
                {
                    string consulta = $"SELECT * FROM Usuario WHERE CONCAT('Id del Usuario: ', Id, '   Nombre: ', Nombre) = '{informacionCompletaDelUsuarioSeleccionado}'";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtSedes = new DataTable();
                    miAdaptadorSql.Fill(dtSedes);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(informacionCompletaDelUsuarioSeleccionado);

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDelUsuarioSeleccionado.txt", sb.ToString());

                    MessageBox.Show("El reporte del usuario seleccionado ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
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
                    string consulta = "SELECT *, CONCAT('Id del Usuario: ', Id, '   Nombre: ', Nombre) AS InformacionCompletaDelUsuario FROM Usuario";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtSedes = new DataTable();
                    miAdaptadorSql.Fill(dtSedes);

                    StringBuilder sb = new StringBuilder();

                    foreach (DataRow row in dtSedes.Rows)
                    {
                        sb.AppendLine(row["InformacionCompletaDelUsuario"].ToString());
                    }

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDeUsuarios.txt", sb.ToString());

                    MessageBox.Show("El reporte de los usuarios ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void BtnRegresarAInicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }
    }
}

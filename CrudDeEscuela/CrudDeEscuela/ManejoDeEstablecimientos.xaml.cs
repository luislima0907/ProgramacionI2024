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
    /// Lógica de interacción para ManejoDeEstablecimientos.xaml
    /// </summary>
    public partial class ManejoDeEstablecimientos : Window
    {
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ManejoDeEstablecimientos()
        {
            InitializeComponent();
            // creamos una string de esta forma para poner dentro la cadena de conexion a nuestra base de datos
            // para crear la conexion se necesita el nombre del proyecto luego el metodo properties para acceder a sus propiedades
            // luego el metodo Settings para acceder a sus configuraciones y de ultimo el nombre que nos dio sql server al momento de crear la base de datos
            string miConexion = ConfigurationManager.ConnectionStrings["CrudDeEscuela.Properties.Settings.Sistema_De_EscuelaConnectionString"].ConnectionString;

            // instanciamos la conexion a nuestra base de datos, con el constructor
            // del parametro con la cadena de conexion
            miConexionSql = new SqlConnection(miConexion);

            muestraDeLosEstablecimientos();
        }

        private void muestraDeLosEstablecimientos()
        {
            try
            {
                // creamos una consulta calculada con concat para nuestra base de datos
                // concat nos sirve para concatenar la informacion de las columnas en una fila
                string consulta = "SELECT *, CONCAT('Id del Establecimiento: ', Id, '   Nombre: ', Nombre) AS InformacionCompletaDelEstablecimiento FROM Establecimiento";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable tablaDeEstablecimientos = new DataTable();
                    miAdaptadorSql.Fill(tablaDeEstablecimientos);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ListaDeEstablecimientos.DisplayMemberPath = "InformacionCompletaDelEstablecimiento";

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeEstablecimientos.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeEstablecimientos.ItemsSource = tablaDeEstablecimientos.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnActualizarEstablecimiento_Click(object sender, RoutedEventArgs e)
        {
            ActualizarEstablecimiento ventanaActualizar = new ActualizarEstablecimiento((int)ListaDeEstablecimientos.SelectedValue);

            try
            {
                string consulta = "SELECT Nombre FROM Establecimiento WHERE Id = @IdEstablecimiento";

                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(miComandoSql);

                using (miAdaptadorSql)
                {
                    miComandoSql.Parameters.AddWithValue("IdEstablecimiento", ListaDeEstablecimientos.SelectedValue);
                    DataTable tablaDeEstablecimientos = new DataTable();
                    miAdaptadorSql.Fill(tablaDeEstablecimientos);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ventanaActualizar.TxtActualizaEstablecimiento.Text = tablaDeEstablecimientos.Rows[0]["Nombre"].ToString();

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeEstablecimientos.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeEstablecimientos.ItemsSource = tablaDeEstablecimientos.DefaultView;
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
            muestraDeLosEstablecimientos();
        }

        private void BtnBorrarEstablecimiento_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres borrar el establecimiento seleccionado?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    // creamos una consulta parametrica para hacer posible la eliminacion de un registro
                    string consulta = "DELETE FROM Establecimiento WHERE Id = @IdEstablecimiento";
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("IdEstablecimiento", ListaDeEstablecimientos.SelectedValue);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    muestraDeLosEstablecimientos();
                    MessageBox.Show($"Has borrado un establecimiento con exito");
                }
            }
        }

        private void BtnInsertarEstablecimiento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para hacer insertar un registro
                string consulta = "INSERT INTO ESTABLECIMIENTO(Nombre) VALUES(@Nombre)";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("Nombre", TxtInsertarEstablecimiento.Text);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLosEstablecimientos();
                MessageBox.Show($"Has agregado un establecimiento con exito");
                TxtInsertarEstablecimiento.Text = "";
            }
        }

        private void BtnRegresarACarreras_Click(object sender, RoutedEventArgs e)
        {
            ManejoDeCarreras carreras = new ManejoDeCarreras();
            carreras.Show();
            this.Close();
        }

        private void BtnGenerarReporteEnTexto_Click(object sender, RoutedEventArgs e)
        {
            if (ListaDeEstablecimientos.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)ListaDeEstablecimientos.SelectedItem;
                string informacionCompletaDelEstablecimientoSeleccionado = drv["InformacionCompletaDelEstablecimiento"].ToString();

                try
                {
                    string consulta = $"SELECT * FROM Establecimiento WHERE CONCAT('Id del Establecimiento: ', Id, '   Nombre: ', Nombre) = '{informacionCompletaDelEstablecimientoSeleccionado}'";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtEstablecimiento = new DataTable();
                    miAdaptadorSql.Fill(dtEstablecimiento);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(informacionCompletaDelEstablecimientoSeleccionado);

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDelEstablecimientoSeleccionado.txt", sb.ToString());

                    MessageBox.Show("El reporte del establecimiento seleccionado ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
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
                    string consulta = "SELECT *, CONCAT('Id del Establecimiento: ', Id, 'Nombre: ', Nombre) AS InformacionCompletaDelEstablecimiento FROM Establecimiento";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtEstablecimiento = new DataTable();
                    miAdaptadorSql.Fill(dtEstablecimiento);

                    StringBuilder sb = new StringBuilder();

                    foreach (DataRow row in dtEstablecimiento.Rows)
                    {
                        sb.AppendLine(row["InformacionCompletaDelEstablecimiento"].ToString());
                    }

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDeEstablecimientos.txt", sb.ToString());

                    MessageBox.Show("El reporte de los establecimientos ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void BtnAyuda_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

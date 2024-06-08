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
    /// Lógica de interacción para ManejoDeSedes.xaml
    /// </summary>
    public partial class ManejoDeSedes : Window
    {
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ManejoDeSedes()
        {
            InitializeComponent();
            // creamos una string de esta forma para poner dentro la cadena de conexion a nuestra base de datos
            // para crear la conexion se necesita el nombre del proyecto luego el metodo properties para acceder a sus propiedades
            // luego el metodo Settings para acceder a sus configuraciones y de ultimo el nombre que nos dio sql server al momento de crear la base de datos
            string miConexion = ConfigurationManager.ConnectionStrings["CrudDeEscuela.Properties.Settings.Sistema_De_EscuelaConnectionString"].ConnectionString;

            // instanciamos la conexion a nuestra base de datos, con el constructor
            // del parametro con la cadena de conexion
            miConexionSql = new SqlConnection(miConexion);
            muestraDeLasSedes();
        }

        private void muestraDeLasSedes()
        {
            try
            {
                // creamos una consulta calculada con concat para nuestra base de datos
                // concat nos sirve para concatenar la informacion de las columnas en una fila
                string consulta = "SELECT *, CONCAT('Id de la Sede: ', Id, '   Ubicacion: ', Ubicacion) AS InformacionCompletaDeLaSede FROM Sede";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable tablaDeSedes = new DataTable();
                    miAdaptadorSql.Fill(tablaDeSedes);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ListaDeSedes.DisplayMemberPath = "InformacionCompletaDeLaSede";

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeSedes.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeSedes.ItemsSource = tablaDeSedes.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnActualizarSede_Click(object sender, RoutedEventArgs e)
        {
            ActualizarSedes ventanaActualizar = new ActualizarSedes((int)ListaDeSedes.SelectedValue);

            try
            {
                string consulta = "SELECT Ubicacion FROM Sede WHERE Id = @IdSede";

                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(miComandoSql);

                using (miAdaptadorSql)
                {
                    miComandoSql.Parameters.AddWithValue("IdSede", ListaDeSedes.SelectedValue);
                    DataTable tablaDeSedes = new DataTable();
                    miAdaptadorSql.Fill(tablaDeSedes);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ventanaActualizar.TxtActualizaSede.Text = tablaDeSedes.Rows[0]["Ubicacion"].ToString();

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeSedes.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeSedes.ItemsSource = tablaDeSedes.DefaultView;
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
            muestraDeLasSedes();
        }

        private void BtnBorrarSede_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres borrar la sede seleccionada?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    // creamos una consulta parametrica para hacer posible la eliminacion de un registro
                    string consulta = "DELETE FROM Sede WHERE Id = @IdSede";
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("IdSede", ListaDeSedes.SelectedValue);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    muestraDeLasSedes();
                    MessageBox.Show($"Has borrado una sede con exito");
                }
            }
        }

        private void BtnInsertarSede_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para hacer insertar un registro
                string consulta = "INSERT INTO SEDE(Ubicacion) VALUES(@Ubicacion)";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("Ubicacion", TxtInsertarSede.Text);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLasSedes();
                MessageBox.Show($"Has agregado una sede con exito");
                TxtInsertarSede.Text = "";
            }
        }

        private void BtnGenerarReporteEnTexto_Click(object sender, RoutedEventArgs e)
        {
            if (ListaDeSedes.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)ListaDeSedes.SelectedItem;
                string informacionCompletaDeLaSedeSeleccionada = drv["InformacionCompletaDeLaSede"].ToString();

                try
                {
                    string consulta = $"SELECT * FROM Sede WHERE CONCAT('Id de la Sede: ', Id, '   Ubicacion: ', Ubicacion) = '{informacionCompletaDeLaSedeSeleccionada}'";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtSedes = new DataTable();
                    miAdaptadorSql.Fill(dtSedes);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(informacionCompletaDeLaSedeSeleccionada);

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDeLaSedeSeleccionada.txt", sb.ToString());

                    MessageBox.Show("El reporte de la sede seleccionado ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
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
                    string consulta = "SELECT *, CONCAT('Id de la Sede: ', Id, '   Ubicacion: ', Ubicacion) AS InformacionCompletaDeLaSede FROM Sede";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtSedes = new DataTable();
                    miAdaptadorSql.Fill(dtSedes);

                    StringBuilder sb = new StringBuilder();

                    foreach (DataRow row in dtSedes.Rows)
                    {
                        sb.AppendLine(row["InformacionCompletaDeLaSede"].ToString());
                    }

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDeSedes.txt", sb.ToString());

                    MessageBox.Show("El reporte de las sedes ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
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

        private void BtnRegresarACarreras_Click(object sender, RoutedEventArgs e)
        {
            ManejoDeCarreras carreras = new ManejoDeCarreras();
            carreras.Show();
            this.Close();
        }
    }
}

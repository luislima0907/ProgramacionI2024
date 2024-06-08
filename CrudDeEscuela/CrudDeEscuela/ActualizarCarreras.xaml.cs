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

namespace CrudDeEscuela
{
    /// <summary>
    /// Lógica de interacción para ActualizarCarreras.xaml
    /// </summary>
    public partial class ActualizarCarreras : Window
    {
        // esta variable nos servira para guardar el id de la carrera que venga desde otro formulario
        private int IdDeLaCarreraDesdeOtraVentana;
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ActualizarCarreras(int idCarrera)
        {
            InitializeComponent();
            IdDeLaCarreraDesdeOtraVentana = idCarrera;
            // creamos una string de esta forma para poner dentro la cadena de conexion a nuestra base de datos
            // para crear la conexion se necesita el nombre del proyecto luego el metodo properties para acceder a sus propiedades
            // luego el metodo Settings para acceder a sus configuraciones y de ultimo el nombre que nos dio sql server al momento de crear la base de datos
            string miConexion = ConfigurationManager.ConnectionStrings["CrudDeEscuela.Properties.Settings.Sistema_De_EscuelaConnectionString"].ConnectionString;

            // instanciamos la conexion a nuestra base de datos, con el constructor
            // del parametro con la cadena de conexion
            miConexionSql = new SqlConnection(miConexion);


            try
            {
                // creamos una consulta para nuestra base de datos
                string consulta = "SELECT Ubicacion FROM Sede";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                // Creamos un DataTable para almacenar los resultados de la consulta
                DataTable dtSedes = new DataTable();

                using (miAdaptadorSql)
                {
                    // Llenamos el DataTable con los resultados de la consulta
                    miAdaptadorSql.Fill(dtSedes);

                    // Recorremos cada fila del DataTable
                    foreach (DataRow row in dtSedes.Rows)
                    {
                        // Agregamos el nombre de la categoría al ComboBox
                        cboActualizaSedeCarrera.Items.Add(row["Ubicacion"].ToString());
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
                string consulta = "SELECT Nombre FROM Establecimiento";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                // Creamos un DataTable para almacenar los resultados de la consulta
                DataTable dtEstablecimientos = new DataTable();

                using (miAdaptadorSql)
                {
                    // Llenamos el DataTable con los resultados de la consulta
                    miAdaptadorSql.Fill(dtEstablecimientos);

                    // Recorremos cada fila del DataTable
                    foreach (DataRow row in dtEstablecimientos.Rows)
                    {
                        // Agregamos el nombre de la categoría al ComboBox
                        cboActualizaEstablecimientoCarrera.Items.Add(row["Nombre"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnActualizarCarrera_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres actualizar la informacion de la carrera?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    // creamos una consulta parametrica para hacer posible la actualizacion de un registro
                    string consulta = $"UPDATE Carrera SET Nombre = @Nombre, Establecimiento = @Establecimiento, Sede = @Sede, PrimerCurso = @PrimerCurso, SegundoCurso = @SegundoCurso, TercerCurso = @TercerCurso WHERE Id = {IdDeLaCarreraDesdeOtraVentana}";// usamos el id que trajimos desde otra ventana
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("@Nombre", TxtActualizaCarrera.Text);
                    miComandoSql.Parameters.AddWithValue("@Establecimiento", cboActualizaEstablecimientoCarrera.SelectedValue);
                    miComandoSql.Parameters.AddWithValue("@Sede", cboActualizaSedeCarrera.SelectedValue);
                    miComandoSql.Parameters.AddWithValue("@PrimerCurso", TxtActualizaPrimerCurso.Text);
                    miComandoSql.Parameters.AddWithValue("@SegundoCurso", TxtActualizaSegundoCurso.Text);
                    miComandoSql.Parameters.AddWithValue("@TercerCurso", TxtActualizaTercerCurso.Text);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    MessageBox.Show($"Has actualizado a la carrera con exito");
                    TxtActualizaCarrera.Text = "";
                    TxtActualizaPrimerCurso.Text = "";
                    TxtActualizaSegundoCurso.Text = "";
                    TxtActualizaTercerCurso.Text = "";
                    cboActualizaEstablecimientoCarrera.SelectedValue = null;
                    cboActualizaSedeCarrera.SelectedValue = null;
                    // this hace referencia a los objetos de una clase
                    this.Close();
                }
            }
        }

        private void BtnRegresarAVentanaCarrera_Click(object sender, RoutedEventArgs e)
        {
            //ManejoDeCarreras carreras = new ManejoDeCarreras();
            //carreras.Show();
            this.Close();
        }
    }
}

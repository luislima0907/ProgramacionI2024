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
    /// Lógica de interacción para ActualizarAlumnos.xaml
    /// </summary>
    public partial class ActualizarAlumnos : Window
    {
        // esta variable nos servira para guardar el id del alumno que venga desde otro formulario
        private int IdDelAlumnoDesdeOtraVentana;
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ActualizarAlumnos(int idAlumno)
        {
            InitializeComponent();

            IdDelAlumnoDesdeOtraVentana = idAlumno;

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
                string consulta = "SELECT Id FROM Usuario";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                // Creamos un DataTable para almacenar los resultados de la consulta
                DataTable dtUsuarios = new DataTable();

                using (miAdaptadorSql)
                {
                    // Llenamos el DataTable con los resultados de la consulta
                    miAdaptadorSql.Fill(dtUsuarios);

                    // Recorremos cada fila del DataTable
                    foreach (DataRow row in dtUsuarios.Rows)
                    {
                        // Agregamos el nombre de la categoría al ComboBox
                        cboUsuarios.Items.Add(row["Id"].ToString());
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
                string consulta = "SELECT Nombre FROM Carrera";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                // Creamos un DataTable para almacenar los resultados de la consulta
                DataTable dtCarreras = new DataTable();

                using (miAdaptadorSql)
                {
                    // Llenamos el DataTable con los resultados de la consulta
                    miAdaptadorSql.Fill(dtCarreras);

                    // Recorremos cada fila del DataTable
                    foreach (DataRow row in dtCarreras.Rows)
                    {
                        // Agregamos el nombre de la categoría al ComboBox
                        cboActualizaCarreraAlumno.Items.Add(row["Nombre"].ToString());
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
                        cboActualizaEstablecimientoAlumno.Items.Add(row["Nombre"].ToString());
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
                        cboActualizaSedeAlumno.Items.Add(row["Ubicacion"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnActualizarAlumno_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres actualizar la informacion del alumno?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    // creamos una consulta parametrica para hacer posible la actualizacion de un registro
                    string consulta = $"UPDATE Alumno SET Nombre = @Nombre, IdDelUsuario = @IdDelUsuario, NombreDelUsuario = @NombreDelUsuario, Carnet = @Carnet, Direccion = @Direccion, Telefono = @Telefono, Carrera = @Carrera, NombreDelPrimerCurso = @NombreDelPrimerCurso, NombreDelSegundoCurso = @NombreDelSegundoCurso, NombreDelTercerCurso = @NombreDelTercerCurso, Establecimiento = @Establecimiento, Sede = @Sede WHERE Id = {IdDelAlumnoDesdeOtraVentana}";// usamos el id que trajimos desde otra ventana
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("@Nombre", TxtActualizaAlumno.Text);
                    miComandoSql.Parameters.AddWithValue("@IdDelUsuario", cboUsuarios.SelectedValue);
                    miComandoSql.Parameters.AddWithValue("@NombreDelUsuario", TxtInsertarUsuario.Text);
                    miComandoSql.Parameters.AddWithValue("@Carnet", TxtActualizaCarnetAlumno.Text);
                    miComandoSql.Parameters.AddWithValue("@Direccion", TxtActualizaDireccionAlumno.Text);
                    miComandoSql.Parameters.AddWithValue("@Telefono", TxtActualizaTelefonoAlumno.Text);
                    miComandoSql.Parameters.AddWithValue("@Carrera", cboActualizaCarreraAlumno.SelectedValue);
                    miComandoSql.Parameters.AddWithValue("@NombreDelPrimerCurso", TxtActualizaPrimerCurso.Text);
                    miComandoSql.Parameters.AddWithValue("@NombreDelSegundoCurso", TxtActualizaSegundoCurso.Text);
                    miComandoSql.Parameters.AddWithValue("@NombreDelTercerCurso", TxtActualizaTercerCurso.Text);
                    miComandoSql.Parameters.AddWithValue("@Establecimiento", cboActualizaEstablecimientoAlumno.SelectedValue);
                    miComandoSql.Parameters.AddWithValue("@Sede", cboActualizaSedeAlumno.SelectedValue);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    MessageBox.Show($"Has actualizado al alumno con exito");
                    TxtActualizaAlumno.Text = "";
                    cboUsuarios.SelectedValue = null;
                    TxtInsertarUsuario.Text = "";
                    TxtActualizaCarnetAlumno.Text = "";
                    TxtActualizaDireccionAlumno.Text = "";
                    TxtActualizaTelefonoAlumno.Text = "";
                    cboActualizaCarreraAlumno.SelectedValue = null;
                    TxtActualizaPrimerCurso.Text = "";
                    TxtActualizaSegundoCurso.Text = "";
                    TxtActualizaTercerCurso.Text = "";
                    cboActualizaEstablecimientoAlumno.SelectedValue = null;
                    cboActualizaSedeAlumno.SelectedValue = null;
                    // this hace referencia a los objetos de una clase
                    this.Close();
                }
            }
        }

        private void cboActualizaCarreraAlumno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // Obtenemos el nombre de la carrera seleccionada
            string nombreDeLaCarreraSeleccionada = cboActualizaCarreraAlumno.SelectedItem.ToString();

            try
            {
                // Creamos una consulta para obtener los cursos de la carrera seleccionada
                string consulta = $"SELECT PrimerCurso, SegundoCurso, TercerCurso FROM Carrera WHERE Nombre = '{nombreDeLaCarreraSeleccionada}'";

                // Ejecutamos la consulta
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                DataTable dtCursos = new DataTable();
                miAdaptadorSql.Fill(dtCursos);

                // Verificamos que la consulta haya devuelto al menos un resultado
                if (dtCursos.Rows.Count > 0)
                {
                    // Asignamos los nombres de los cursos a los campos de texto
                    TxtActualizaPrimerCurso.Text = dtCursos.Rows[0]["PrimerCurso"].ToString();
                    TxtActualizaSegundoCurso.Text = dtCursos.Rows[0]["SegundoCurso"].ToString();
                    TxtActualizaTercerCurso.Text = dtCursos.Rows[0]["TercerCurso"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnRegresarAVentanaAlumno_Click(object sender, RoutedEventArgs e)
        {
            //ManejoDeAlumnos alumnos = new ManejoDeAlumnos();
            //alumnos.Show();
            this.Close();
        }

        private void cboUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Obtenemos el nombre de la carrera seleccionada
            string IdDelUsuarioSeleccionado = cboUsuarios.SelectedItem.ToString();

            try
            {
                // Creamos una consulta para obtener los cursos de la carrera seleccionada
                string consulta = $"SELECT Nombre FROM Usuario WHERE Id = '{IdDelUsuarioSeleccionado}'";

                // Ejecutamos la consulta
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                DataTable dtUsuarios = new DataTable();
                miAdaptadorSql.Fill(dtUsuarios);

                // Verificamos que la consulta haya devuelto al menos un resultado
                if (dtUsuarios.Rows.Count > 0)
                {
                    // Asignamos los nombres de los cursos a los campos de texto
                    TxtInsertarUsuario.Text = dtUsuarios.Rows[0]["Nombre"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

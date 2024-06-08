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
    /// Lógica de interacción para ActualizarPromedioDeNotas.xaml
    /// </summary>
    public partial class ActualizarPromedioDeNotas : Window
    {
        // esta variable nos servira para guardar el id de la nota que venga desde otro formulario
        private int IdDeLaNotaDesdeOtraVentana;
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ActualizarPromedioDeNotas(int idNota)
        {
            InitializeComponent();

            IdDeLaNotaDesdeOtraVentana = idNota;

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
                string consulta = "SELECT Id FROM Alumno";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                // Creamos un DataTable para almacenar los resultados de la consulta
                DataTable dtAlumnos = new DataTable();

                using (miAdaptadorSql)
                {
                    // Llenamos el DataTable con los resultados de la consulta
                    miAdaptadorSql.Fill(dtAlumnos);

                    // Recorremos cada fila del DataTable
                    foreach (DataRow row in dtAlumnos.Rows)
                    {
                        // Agregamos el nombre de la categoría al ComboBox
                        cboActualizaIdAlumnos.Items.Add(row["Id"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void BtnActualizarNota_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres actualizar la informacion de la Nota?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    // creamos una consulta parametrica para hacer posible la actualizacion de un registro
                    string consulta = $"UPDATE Nota SET IdAlumno = @IdAlumno, CarnetDelAlumno = @CarnetDelAlumno, NombreDelAlumno = @NombreDelAlumno, NombreDeLaCarrera = @NombreDeLaCarrera, NombrePrimerCurso = @NombrePrimerCurso, NotaPrimerCurso = @NotaPrimerCurso, NombreSegundoCurso = @NombreSegundoCurso, NotaSegundoCurso = @NotaSegundoCurso, NombreTercerCurso = @NombreTercerCurso, NotaTercerCurso = @NotaTercerCurso, SumaDeLasNotas = @SumaDeLasNotas, PromedioDeLasNotas = @PromedioDeLasNotas WHERE Id = {IdDeLaNotaDesdeOtraVentana}";// usamos el id que trajimos desde otra ventana
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("@IdAlumno", cboActualizaIdAlumnos.SelectedValue);
                    miComandoSql.Parameters.AddWithValue("@CarnetDelAlumno", txtActualizaCarnetDelAlumno.Text);
                    miComandoSql.Parameters.AddWithValue("@NombreDelAlumno", txtActualizaNombreDelAlumno.Text);
                    miComandoSql.Parameters.AddWithValue("@NombreDeLaCarrera", txtActualizaCarreraDelAlumno.Text);
                    miComandoSql.Parameters.AddWithValue("@NombrePrimerCurso", txtActualizaPrimerCursoCarrera.Text);
                    miComandoSql.Parameters.AddWithValue("@NotaPrimerCurso", txtActualizaNotaPrimerCurso.Text);
                    miComandoSql.Parameters.AddWithValue("@NombreSegundoCurso", txtActualizaSegundoCursoCarrera.Text);
                    miComandoSql.Parameters.AddWithValue("@NotaSegundoCurso", txtActualizaNotaSegundoCurso.Text);
                    miComandoSql.Parameters.AddWithValue("@NombreTercerCurso", txtActualizaTercerCursoCarrera.Text);
                    miComandoSql.Parameters.AddWithValue("@NotaTercerCurso", txtActualizaNotaTercerCurso.Text);
                    miComandoSql.Parameters.AddWithValue("@SumaDeLasNotas", txtActualizaSumaDeLasNotas.Text);
                    miComandoSql.Parameters.AddWithValue("@PromedioDeLasNotas", txtActualizaPromedioDeLasNotas.Text);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    MessageBox.Show($"Has actualizado la nota con exito");
                    cboActualizaIdAlumnos.SelectedIndex = 0;
                    txtActualizaCarnetDelAlumno.Text = "";
                    txtActualizaNombreDelAlumno.Text = "";
                    txtActualizaCarreraDelAlumno.Text = "";
                    txtActualizaPrimerCursoCarrera.Text = "";
                    txtActualizaNotaPrimerCurso.Text = "";
                    txtActualizaSegundoCursoCarrera.Text = "";
                    txtActualizaNotaSegundoCurso.Text = "";
                    txtActualizaTercerCursoCarrera.Text = "";
                    txtActualizaNotaTercerCurso.Text = "";
                    txtActualizaSumaDeLasNotas.Text = "";
                    txtActualizaPromedioDeLasNotas.Text = "";
                    // this hace referencia a los objetos de una clase
                    this.Close();
                }
            }
        }

        private void BtnRegresarAVentanaNotas_Click(object sender, RoutedEventArgs e)
        {
            //ManejoDePromedioDeNotas notas = new ManejoDePromedioDeNotas();
            //notas.Show();
            this.Close();
        }

        private void cboActualizaIdAlumnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Obtenemos el id del alumno seleccionado
            string IdDelAlumnoSeleccionado = cboActualizaIdAlumnos.SelectedItem.ToString();

            try
            {
                // Creamos una consulta para obtener los cursos de la carrera seleccionada
                string consulta = $"SELECT Nombre,Carnet,Carrera,NombreDelPrimerCurso,NombreDelSegundoCurso,NombreDelTercerCurso FROM Alumno WHERE Id = '{IdDelAlumnoSeleccionado}'";

                // Ejecutamos la consulta
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                DataTable dtIdAlumnos = new DataTable();
                miAdaptadorSql.Fill(dtIdAlumnos);

                // Verificamos que la consulta haya devuelto al menos un resultado
                if (dtIdAlumnos.Rows.Count > 0)
                {
                    // Asignamos los nombres de los cursos a los campos de texto
                    txtActualizaNombreDelAlumno.Text = dtIdAlumnos.Rows[0]["Nombre"].ToString();
                    txtActualizaCarnetDelAlumno.Text = dtIdAlumnos.Rows[0]["Carnet"].ToString();
                    txtActualizaCarreraDelAlumno.Text = dtIdAlumnos.Rows[0]["Carrera"].ToString();
                    txtActualizaPrimerCursoCarrera.Text = dtIdAlumnos.Rows[0]["NombreDelPrimerCurso"].ToString();
                    txtActualizaSegundoCursoCarrera.Text = dtIdAlumnos.Rows[0]["NombreDelSegundoCurso"].ToString();
                    txtActualizaTercerCursoCarrera.Text = dtIdAlumnos.Rows[0]["NombreDelTercerCurso"].ToString();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void txtActualizaNotaTercerCurso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Verificamos si los campos de texto contienen números válidos
                if (int.TryParse(txtActualizaNotaPrimerCurso.Text, out int notaPrimerCurso) && notaPrimerCurso >= 1 && notaPrimerCurso <= 100 &&
                    int.TryParse(txtActualizaNotaSegundoCurso.Text, out int notaSegundoCurso) && notaSegundoCurso >= 1 && notaSegundoCurso <= 100 &&
                    int.TryParse(txtActualizaNotaTercerCurso.Text, out int notaTercerCurso) && notaTercerCurso >= 1 && notaTercerCurso <= 100)
                {
                    // Calculamos la suma de las notas
                    int sumaDeLasNotas = notaPrimerCurso + notaSegundoCurso + notaTercerCurso;

                    // Calculamos el promedio de las notas
                    int promedioDeLasNotas = sumaDeLasNotas / 3;

                    // Mostramos la suma y el promedio en los campos de texto correspondientes
                    txtActualizaSumaDeLasNotas.Text = sumaDeLasNotas.ToString();
                    txtActualizaPromedioDeLasNotas.Text = promedioDeLasNotas.ToString();
                }
            }
        }
    }
}

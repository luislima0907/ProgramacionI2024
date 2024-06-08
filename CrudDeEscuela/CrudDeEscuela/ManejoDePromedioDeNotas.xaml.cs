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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CrudDeEscuela
{
    /// <summary>
    /// Lógica de interacción para ManejoDePromedioDeNotas.xaml
    /// </summary>
    public partial class ManejoDePromedioDeNotas : Window
    {
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ManejoDePromedioDeNotas()
        {
            InitializeComponent();
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
                        cboIdAlumnos.Items.Add(row["Id"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            muestraDeLasNotas();
        }

        private void muestraDeLasNotas()
        {
            try
            {
                // creamos una consulta calculada con concat para nuestra base de datos
                // concat nos sirve para concatenar la informacion de las columnas en una fila
                string consulta = "SELECT *, CONCAT('Id del Alumno: ', IdAlumno, '   Carnet del Alumno: ', CarnetDelAlumno, '   Nombre del Alumno: ', NombreDelAlumno, '   Nombre de la Carrera: ', NombreDeLaCarrera, '   Nombre del Primer Curso: ', NombrePrimerCurso, '   Nota del Primer Curso: ', NotaPrimerCurso, '   Nombre del Segundo Curso: ', NombreSegundoCurso, '   Nota del Segundo Curso: ', NotaSegundoCurso, '   Nombre del Tercer Curso: ', NombreTercerCurso, '   Nota del Tercer Curso: ', NotaTercerCurso, '   Suma de las Notas: ', SumaDeLasNotas, '   Promedio de las Notas: ', PromedioDeLasNotas) AS InformacionCompletaDeLaNota FROM Nota";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable tablaDeNotas = new DataTable();
                    miAdaptadorSql.Fill(tablaDeNotas);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ListaDeNotas.DisplayMemberPath = "InformacionCompletaDeLaNota";

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeNotas.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeNotas.ItemsSource = tablaDeNotas.DefaultView;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void BtnBorrarNota_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres borrar la nota seleccionada?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if(messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    // creamos una consulta parametrica para hacer posible la eliminacion de un registro
                    string consulta = "DELETE FROM Nota WHERE Id = @IdNota";
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("IdNota", ListaDeNotas.SelectedValue);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    muestraDeLasNotas();
                    System.Windows.Forms.MessageBox.Show($"Has borrado una nota con exito");
                }
            }
        }

        private void BtnRegresarAlInicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }

        private void BtnInsertarNota_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para hacer insertar un registro
                string consulta = "INSERT INTO NOTA(IdAlumno,CarnetDelAlumno,NombreDelAlumno,NombreDeLaCarrera,NombrePrimerCurso,NotaPrimerCurso,NombreSegundoCurso,NotaSegundoCurso,NombreTercerCurso,NotaTercerCurso,SumaDeLasNotas,PromedioDeLasNotas) VALUES(@IdAlumno,@CarnetDelAlumno,@NombreDelAlumno,@NombreDeLaCarrera,@NombrePrimerCurso,@NotaPrimerCurso,@NombreSegundoCurso,@NotaSegundoCurso,@NombreTercerCurso,@NotaTercerCurso,@SumaDeLasNotas,@PromedioDeLasNotas)";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("IdAlumno", cboIdAlumnos.SelectedValue);
                miComandoSql.Parameters.AddWithValue("CarnetDelAlumno", txtCarnetDelAlumno.Text);
                miComandoSql.Parameters.AddWithValue("NombreDelAlumno", txtNombreDelAlumno.Text);
                miComandoSql.Parameters.AddWithValue("NombreDeLaCarrera", txtCarreraDelAlumno.Text);
                miComandoSql.Parameters.AddWithValue("NombrePrimerCurso", txtPrimerCursoCarrera.Text);
                miComandoSql.Parameters.AddWithValue("NotaPrimerCurso", txtNotaPrimerCurso.Text);
                miComandoSql.Parameters.AddWithValue("NombreSegundoCurso", txtSegundoCursoCarrera.Text);
                miComandoSql.Parameters.AddWithValue("NotaSegundoCurso", txtNotaSegundoCurso.Text);
                miComandoSql.Parameters.AddWithValue("NombreTercerCurso", txtTercerCursoCarrera.Text);
                miComandoSql.Parameters.AddWithValue("NotaTercerCurso", txtNotaTercerCurso.Text);
                miComandoSql.Parameters.AddWithValue("SumaDeLasNotas", txtSumaDeLasNotas.Text);
                miComandoSql.Parameters.AddWithValue("PromedioDeLasNotas", txtPromedioDeLasNotas.Text);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLasNotas();
                System.Windows.Forms.MessageBox.Show($"Has agregado una nota con exito");
                cboIdAlumnos.SelectedValue = null;
                txtCarnetDelAlumno.Text = "";
                txtNombreDelAlumno.Text = "";
                txtCarreraDelAlumno.Text = "";
                txtPrimerCursoCarrera.Text = "";
                txtNotaPrimerCurso.Text = "";
                txtSegundoCursoCarrera.Text = "";
                txtNotaSegundoCurso.Text = "";
                txtTercerCursoCarrera.Text = "";
                txtNotaTercerCurso.Text = "";
                txtSumaDeLasNotas.Text = "";
                txtPromedioDeLasNotas.Text = "";
            }
        }

        private void BtnGenerarReporteEnTexto_Click(object sender, RoutedEventArgs e)
        {
            if (ListaDeNotas.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)ListaDeNotas.SelectedItem;
                string informacionCompletaDeLaNotaSeleccionada = drv["InformacionCompletaDeLaNota"].ToString();

                try
                {
                    string consulta = $"SELECT * FROM Nota WHERE CONCAT('Id del Alumno: ', IdAlumno, '   Carnet del Alumno: ', CarnetDelAlumno, '   Nombre del Alumno: ', NombreDelAlumno, '   Nombre de la Carrera: ', NombreDeLaCarrera, '   Nombre del Primer Curso: ', NombrePrimerCurso, '   Nota del Primer Curso: ', NotaPrimerCurso, '   Nombre del Segundo Curso: ', NombreSegundoCurso, '   Nota del Segundo Curso: ', NotaSegundoCurso, '   Nombre del Tercer Curso: ', NombreTercerCurso, '   Nota del Tercer Curso: ', NotaTercerCurso, '   Suma de las Notas: ', SumaDeLasNotas, '   Promedio de las Notas: ', PromedioDeLasNotas) = '{informacionCompletaDeLaNotaSeleccionada}'";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtNota = new DataTable();
                    miAdaptadorSql.Fill(dtNota);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(informacionCompletaDeLaNotaSeleccionada);

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDeLaNotaSeleccionada.txt", sb.ToString());

                    System.Windows.Forms.MessageBox.Show("El reporte de la nota seleccionada ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                try
                {
                    string consulta = "SELECT *, CONCAT('Id del Alumno: ', IdAlumno, '   Carnet del Alumno: ', CarnetDelAlumno, '   Nombre del Alumno: ', NombreDelAlumno, '   Nombre de la Carrera: ', NombreDeLaCarrera, '   Nombre del Primer Curso: ', NombrePrimerCurso, '   Nota del Primer Curso: ', NotaPrimerCurso, '   Nombre del Segundo Curso: ', NombreSegundoCurso, '   Nota del Segundo Curso: ', NotaSegundoCurso, '   Nombre del Tercer Curso: ', NombreTercerCurso, '   Nota del Tercer Curso: ', NotaTercerCurso, '   Suma de las Notas: ', SumaDeLasNotas, '   Promedio de las Notas: ', PromedioDeLasNotas) AS InformacionCompletaDeLaNota FROM Nota";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtNota = new DataTable();
                    miAdaptadorSql.Fill(dtNota);

                    StringBuilder sb = new StringBuilder();

                    foreach (DataRow row in dtNota.Rows)
                    {
                        sb.AppendLine(row["InformacionCompletaDeLaNota"].ToString());
                    }

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDeNotas.txt", sb.ToString());

                    System.Windows.Forms.MessageBox.Show("El reporte de las notas ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            }
        }

        private void cboIdAlumnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Obtenemos el id del alumno seleccionado
            string IdDelAlumnoSeleccionado = cboIdAlumnos.SelectedItem.ToString();

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
                    txtNombreDelAlumno.Text = dtIdAlumnos.Rows[0]["Nombre"].ToString();
                    txtCarnetDelAlumno.Text = dtIdAlumnos.Rows[0]["Carnet"].ToString();
                    txtCarreraDelAlumno.Text = dtIdAlumnos.Rows[0]["Carrera"].ToString();
                    txtPrimerCursoCarrera.Text = dtIdAlumnos.Rows[0]["NombreDelPrimerCurso"].ToString();
                    txtSegundoCursoCarrera.Text = dtIdAlumnos.Rows[0]["NombreDelSegundoCurso"].ToString();
                    txtTercerCursoCarrera.Text = dtIdAlumnos.Rows[0]["NombreDelTercerCurso"].ToString();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void txtNotaTercerCurso_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Verificamos si los campos de texto contienen números válidos
                if (int.TryParse(txtNotaPrimerCurso.Text, out int notaPrimerCurso) && notaPrimerCurso >= 1 && notaPrimerCurso <= 100 &&
                    int.TryParse(txtNotaSegundoCurso.Text, out int notaSegundoCurso) && notaSegundoCurso >= 1 && notaSegundoCurso <= 100 &&
                    int.TryParse(txtNotaTercerCurso.Text, out int notaTercerCurso) && notaTercerCurso >= 1 && notaTercerCurso <= 100)
                {
                    // Calculamos la suma de las notas
                    int sumaDeLasNotas = notaPrimerCurso + notaSegundoCurso + notaTercerCurso;

                    // Calculamos el promedio de las notas
                    int promedioDeLasNotas = sumaDeLasNotas / 3;

                    // Mostramos la suma y el promedio en los campos de texto correspondientes
                    txtSumaDeLasNotas.Text = sumaDeLasNotas.ToString();
                    txtPromedioDeLasNotas.Text = promedioDeLasNotas.ToString();
                }
            }
        }

        private void BtnAyuda_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Estas son las funciones de esta ventana:\n\n1. Agregar: Para agregar una nota al alumno primero tienes que seleccionar su id en el comboBox de Id del Alumno, " +
                "se te mostraran varios numeros y tienes que elegir uno, cuando elijas uno automaticamente se llenaran los siguientes campos: Carnet del alumno, nombre del alumno, Carrera, Primer curso, Segundo Curso, " +
                "Tercer Curso. Esto pasa porque al momento de agregar un alumno nosotros ya le agregamos esos campos entonces para no volverlos a escribir solo tenemos que elegir el id del alumno, " +
                "Una vez tengamos al id del alumno tenemos que asignarle una nota a cada curso, la nota tiene que ser de numeros enteros del 1 al 100, una vez ya tengamos las notas de los cursos tenemos que " +
                "darle enter al campo de texto de la nota del tercer curso para que nos calcule la suma y el promedio de las notas ingresadas, de ultimo ya podemos darle al boton de agregar nota y automaticamente se agregara" +
                " al listbox para poderla visualizar.\n\n2. Actualizar: Para actualizar la nota solo la seleccionamos y le damos al boton de actualizar y se nos mostrara una ventana con la informacion de la nota, ya para editarla " +
                "seguimos los mismos pasos que al momento de agregarla, una vez ya tengamos la nueva informacion de la nota, le damos al boton de actualizar y nos preguntara si queremos actualizar la informacion de la nota, si le " +
                "damos a 'si' se cerrara la ventana y ya nos mostrara la nueva nota en el listbox.\n\n3. Borrar: Para borrar una nota solo tenemos que seleccionarla y darle al boton de Borrar, nos preguntara primero si queremos eliminarla " +
                "y si le damos que 'si' la nota sera eliminada.\n\n4. Generar Reporte: Para generar un reporte individual solo tenemos que seleccionar una nota y darle al boton de generar un reporte y automaticamente se generara un reporte " +
                "en un archivo de texto con la nota seleccionada y queremos un reporte de todas las notas simplemente no seleccionamos ninguna nota y le damos al boton de generar un reporte y con eso ya nos genera un reporte con todas las notas" +
                " en un archivo de texto.");
        }

        private void BtnActualizarNota_Click(object sender, RoutedEventArgs e)
        {
            ActualizarPromedioDeNotas ventanaActualizar = new ActualizarPromedioDeNotas((int)ListaDeNotas.SelectedValue);

            try
            {
                string consulta = "SELECT IdAlumno,CarnetDelAlumno,NombreDelAlumno,NombreDeLaCarrera,NombrePrimerCurso,NotaPrimerCurso,NombreSegundoCurso,NotaSegundoCurso,NombreTercerCurso,NotaTercerCurso,SumaDeLasNotas,PromedioDeLasNotas FROM Nota WHERE Id = @IdNota";

                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(miComandoSql);

                using (miAdaptadorSql)
                {
                    miComandoSql.Parameters.AddWithValue("IdNota", ListaDeNotas.SelectedValue);
                    DataTable tablaDeNotas = new DataTable();
                    miAdaptadorSql.Fill(tablaDeNotas);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ventanaActualizar.cboActualizaIdAlumnos.SelectedValue = tablaDeNotas.Rows[0]["IdAlumno"].ToString();
                    ventanaActualizar.txtActualizaCarnetDelAlumno.Text = tablaDeNotas.Rows[0]["CarnetDelAlumno"].ToString();
                    ventanaActualizar.txtActualizaNombreDelAlumno.Text = tablaDeNotas.Rows[0]["NombreDelAlumno"].ToString();
                    ventanaActualizar.txtActualizaCarreraDelAlumno.Text = tablaDeNotas.Rows[0]["NombreDeLaCarrera"].ToString();
                    ventanaActualizar.txtActualizaPrimerCursoCarrera.Text = tablaDeNotas.Rows[0]["NombrePrimerCurso"].ToString();
                    ventanaActualizar.txtActualizaNotaPrimerCurso.Text = tablaDeNotas.Rows[0]["NotaPrimerCurso"].ToString();
                    ventanaActualizar.txtActualizaSegundoCursoCarrera.Text = tablaDeNotas.Rows[0]["NombreSegundoCurso"].ToString();
                    ventanaActualizar.txtActualizaNotaSegundoCurso.Text = tablaDeNotas.Rows[0]["NotaSegundoCurso"].ToString();
                    ventanaActualizar.txtActualizaTercerCursoCarrera.Text = tablaDeNotas.Rows[0]["NombreTercerCurso"].ToString();
                    ventanaActualizar.txtActualizaNotaTercerCurso.Text = tablaDeNotas.Rows[0]["NotaTercerCurso"].ToString();
                    ventanaActualizar.txtActualizaSumaDeLasNotas.Text = tablaDeNotas.Rows[0]["SumaDeLasNotas"].ToString();
                    ventanaActualizar.txtActualizaPromedioDeLasNotas.Text = tablaDeNotas.Rows[0]["PromedioDeLasNotas"].ToString();


                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeNotas.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeNotas.ItemsSource = tablaDeNotas.DefaultView;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            // ShowDialog lo que nos permite es de que pone la ventana en la que estemos en primer plano a nivel de programa
            // es decir, nos servira al momento de tener dos ventanas abiertas del mismo programa y no queramos que el usuario
            // salga de ahi hasta que la cierre o termine la tarea que se le solicita
            ventanaActualizar.ShowDialog();
            muestraDeLasNotas();
        }
    }
}

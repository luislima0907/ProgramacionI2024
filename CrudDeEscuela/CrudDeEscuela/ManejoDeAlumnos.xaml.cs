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
    /// Lógica de interacción para ManejoDeAlumnos.xaml
    /// </summary>
    public partial class ManejoDeAlumnos : Window
    {
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ManejoDeAlumnos()
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
                        cboCarreras.Items.Add(row["Nombre"].ToString());
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
                        cboEstablecimiento.Items.Add(row["Nombre"].ToString());
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
                        cboSedes.Items.Add(row["Ubicacion"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            muestraDeLosAlumnos();
        }

        private void muestraDeLosAlumnos()
        {
            try
            {
                // creamos una consulta calculada con concat para nuestra base de datos
                // concat nos sirve para concatenar la informacion de las columnas en una fila
                string consulta = "SELECT *, CONCAT('Nombre: ', Nombre, '   Id del Usuario: ', IdDelUsuario, '   NombreDelUsuario: ', NombreDelUsuario, '   Carnet: ', Carnet, '   Direccion: ', Direccion, '   Telefono: ', Telefono, '   Carrera: ', Carrera, '   Nombre del primer curso: ', NombreDelPrimerCurso, '   Nombre del segundo curso: ', NombreDelSegundoCurso, '   Nombre del tercer curso: ', NombreDelTercerCurso, '   Establecimiento: ', Establecimiento, '   Sede: ', Sede) AS InformacionCompletaDelAlumno FROM Alumno";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable tablaDeAlumnos = new DataTable();
                    miAdaptadorSql.Fill(tablaDeAlumnos);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ListaDeAlumnos.DisplayMemberPath = "InformacionCompletaDelAlumno";

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeAlumnos.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeAlumnos.ItemsSource = tablaDeAlumnos.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnActualizarAlumno_Click(object sender, RoutedEventArgs e)
        {
            ActualizarAlumnos ventanaActualizar = new ActualizarAlumnos((int)ListaDeAlumnos.SelectedValue);

            try
            {
                string consulta = "SELECT Nombre,IdDelUsuario,NombreDelUsuario,Carnet,Direccion,Telefono,Carrera,NombreDelPrimerCurso,NombreDelSegundoCurso,NombreDelTercerCurso,Establecimiento,Sede FROM Alumno WHERE Id = @IdAlumno";

                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(miComandoSql);

                using (miAdaptadorSql)
                {
                    miComandoSql.Parameters.AddWithValue("IdAlumno", ListaDeAlumnos.SelectedValue);
                    DataTable tablaDeAlumnos = new DataTable();
                    miAdaptadorSql.Fill(tablaDeAlumnos);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ventanaActualizar.TxtActualizaAlumno.Text = tablaDeAlumnos.Rows[0]["Nombre"].ToString();
                    ventanaActualizar.cboUsuarios.SelectedValue = tablaDeAlumnos.Rows[0]["IdDelUsuario"].ToString();
                    ventanaActualizar.TxtInsertarUsuario.Text = tablaDeAlumnos.Rows[0]["NombreDelUsuario"].ToString();
                    ventanaActualizar.TxtActualizaCarnetAlumno.Text = tablaDeAlumnos.Rows[0]["Carnet"].ToString();
                    ventanaActualizar.TxtActualizaDireccionAlumno.Text = tablaDeAlumnos.Rows[0]["Direccion"].ToString();
                    ventanaActualizar.TxtActualizaTelefonoAlumno.Text = tablaDeAlumnos.Rows[0]["Telefono"].ToString();
                    ventanaActualizar.cboActualizaCarreraAlumno.SelectedValue = tablaDeAlumnos.Rows[0]["Carrera"].ToString();
                    ventanaActualizar.TxtActualizaPrimerCurso.Text = tablaDeAlumnos.Rows[0]["NombreDelPrimerCurso"].ToString();
                    ventanaActualizar.TxtActualizaSegundoCurso.Text = tablaDeAlumnos.Rows[0]["NombreDelSegundoCurso"].ToString();
                    ventanaActualizar.TxtActualizaTercerCurso.Text = tablaDeAlumnos.Rows[0]["NombreDelTercerCurso"].ToString();
                    ventanaActualizar.cboActualizaEstablecimientoAlumno.SelectedValue = tablaDeAlumnos.Rows[0]["Establecimiento"].ToString();
                    ventanaActualizar.cboActualizaSedeAlumno.SelectedValue = tablaDeAlumnos.Rows[0]["Sede"].ToString();


                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeAlumnos.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeAlumnos.ItemsSource = tablaDeAlumnos.DefaultView;
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
            muestraDeLosAlumnos();
        }

        private void BtnBorrarAlumno_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres borrar al alumno seleccionado?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    // creamos una consulta parametrica para hacer posible la eliminacion de un registro
                    string consulta = "DELETE FROM Alumno WHERE Id = @IdAlumno";
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("IdAlumno", ListaDeAlumnos.SelectedValue);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    muestraDeLosAlumnos();
                    MessageBox.Show($"Has borrado un alumno con exito");
                }
            }
        }

        private void BtnInsertarAlumno_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para hacer insertar un registro
                string consulta = "INSERT INTO ALUMNO(Nombre,IdDelUsuario,NombreDelUsuario,Carnet,Direccion,Telefono,Carrera,NombreDelPrimerCurso,NombreDelSegundoCurso,NombreDelTercerCurso,Establecimiento,Sede) VALUES(@Nombre,@IdDelUsuario,@NombreDelUsuario,@Carnet,@Direccion,@Telefono,@Carrera,@NombreDelPrimerCurso,@NombreDelSegundoCurso,@NombreDelTercerCurso,@Establecimiento,@Sede)";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("Nombre", TxtInsertarAlumno.Text);
                miComandoSql.Parameters.AddWithValue("IdDelUsuario", cboUsuarios.SelectedValue);
                miComandoSql.Parameters.AddWithValue("NombreDelUsuario", TxtInsertarUsuario.Text);
                miComandoSql.Parameters.AddWithValue("Carnet", TxtInsertarCarnetAlumno.Text);
                miComandoSql.Parameters.AddWithValue("Direccion", TxtInsertarDireccionAlumno.Text);
                miComandoSql.Parameters.AddWithValue("Telefono", TxtInsertarTelefonoAlumno.Text);
                miComandoSql.Parameters.AddWithValue("Carrera", cboCarreras.SelectedValue);
                miComandoSql.Parameters.AddWithValue("NombreDelPrimerCurso", TxtInsertarPrimerCurso.Text);
                miComandoSql.Parameters.AddWithValue("NombreDelSegundoCurso", TxtInsertarSegundoCurso.Text);
                miComandoSql.Parameters.AddWithValue("NombreDelTercerCurso", TxtInsertarTercerCurso.Text);
                miComandoSql.Parameters.AddWithValue("Establecimiento", cboEstablecimiento.SelectedValue);
                miComandoSql.Parameters.AddWithValue("Sede", cboSedes.SelectedValue);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLosAlumnos();
                MessageBox.Show($"Has agregado un alumno con exito");
                TxtInsertarAlumno.Text = "";
                cboUsuarios.SelectedValue = null;
                TxtInsertarUsuario.Text = "";
                TxtInsertarCarnetAlumno.Text = "";
                TxtInsertarDireccionAlumno.Text = "";
                TxtInsertarTelefonoAlumno.Text = "";
                cboCarreras.SelectedValue = null;
                TxtInsertarPrimerCurso.Text = "";
                TxtInsertarSegundoCurso.Text = "";
                TxtInsertarTercerCurso.Text = "";
                cboEstablecimiento.SelectedValue = null;
                cboSedes.SelectedValue = null;
            }
        }

        private void BtnGenerarReporteEnTexto_Click(object sender, RoutedEventArgs e)
        {
            if (ListaDeAlumnos.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)ListaDeAlumnos.SelectedItem;
                string informacionCompletaDelAlumnoSeleccionado = drv["InformacionCompletaDelAlumno"].ToString();

                try
                {
                    string consulta = $"SELECT * FROM Alumno WHERE CONCAT('Nombre: ', Nombre, '   Id del Usuario: ', IdDelUsuario, '   Nombre del Usuario: ', NombreDelUsuario, '   Carnet: ', Carnet, '   Direccion: ', Direccion, '   Telefono: ', Telefono, '   Carrera: ', Carrera, '   Nombre del primer curso: ', NombreDelPrimerCurso, '   Nombre del segundo curso: ', NombreDelSegundoCurso, '   Nombre del tercer curso: ', NombreDelTercerCurso, '   Establecimiento: ', Establecimiento, '   Sede: ', Sede) = '{informacionCompletaDelAlumnoSeleccionado}'";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtAlumno = new DataTable();
                    miAdaptadorSql.Fill(dtAlumno);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(informacionCompletaDelAlumnoSeleccionado);

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDelAlumnoSeleccionado.txt", sb.ToString());

                    MessageBox.Show("El reporte del alumno seleccionado ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
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
                    string consulta = "SELECT *, CONCAT('Nombre: ', Nombre, '   Id del Usuario: ', IdDelUsuario, '   Nombre del Usuario: ', NombreDelUsuario, '   Carnet: ', Carnet, '   Direccion: ', Direccion, '   Telefono: ', Telefono, '   Carrera: ', Carrera, '   Nombre del primer curso: ', NombreDelPrimerCurso, '   Nombre del segundo curso: ', NombreDelSegundoCurso, '   Nombre del tercer curso: ', NombreDelTercerCurso, '   Establecimiento: ', Establecimiento, '   Sede: ', Sede) AS InformacionCompletaDelAlumno FROM Alumno";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtAlumno = new DataTable();
                    miAdaptadorSql.Fill(dtAlumno);

                    StringBuilder sb = new StringBuilder();

                    foreach (DataRow row in dtAlumno.Rows)
                    {
                        sb.AppendLine(row["InformacionCompletaDelAlumno"].ToString());
                    }

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDeAlumnos.txt", sb.ToString());

                    MessageBox.Show("El reporte de los alumnos ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void BtnRegresarAlInicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }

        private void BtnAyuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Estas son las funciones de esta ventana:\n\n1. Agregar: Tienes que llenar todos los campos de texto y seleccionar un item del comboBox para poder agregar a un alumno," +
                " cuando elijas una carrera automaticamente se llenaran los campos de texto que pertenecen a los cursos, ya que cada carrera tiene sus cursos por defecto. Una vez tengas toda la informacion" +
                " tienes que darle al boton de agregar y el alumno se mostrara en la listbox con toda su informacion.\n\n2. Actualizar: Para actualizar un alumno tienes que seleccionarlo " +
                "en la listBox y luego darle al boton de actualizar, luego se abrira una ventana con toda la informacion del alumno seleccionado para poderla editar, cuando ya llenes toda la nueva informacion " +
                "del alumno, tienes que darle al boton de actualizar y te saldra una ventana preguntandote si quieres actualizar la informacion del alumno, si le das al boton de 'si' se cerrara la ventana y te dirigira " +
                "nuevamente a la ventana de alumnos donde ya tendras al alumno con la nueva informacion.\n\n3. Borrar: Para borrar un alumno tienes que seleccionarlo y darle al boton de Borrar, se te mostrara un mensaje " +
                "preguntandote si de verdad quieres eliminarlo, y si le das que 'si' el alumno sera borrado.\n\n4. Generar Reporte: Para generar un reporte individual tienes que seleccionar a un alumno y darle al boton de generar " +
                "reporte y automaticamente te generara un archivo de texto con la informacion del alumno seleccionado, ya si quieres reporte de todos los alumnos, simplemente no selecciones a ninguno y dale al boton de generar reporte " +
                "y con eso ya tendrias un nuevo archivo de texto con la informacion de todos los alumnos que aparezcan en la listbox.");
        }

        private void cboCarreras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Obtenemos el nombre de la carrera seleccionada
            string nombreDeLaCarreraSeleccionada = cboCarreras.SelectedItem.ToString();

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
                    TxtInsertarPrimerCurso.Text = dtCursos.Rows[0]["PrimerCurso"].ToString();
                    TxtInsertarSegundoCurso.Text = dtCursos.Rows[0]["SegundoCurso"].ToString();
                    TxtInsertarTercerCurso.Text = dtCursos.Rows[0]["TercerCurso"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

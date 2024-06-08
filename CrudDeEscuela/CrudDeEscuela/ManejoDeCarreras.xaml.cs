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
    /// Lógica de interacción para ManejoDeCarreras.xaml
    /// </summary>
    public partial class ManejoDeCarreras : Window
    {
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ManejoDeCarreras()
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
                        cboEstablecimientos.Items.Add(row["Nombre"].ToString());
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
            muestraDeLasCarreras();
        }

        private void muestraDeLasCarreras()
        {
            try
            {
                // creamos una consulta calculada con concat para nuestra base de datos
                // concat nos sirve para concatenar la informacion de las columnas en una fila
                string consulta = "SELECT *, CONCAT('Id de la Carrera: ', Id, '   Nombre: ', Nombre, '   Establecimiento: ', Establecimiento, '   Sede: ', Sede, '   Nombre del primer curso: ', PrimerCurso, '   Nombre del segundo curso: ', SegundoCurso, '   Nombre del tercer curso: ', TercerCurso) AS InformacionCompletaDeLaCarrera FROM Carrera";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable tablaDeCarreras = new DataTable();
                    miAdaptadorSql.Fill(tablaDeCarreras);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ListaDeCarreras.DisplayMemberPath = "InformacionCompletaDeLaCarrera";

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeCarreras.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeCarreras.ItemsSource = tablaDeCarreras.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnInsertarCarrera_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para hacer insertar un registro
                string consulta = "INSERT INTO CARRERA(Nombre,Establecimiento,Sede,PrimerCurso,SegundoCurso,TercerCurso) VALUES(@Nombre,@Establecimiento,@Sede,@PrimerCurso,@SegundoCurso,@TercerCurso)";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("Nombre", TxtInsertarCarrera.Text);
                miComandoSql.Parameters.AddWithValue("Establecimiento", cboEstablecimientos.SelectedValue);
                miComandoSql.Parameters.AddWithValue("Sede", cboSedes.SelectedValue);
                miComandoSql.Parameters.AddWithValue("PrimerCurso", TxtInsertarPrimerCurso.Text);
                miComandoSql.Parameters.AddWithValue("SegundoCurso", TxtInsertarSegundoCurso.Text);
                miComandoSql.Parameters.AddWithValue("TercerCurso", TxtInsertarTercerCurso.Text);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLasCarreras();
                MessageBox.Show($"Has agregado una carrera con exito");
                TxtInsertarCarrera.Text = "";
                cboEstablecimientos.SelectedValue = null;
                cboSedes.SelectedValue = null;
                TxtInsertarPrimerCurso.Text = "";
                TxtInsertarSegundoCurso.Text = "";
                TxtInsertarTercerCurso.Text = "";
            }
        }

        private void BtnBorrarCarrera_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres borrar la carrera seleccionada?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    // creamos una consulta parametrica para hacer posible la eliminacion de un registro
                    string consulta = "DELETE FROM Carrera WHERE Id = @IdCarrera";
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("IdCarrera", ListaDeCarreras.SelectedValue);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    muestraDeLasCarreras();
                    MessageBox.Show($"Has borrado una carrera con exito");
                }
            }
        }

        private void BtnActualizarCarrera_Click(object sender, RoutedEventArgs e)
        {
            ActualizarCarreras ventanaActualizar = new ActualizarCarreras((int)ListaDeCarreras.SelectedValue);

            try
            {
                string consulta = "SELECT Nombre,Establecimiento,Sede,PrimerCurso,SegundoCurso,TercerCurso FROM Carrera WHERE Id = @IdCarrera";

                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(miComandoSql);

                using (miAdaptadorSql)
                {
                    miComandoSql.Parameters.AddWithValue("IdCarrera", ListaDeCarreras.SelectedValue);
                    DataTable tablaDeCarreras = new DataTable();
                    miAdaptadorSql.Fill(tablaDeCarreras);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ventanaActualizar.TxtActualizaCarrera.Text = tablaDeCarreras.Rows[0]["Nombre"].ToString();
                    ventanaActualizar.cboActualizaEstablecimientoCarrera.SelectedValue = tablaDeCarreras.Rows[0]["Establecimiento"].ToString();
                    ventanaActualizar.cboActualizaSedeCarrera.SelectedValue = tablaDeCarreras.Rows[0]["Sede"].ToString();
                    ventanaActualizar.TxtActualizaPrimerCurso.Text = tablaDeCarreras.Rows[0]["PrimerCurso"].ToString();
                    ventanaActualizar.TxtActualizaSegundoCurso.Text = tablaDeCarreras.Rows[0]["SegundoCurso"].ToString();
                    ventanaActualizar.TxtActualizaTercerCurso.Text = tablaDeCarreras.Rows[0]["TercerCurso"].ToString();

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeCarreras.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeCarreras.ItemsSource = tablaDeCarreras.DefaultView;
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
            muestraDeLasCarreras();
        }

        private void BtnRegresarAlInicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }

        private void BtnIrAEstablecimiento_Click(object sender, RoutedEventArgs e)
        {
            ManejoDeEstablecimientos establecimientos = new ManejoDeEstablecimientos();
            establecimientos.Show();
            this.Close();
        }

        private void BtnGenerarReporteEnTexto_Click(object sender, RoutedEventArgs e)
        {
            if (ListaDeCarreras.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)ListaDeCarreras.SelectedItem;
                string informacionCompletaDeLaCarreraSeleccionado = drv["InformacionCompletaDeLaCarrera"].ToString();

                try
                {
                    string consulta = $"SELECT * FROM Carrera WHERE CONCAT('Id de la Carrera: ', Id, '   Nombre: ', Nombre, '   Establecimiento: ', Establecimiento, '   Sede: ', Sede, '   Nombre del primer curso: ', PrimerCurso, '   Nombre del segundo curso: ', SegundoCurso, '   Nombre del tercer curso: ', TercerCurso) = '{informacionCompletaDeLaCarreraSeleccionado}'";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtAlumno = new DataTable();
                    miAdaptadorSql.Fill(dtAlumno);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(informacionCompletaDeLaCarreraSeleccionado);

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDeLaCarreraSeleccionada.txt", sb.ToString());

                    MessageBox.Show("El reporte de la carrera seleccionada ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
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
                    string consulta = "SELECT *, CONCAT('Id de la Carrera: ', Id, '   Nombre: ', Nombre, '   Establecimiento: ', Establecimiento, '   Sede: ', Sede, '   Nombre del primer curso: ', PrimerCurso, '   Nombre del segundo curso: ', SegundoCurso, '   Nombre del tercer curso: ', TercerCurso) AS InformacionCompletaDeLaCarrera FROM Carrera";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtCarrera = new DataTable();
                    miAdaptadorSql.Fill(dtCarrera);

                    StringBuilder sb = new StringBuilder();

                    foreach (DataRow row in dtCarrera.Rows)
                    {
                        sb.AppendLine(row["InformacionCompletaDeLaCarrera"].ToString());
                    }

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDeCarreras.txt", sb.ToString());

                    MessageBox.Show("El reporte de las carreras ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void BtnAyuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Estas son las funciones de esta ventana:\n\n1. Agregar: Tienes que llenar todos los campos de texto y seleccionar un item del comboBox para poder agregar a una carrera," +
                "Una vez tengas toda la informacion" +
                " tienes que darle al boton de agregar y la carrera se mostrara en la listbox con toda su informacion.\n\n2. Actualizar: Para actualizar una carrera tienes que seleccionarla " +
                "en la listBox y luego darle al boton de actualizar, luego se abrira una ventana con toda la informacion de la carrera seleccionada para poderla editar, cuando ya llenes toda la nueva informacion " +
                "de la carrera, tienes que darle al boton de actualizar y te saldra una ventana preguntandote si quieres actualizar la informacion de la carrera, si le das al boton de 'si' se cerrara la ventana y te dirigira " +
                "nuevamente a la ventana de la carrera donde ya tendras a la carrera con la nueva informacion.\n\n3. Borrar: Para borrar una carrera tienes que seleccionarla y darle al boton de Borrar, se te mostrara un mensaje " +
                "preguntandote si de verdad quieres eliminarla, y si le das que 'si' la carrera sera borrada.\n\n4. Generar Reporte: Para generar un reporte individual tienes que seleccionar una carrera y darle al boton de generar " +
                "reporte y automaticamente te generara un archivo de texto con la informacion de la carrera seleccionada, ya si quieres reporte de todas las carreras, simplemente no selecciones a ninguna y dale al boton de generar reporte " +
                "y con eso ya tendrias un nuevo archivo de texto con la informacion de todas las carreras que aparezcan en la listbox.5. Ir a Sedes o Establecimientos: Si le das al boton de ir a sedes o ir a establecimientos, se te mostrara una nueva ventana con la informacion de las sedes " +
                "o establecimientos disponibles, ahi puedes hacer todas las funciones que se pueden hacer en esta ventana.");
        }

        private void BtnIrASedes_Click(object sender, RoutedEventArgs e)
        {
            ManejoDeSedes sedes = new ManejoDeSedes();
            sedes.Show();
            this.Close();
        }
    }
}

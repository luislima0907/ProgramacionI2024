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
    /// Lógica de interacción para ManejoDeCategoriaDeLosProductos.xaml
    /// </summary>
    public partial class ManejoDeCategoriaDeLosProductos : Window
    {
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ManejoDeCategoriaDeLosProductos()
        {
            InitializeComponent();
            // creamos una string de esta forma para poner dentro la cadena de conexion a nuestra base de datos
            // para crear la conexion se necesita el nombre del proyecto luego el metodo properties para acceder a sus propiedades
            // luego el metodo Settings para acceder a sus configuraciones y de ultimo el nombre que nos dio sql server al momento de crear la base de datos
            string miConexion = ConfigurationManager.ConnectionStrings["MiPrimerCRUD.Properties.Settings.GestionDePedidosConnectionString"].ConnectionString;

            // instanciamos la conexion a nuestra base de datos, con el constructor
            // del parametro con la cadena de conexion
            miConexionSql = new SqlConnection(miConexion);
            muestraDeLasCategorias();
        }

        public void muestraDeLasCategorias()
        {
            try
            {
                // creamos una consulta calculada con concat para nuestra base de datos
                // concat nos sirve para concatenar la informacion de las columnas en una fila
                string consulta = "SELECT *, CONCAT('Nombre: ', Nombre, '   Id de la Categoria: ', Id) AS InformacionCompletaDeLaCategoria FROM Categoria";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable tablaDeCategorias = new DataTable();
                    miAdaptadorSql.Fill(tablaDeCategorias);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ListaDeCategorias.DisplayMemberPath = "InformacionCompletaDeLaCategoria";

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeCategorias.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeCategorias.ItemsSource = tablaDeCategorias.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnActualizarCategoria_Click(object sender, RoutedEventArgs e)
        {
            ActualizarCategoria ventanaActualizar = new ActualizarCategoria((int)ListaDeCategorias.SelectedValue);

            try
            {
                string consulta = "SELECT Nombre FROM Categoria WHERE Id = @IdCategoria";

                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(miComandoSql);

                using (miAdaptadorSql)
                {
                    miComandoSql.Parameters.AddWithValue("IdCategoria", ListaDeCategorias.SelectedValue);
                    DataTable tablaDeCategorias = new DataTable();
                    miAdaptadorSql.Fill(tablaDeCategorias);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ventanaActualizar.TxtActualizaCategoria.Text = tablaDeCategorias.Rows[0]["Nombre"].ToString();
                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeCategorias.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeCategorias.ItemsSource = tablaDeCategorias.DefaultView;
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
            muestraDeLasCategorias();
        }

        private void BtnBorrarCategoria_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para hacer posible la eliminacion de un registro
                string consulta = "DELETE FROM Categoria WHERE Id=@IdCategoria";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("IdCategoria", ListaDeCategorias.SelectedValue);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLasCategorias();
                MessageBox.Show($"Has borrado la categoria con exito");
            }
        }

        private void BtnInsertarCategoria_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para insertar un registro
                string consulta = "INSERT INTO CATEGORIA(Nombre) VALUES(@Nombre)";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("Nombre", TxtInsertarCategoria.Text);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLasCategorias();
                MessageBox.Show($"Has insertado una categoria con exito");
                TxtInsertarCategoria.Text = "";
            }
        }

        private void BtnRegresarAlInicio_Click(object sender, RoutedEventArgs e)
        {
            ManejoDeProductos productos = new ManejoDeProductos();
            productos.Show();
            this.Close();
        }

        private void BtnGenerarReporteEnTexto_Click(object sender, RoutedEventArgs e)
        {
            if (ListaDeCategorias.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)ListaDeCategorias.SelectedItem;
                string informacionCompletaDeLaCategoriaSeleccionada = drv["InformacionCompletaDeLaCategoria"].ToString();

                try
                {
                    string consulta = $"SELECT * FROM Cliente WHERE CONCAT('Nombre: ', Nombre) = '{informacionCompletaDeLaCategoriaSeleccionada}'";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtCategoria = new DataTable();
                    miAdaptadorSql.Fill(dtCategoria);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(informacionCompletaDeLaCategoriaSeleccionada);

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDeLaCategoriaSeleccionada.txt", sb.ToString());

                    MessageBox.Show("El reporte de la categoria seleccionada ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
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
                    string consulta = "SELECT *, CONCAT('Nombre: ', Nombre) AS InformacionCompletaDeLaCategoria FROM Categoria";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtCategoria = new DataTable();
                    miAdaptadorSql.Fill(dtCategoria);

                    StringBuilder sb = new StringBuilder();

                    foreach (DataRow row in dtCategoria.Rows)
                    {
                        sb.AppendLine(row["InformacionCompletaDeLaCategoria"].ToString());
                    }

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDeLasCategorias.txt", sb.ToString());

                    MessageBox.Show("El reporte de las categorias ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}

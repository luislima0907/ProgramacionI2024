using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace MiPrimerCRUD
{
    /// <summary>
    /// Lógica de interacción para ActualizarCategoria.xaml
    /// </summary>
    public partial class ActualizarCategoria : Window
    {
        // esta variable nos servira para guardar el id del producto que venga desde otro formulario
        private int IdDeLaCategoriaDesdeOtraVentana;
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ActualizarCategoria(int IdCategoria)
        {
            InitializeComponent();
            IdDeLaCategoriaDesdeOtraVentana = IdCategoria;

            // creamos una string de esta forma para poner dentro la cadena de conexion a nuestra base de datos
            // para crear la conexion se necesita el nombre del proyecto luego el metodo properties para acceder a sus propiedades
            // luego el metodo Settings para acceder a sus configuraciones y de ultimo el nombre que nos dio sql server al momento de crear la base de datos
            string miConexion = ConfigurationManager.ConnectionStrings["MiPrimerCRUD.Properties.Settings.GestionDePedidosConnectionString"].ConnectionString;

            // instanciamos la conexion a nuestra base de datos, con el constructor
            // del parametro con la cadena de conexion
            miConexionSql = new SqlConnection(miConexion);

        }

        private void BtnActualizarCategoria_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres actualizar la informacion de la categoria?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    // creamos una consulta parametrica para hacer posible la actualizacion de un registro
                    string consulta = $"UPDATE Categoria SET Nombre = @Nombre WHERE Id = {IdDeLaCategoriaDesdeOtraVentana}";
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("@Nombre", TxtActualizaCategoria.Text);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    MessageBox.Show($"Has actualizado la categoria con exito");
                    TxtActualizaCategoria.Text = "";
                    // this hace referencia a los objetos de una clase
                    this.Close();
                }
            }
        }

        private void BtnRegresaAVentanaCategorias_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace MiPrimerCRUD
{
    /// <summary>
    /// Lógica de interacción para ManejoDeProductos.xaml
    /// </summary>
    public partial class ManejoDeProductos : Window
    {
        // creamos un objeto de tipo sqlconection para conectar nuestra base de datos y poder hacer consultas
        SqlConnection miConexionSql;
        public ManejoDeProductos()
        {
            InitializeComponent();
            // creamos una string de esta forma para poner dentro la cadena de conexion a nuestra base de datos
            // para crear la conexion se necesita el nombre del proyecto luego el metodo properties para acceder a sus propiedades
            // luego el metodo Settings para acceder a sus configuraciones y de ultimo el nombre que nos dio sql server al momento de crear la base de datos
            string miConexion = ConfigurationManager.ConnectionStrings["MiPrimerCRUD.Properties.Settings.GestionDePedidosConnectionString"].ConnectionString;

            // instanciamos la conexion a nuestra base de datos, con el constructor
            // del parametro con la cadena de conexion
            miConexionSql = new SqlConnection(miConexion);

            try
            {
                // creamos una consulta para nuestra base de datos
                string consulta = "SELECT Nombre FROM Categoria";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                // Creamos un DataTable para almacenar los resultados de la consulta
                DataTable dtCategorias = new DataTable();

                using (miAdaptadorSql)
                {
                    // Llenamos el DataTable con los resultados de la consulta
                    miAdaptadorSql.Fill(dtCategorias);

                    // Recorremos cada fila del DataTable
                    foreach (DataRow row in dtCategorias.Rows)
                    {
                        // Agregamos el nombre de la categoría al ComboBox
                        cboCategorias.Items.Add(row["Nombre"].ToString());
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
                string consulta = "SELECT Nombre FROM Proveedor";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                // Creamos un DataTable para almacenar los resultados de la consulta
                DataTable dtProveedores = new DataTable();

                using (miAdaptadorSql)
                {
                    // Llenamos el DataTable con los resultados de la consulta
                    miAdaptadorSql.Fill(dtProveedores);

                    // Recorremos cada fila del DataTable
                    foreach (DataRow row in dtProveedores.Rows)
                    {
                        // Agregamos el nombre de la categoría al ComboBox
                        cboProveedores.Items.Add(row["Nombre"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            muestraDeLosProductos();
        }

        // creamos un metodo para llamar los registros de nuestros productos
        private void muestraDeLosProductos()
        {
            try
            {
                // creamos una consulta calculada con concat para nuestra base de datos
                // concat nos sirve para concatenar la informacion de las columnas en una fila
                string consulta = "SELECT *, CONCAT('Categoria: ', Seccion, '   Nombre: ', NombreDelArticulo, '   Precio: ', Precio, '   Fecha: ', Fecha, '   Origen: ', PaisDeOrigen, '   Proveedor: ', Proveedor, '   Cantidad: ', Cantidad) AS InformacionCompletaDelProducto FROM Articulo";

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable tablaDeProductos = new DataTable();
                    miAdaptadorSql.Fill(tablaDeProductos);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ListaDeProductos.DisplayMemberPath = "InformacionCompletaDelProducto";

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeProductos.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeProductos.ItemsSource = tablaDeProductos.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void BtnActualizarProducto_Click(object sender, RoutedEventArgs e)
        {
            ActualizarProducto ventanaActualizar = new ActualizarProducto((int)ListaDeProductos.SelectedValue);

            try
            {
                string consulta = "SELECT Seccion,NombreDelArticulo,Precio,PaisDeOrigen,Proveedor,Cantidad FROM Articulo WHERE Id = @IdProducto";

                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);

                // con esto le decimos a la base de datos que ejecute la consulta que construimos en una string
                // y que lo ejecute en la conexion hacia nuestra base de datos
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(miComandoSql);

                using (miAdaptadorSql)
                {
                    miComandoSql.Parameters.AddWithValue("IdProducto", ListaDeProductos.SelectedValue);
                    DataTable tablaDeProductos = new DataTable();
                    miAdaptadorSql.Fill(tablaDeProductos);

                    // decimos cual informacion de alguna columna en nuestras tablas queremos ver en el listbox que creamos
                    ventanaActualizar.TxtActualizaSeccionProducto.Text = tablaDeProductos.Rows[0]["Seccion"].ToString();
                    ventanaActualizar.TxtActualizaProducto.Text = tablaDeProductos.Rows[0]["NombreDelArticulo"].ToString();
                    ventanaActualizar.TxtActualizaPrecioProducto.Text = tablaDeProductos.Rows[0]["Precio"].ToString();
                    //ventanaActualizar.TxtActualizaFechaProducto.Text = tablaDeProductos.Rows[0]["Fecha"].ToString();
                    ventanaActualizar.TxtActualizaOrigenProducto.Text = tablaDeProductos.Rows[0]["PaisDeOrigen"].ToString();
                    ventanaActualizar.cboProveedores.SelectedValue = tablaDeProductos.Rows[0]["Proveedor"].ToString();
                    ventanaActualizar.TxtActualizaCantidadProducto.Text = tablaDeProductos.Rows[0]["Cantidad"].ToString();

                    // seleccionamos el elemento de la tabla segun su id
                    ListaDeProductos.SelectedValuePath = "Id";

                    // Especificamos de donde viene la informacion para llenarla en el listbox
                    ListaDeProductos.ItemsSource = tablaDeProductos.DefaultView;
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
            muestraDeLosProductos();
        }

        private void BtnBorrarProducto_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Quieres borrar el producto seleccionado?", "Mensaje", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    // creamos una consulta parametrica para hacer posible la eliminacion de un registro
                    string consulta = "DELETE FROM Articulo WHERE Id = @IdProducto";
                    SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                    miConexionSql.Open();
                    miComandoSql.Parameters.AddWithValue("IdProducto", ListaDeProductos.SelectedValue);
                    miComandoSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    miConexionSql.Close();
                    muestraDeLosProductos();
                    MessageBox.Show($"Has borrado el producto con exito");
                }
            }
        }

        private void BtnInsertarProducto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // creamos una consulta parametrica para insertar un registro
                string consulta = "INSERT INTO ARTICULO(Seccion,NombreDelArticulo,Precio,PaisDeOrigen,Cantidad,Proveedor) VALUES(@Seccion,@NombreDelArticulo,@Precio,@PaisDeOrigen,@Cantidad,@Proveedor)";
                SqlCommand miComandoSql = new SqlCommand(consulta, miConexionSql);
                miConexionSql.Open();
                miComandoSql.Parameters.AddWithValue("Seccion", cboCategorias.SelectedValue);
                miComandoSql.Parameters.AddWithValue("NombreDelArticulo", TxtInsertarProducto.Text);
                miComandoSql.Parameters.AddWithValue("Precio", TxtInsertarPrecioProducto.Text);
                //miComandoSql.Parameters.AddWithValue("Fecha", TxtInsertarFechaProducto.Text);
                miComandoSql.Parameters.AddWithValue("PaisDeOrigen", TxtInsertarOrigenProducto.Text);
                miComandoSql.Parameters.AddWithValue("Cantidad", TxtInsertarCantidadProducto.Text);
                miComandoSql.Parameters.AddWithValue("Proveedor", cboProveedores.SelectedValue);
                miComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                muestraDeLosProductos();
                MessageBox.Show($"Has insertado un producto con exito");
                TxtInsertarProducto.Text = "";
                TxtInsertarPrecioProducto.Text = "";
                //TxtInsertarFechaProducto.Text = "";
                TxtInsertarOrigenProducto.Text = "";
                TxtInsertarCantidadProducto.Text = "";
                cboProveedores.SelectedValue = null;
            }
        }

        private void BtnRegresarAlInicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }

        private void BtnIrACategoria_Click(object sender, RoutedEventArgs e)
        {
            ManejoDeCategoriaDeLosProductos categorias = new ManejoDeCategoriaDeLosProductos();
            categorias.Show();
            this.Close();
        }

        private void TxtInsertarCantidadProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            int cantidad = int.Parse(TxtInsertarCantidadProducto.Text);
            // Validar que la cantidad no sea menor a 0
            if (cantidad < 0)
            {
                    MessageBox.Show("La cantidad no puede ser menor a 0.");
                    TxtInsertarCantidadProducto.Text = "";
                    return;
            }
        }

        private void TxtInsertarPrecioProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            int cantidad = int.Parse(TxtInsertarPrecioProducto.Text);
            // Validar que el precio no sea menor a 0
            if (cantidad < 0)
            {
                MessageBox.Show("La cantidad no puede ser menor a 0.");
                TxtInsertarPrecioProducto.Text = "";
                return;
            }
        }

        private void BtnIrAProveedores_Click(object sender, RoutedEventArgs e)
        {
            ManejoDeProveedores proveedores = new ManejoDeProveedores();
            proveedores.Show();
            this.Close();
        }

        private void BtnGenerarReporteEnTexto_Click(object sender, RoutedEventArgs e)
        {
            if (ListaDeProductos.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)ListaDeProductos.SelectedItem;
                string informacionCompletaDelProductoSeleccionado = drv["InformacionCompletaDelProducto"].ToString();

                try
                {
                    string consulta = $"SELECT * FROM Articulo WHERE CONCAT('Categoria: ', Seccion, '   Nombre: ', NombreDelArticulo, '   Precio: ', Precio, '   Fecha: ', Fecha, '   Origen: ', PaisDeOrigen, '   Proveedor: ', Proveedor, '   Cantidad: ', Cantidad) = '{informacionCompletaDelProductoSeleccionado}'";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtProducto = new DataTable();
                    miAdaptadorSql.Fill(dtProducto);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(informacionCompletaDelProductoSeleccionado);

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDelProductoSeleccionado.txt", sb.ToString());

                    MessageBox.Show("El reporte del producto seleccionado ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
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
                    string consulta = "SELECT *, CONCAT('Categoria: ', Seccion, '   Nombre: ', NombreDelArticulo, '   Precio: ', Precio, '   Fecha: ', Fecha, '   Origen: ', PaisDeOrigen, '   Proveedor: ', Proveedor, '   Cantidad: ', Cantidad) AS InformacionCompletaDelProducto FROM Articulo";

                    SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
                    DataTable dtProductos = new DataTable();
                    miAdaptadorSql.Fill(dtProductos);

                    StringBuilder sb = new StringBuilder();

                    foreach (DataRow row in dtProductos.Rows)
                    {
                        sb.AppendLine(row["InformacionCompletaDelProducto"].ToString());
                    }

                    File.WriteAllText(@"C:\Users\ruben\OneDrive\Desktop\ReporteDeProductos.txt", sb.ToString());

                    MessageBox.Show("El reporte de productos ha sido generado exitosamente. Puede ver el archivo en su escritorio.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void BtnAyuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Estas son las funciones de esta ventana:\n\n1. Agregar: Tienes que llenar todos los campos de texto que te aparecen junto con los valores que elijas en los comboBox, luego le das click al boton de agregar y con eso ya se registraria el producto en la listbox" +
                    "\n\n2. Actualizar: Para actualizar un un producto tienes que seleccionarlo " +
                    "en la listBox y luego darle al boton de actualizar, luego se abrira una ventana con toda la informacion del producto seleccionado para poderla editar, cuando ya llenes toda la nueva informacion " +
                    "del producto, tienes que darle al boton de actualizar y te saldra una ventana preguntandote si quieres actualizar la informacion del producto, si le das al boton de 'si' se cerrara la ventana y te dirigira " +
                    "nuevamente a la ventana de productos donde ya tendras al producto con la nueva informacion.\n\n3. Borrar: Para borrar un producto tienes que seleccionarlo y darle al boton de Borrar, se te mostrara un mensaje " +
                    "preguntandote si de verdad quieres eliminarlo, y si le das que 'si' el producto sera borrado.\n\n4. Generar Reporte: Para generar un reporte individual tienes que seleccionar a un producto y darle al boton de generar " +
                    "reporte y automaticamente te generara un archivo de texto con la informacion del producto seleccionado, ya si quieres reporte de todos los productos, simplemente no selecciones a ninguno y dale al boton de generar reporte " +
                    "y con eso ya tendrias un nuevo archivo de texto con la informacion de todos los productos que aparezcan en la listbox.\n\n5. Ir a Categorias o Proveedores: Si le das a cualquiera de esos dos botones te abrira una ventana donde puedes" +
                    " hacer todas lsa funciones de esta ventana solo que con la informacion del boton que elijas en este caso la informacion de los proveedores o categorias.");
        }
    }
}

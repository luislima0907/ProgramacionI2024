using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoDeTotito
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Indicamos el turno de cada jugador, se inicia primero en 1, ya que representa al primer jugador
        int turno = 1;

        // creamos una variable que ira aumentando hasta 9 para definir si hay empate o no, su valor se incrementara en uno cada vez que se llame a la funcion Ganador()
        int empate = 0;

        //
        int contadorJugadorUno = 0;
        int contadorJugadorDos = 0;
        int contadorEmpates = 0;


        private void AgregarPuntos()
        {
            if (turno == 1) contadorJugadorUno++;
            else if (turno == 2) contadorJugadorDos++;
            ReiniciarJuego();
        }

        private void ReiniciarJuego()
        {
            lblJugadorUno.Text = contadorJugadorUno.ToString();
            lblJugadorDos.Text = contadorJugadorDos.ToString();
            lblEmpates.Text = contadorEmpates.ToString();
            // Se dejan todos los botones en blanco para que se puedan rellenar nuevamente
            btnUno.Text = "";
            btnDos.Text = "";
            btnTres.Text = "";
            btnCuatro.Text = "";
            btnCinco.Text = "";
            btnSeis.Text = "";
            btnSiete.Text = "";
            btnOcho.Text = "";
            btnNueve.Text = "";

            // creamos un metodo para reniciar el juego, dejando el contador del empate en 0 para que se borre el progreso anterior y no genere conflictos al llegar a 9, ya que ahi salta un mensaje para aclarar el desempate
            empate = 0;

            // aqui decimos que si el jugador 1 (X) gano en la anterior partida, entonces que le de la oportunidad al jugador 2 (O) para empezar en la otra partida
            if (turno == 1) turno = 2;
            else turno = 1;
        }
        private void Ganador()
        {
            empate++;
            if (btnUno.Text == btnDos.Text && btnUno.Text == btnTres.Text && btnUno.Text != "")
            {
                MessageBox.Show($"Ha ganado el jugador {turno}");
                AgregarPuntos();
            }
            if (btnCuatro.Text == btnCinco.Text && btnCuatro.Text == btnSeis.Text && btnCuatro.Text != "")
            {
                MessageBox.Show($"Ha ganado el jugador {turno}");
                AgregarPuntos();
            }
            if (btnSiete.Text == btnOcho.Text && btnSiete.Text == btnNueve.Text && btnSiete.Text != "")
            {
                MessageBox.Show($"Ha ganado el jugador {turno}");
                ReiniciarJuego();
            }
            if (btnUno.Text == btnCuatro.Text && btnUno.Text == btnSiete.Text && btnUno.Text != "")
            {
                MessageBox.Show($"Ha ganado el jugador {turno}");
                AgregarPuntos();
            }
            if (btnDos.Text == btnCinco.Text && btnDos.Text == btnOcho.Text && btnDos.Text != "")
            {
                MessageBox.Show($"Ha ganado el jugador {turno}");
                AgregarPuntos();
            }
            if (btnTres.Text == btnSeis.Text && btnTres.Text == btnNueve.Text && btnTres.Text != "")
            {
                MessageBox.Show($"Ha ganado el jugador {turno}");
                AgregarPuntos();
            }
            if (btnUno.Text == btnCinco.Text && btnUno.Text == btnNueve.Text && btnUno.Text != "")
            {
                MessageBox.Show($"Ha ganado el jugador {turno}");
                AgregarPuntos();
            }
            if (btnTres.Text == btnCinco.Text && btnTres.Text == btnSiete.Text && btnTres.Text != "")
            {
                MessageBox.Show($"Ha ganado el jugador {turno}");
                AgregarPuntos();
            }
            if (empate == 9)
            {
                MessageBox.Show("Ningún jugador gano, esto es un empate");
                contadorEmpates++;
                ReiniciarJuego();
            }
        }

        // Hacemos un metodo para escribir X u O en el tablero del totito y luego lo llamamos en cada boton al momento de hacer click sobre el
        private void escribirXuO(Button a)
        {
            // si el boton no tiene X u O asignados dentro de el, entonces que le asigne X u O dependiendo del turno
            if (a.Text == "")
            {
                if (turno == 1)
                {
                    a.Text = "X";
                    Ganador();
                    turno = 2;
                }
                else if (turno == 2)
                {
                    a.Text = "O";
                    Ganador();
                    turno = 1;
                }
            }
            // si el boton ya tiene asignado X u O, entonces que le muestre el siguiente mensaje, esto se hace para que no se pueda alterar el tablero una vez ya tenga X u O asignados dentro
            else if (a.Text != "")
            {
                MessageBox.Show("No puede volver a editar la misma casilla, intentelo con otra");
            }
        }

        // creamos un evento en cada boton al momento de hacer click sobre el.
        private void btnUno_Click(object sender, EventArgs e)
        {
            escribirXuO(btnUno);
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            escribirXuO(btnDos);
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            escribirXuO(btnTres);
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            escribirXuO(btnCuatro);
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            escribirXuO(btnCinco);
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            escribirXuO(btnSeis);
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            escribirXuO(btnSiete);
        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            escribirXuO(btnOcho);
        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            escribirXuO(btnNueve);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

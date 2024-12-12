using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{

    public partial class Form1 : Form
    {

        //Variables para usar en cada metodo
        string playerX = "";
        string playerO = "";
        bool cambio = true;
        int empate = 0;
        int ganadasX = 0;
        int ganadasO = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OnOffBtn(false);
        }

        //Funcionalidad a cada cuadro para marcar signo
        private void OnOffBtn(bool onoff)
        {
            a1.Enabled = onoff;
            a2.Enabled = onoff;
            a3.Enabled = onoff;
            b1.Enabled = onoff;
            b2.Enabled = onoff;
            b3.Enabled = onoff;
            c1.Enabled = onoff;
            c2.Enabled = onoff;
            c3.Enabled = onoff;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void Ingresar()
        {
            //Cuando ninguno de los jugadores ingresa un nombre
            if (txtUser1.Text == "" && txtUser2.Text == "")
            {
                //Mensaje de advertencia
                MessageBox.Show("El nombre de los jugadores no puede ser null", "Nombre invalido"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }

            //En caso de que cada usuario no ingrese un nombre
            else
            {
                if (txtUser1.Text == "")
                {
                    MessageBox.Show("El nombre del Player1 no puede ser null", "Nombre invalido"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                }
                if (txtUser2.Text == "")
                {
                    MessageBox.Show("El nombre del Player2 no puede ser null", "Nombre invalido"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                }
            }

            //Cuando el usuario ingresa un nombre
            if (txtUser1.Text != "" && txtUser2.Text != "")
            {
                //Seleccion de X a Player1 y O a Player 2
                if (RbUser1X.Checked && RbUser2O.Checked)
                {
                    //Iguala el signo a cada jugador
                    playerX = txtUser1.Text;
                    playerO = txtUser2.Text;

                    //Desactiva el otro signo que no se escogio
                    RbUser1O.Enabled = false;
                    RbUser2X.Enabled = false;

                    //Inicializar
                    PlayGame();
                }

                //Seleccion de O a Player1 y X a Player 2
                if (RbUser1O.Checked && RbUser2X.Checked)
                {
                    //Iguala el signo a cada jugador
                    playerO = txtUser1.Text;
                    playerX = txtUser2.Text;

                    //Desactiva el otro signo que no se escogio
                    RbUser1X.Enabled = false;
                    RbUser2O.Enabled = false;

                    //Inicializa el juego
                    PlayGame();
                }


                //En caso de que seleccionen X
                if (RbUser1X.Checked && RbUser2X.Checked)
                {
                    //Mensaje de advertencia
                    MessageBox.Show("Solo un jugador puede escoger la letra X", "Escoja una letra diferente"
                   , MessageBoxButtons.OK
                   , MessageBoxIcon.Information);
                }

                //En caso de que seleccionen O
                if (RbUser1O.Checked && RbUser2O.Checked)
                {
                    //Mensaje de advertencia
                    MessageBox.Show("Solo un jugador puede escoger la letra O", "Escoja una letra diferente"
                   , MessageBoxButtons.OK
                   , MessageBoxIcon.Information);
                }

                //En caso de no seleccionar signo, primer escenario
                if (!RbUser2X.Checked && !RbUser2O.Checked)
                {
                    //Mensaje de advertencia
                    MessageBox.Show("Player 2 debe escoger una letra", "Escoja una letra"
                   , MessageBoxButtons.OK
                   , MessageBoxIcon.Information);
                }
            }
        }

        //Agrega nombre a los jugadores
        private void PlayGame()
        {
            Player1.Text = txtUser1.Text;
            Player2.Text = txtUser2.Text;

            ptsPlayer1.Visible = true;
            ptsPlayer2.Visible = true;

            groupBox1.Text = "Score";

            btnLimpiar.Visible = true;
            btnReiniciar.Visible = true;

            btnNewGame.Visible = false;
            txtUser1.Visible = false;
            txtUser2.Visible = false;

            //Mensaje de advertencia
            MessageBox.Show("Empieza " + playerX, "Informacion"
           , MessageBoxButtons.OK
           , MessageBoxIcon.Information);

            OnOffBtn(true);
        }

        //Reinicia el juego, ocultando y mostrando ciertos botones nuevamente
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            // Limpia el tablero y desactiva los botones
            Limpiar();
            OnOffBtn(false);

            // Oculta botones de limpieza y reinicio
            btnLimpiar.Visible = false;
            btnReiniciar.Visible = false;

            // Restablece cuadros de texto y nombres de jugadores
            txtUser1.Visible = true;
            txtUser2.Visible = true;
            txtUser1.Text = "";
            txtUser2.Text = "";

            // Restablece variables de puntajes y estados
            playerX = "";
            playerO = "";
            ganadasX = 0;
            ganadasO = 0;
            empate = 0;
            cambio = true;

            // Restablece las etiquetas de puntajes
            ptsPlayer1.Text = "0";
            ptsPlayer2.Text = "0";
            Player1.Text = "";
            Player2.Text = "";

            // Habilita nuevamente la selección de signos
            RbUser1O.Enabled = true;
            RbUser2X.Enabled = true;
            RbUser1X.Enabled = true;
            RbUser2O.Enabled = true;

            // Desmarca los radio buttons de selección de signos
            RbUser1X.Checked = false;
            RbUser1O.Checked = false;
            RbUser2X.Checked = false;
            RbUser2O.Checked = false;

            // Oculta puntajes y reinicia el grupo de jugadores
            ptsPlayer1.Visible = false;
            ptsPlayer2.Visible = false;
            groupBox1.Text = "Players";

            // Restablece el botón para empezar un nuevo juego
            btnNewGame.Visible = true;
        }

        //Representa todos los botones
        private void Buttons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (cambio)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            cambio = !cambio;
            b.Enabled = false;
            Partida();
        }

        private void Partida()
        {
            //Formas de Ganar Horizontal
            if ((a1.Text == a2.Text) && (a2.Text == a3.Text) && (!a1.Enabled))
            {
                Validacion(a1);
            }
            else if ((b1.Text == b2.Text) && (b2.Text == b3.Text) && (!b1.Enabled))
            {
                Validacion(b1);
            }
            else if ((c1.Text == c2.Text) && (c2.Text == c3.Text) && (!c1.Enabled))
            {
                Validacion(c1);
            }

            //Formas de Ganar Vertical
            if ((a1.Text == b1.Text) && (b1.Text == c1.Text) && (!a1.Enabled))
            {
                Validacion(a1);
            }
            else if ((a2.Text == b2.Text) && (b2.Text == c2.Text) && (!a2.Enabled))
            {
                Validacion(a2);
            }
            else if ((a3.Text == b3.Text) && (b3.Text == c3.Text) && (!a3.Enabled))
            {
                Validacion(a3);
            }

            //Formas de Ganar Diagonal
            if ((a1.Text == b2.Text) && (b2.Text == c3.Text) && (!a1.Enabled))
            {
                Validacion(a1);
            }
            else if ((a3.Text == b2.Text) && (b2.Text == c1.Text) && (!a3.Enabled))
            {
                Validacion(a3);
            }

            //Empate
            empate++;
            if (empate == 9)
            {
                MessageBox.Show("Es un Empate!!", "Empate"
                , MessageBoxButtons.OK
                , MessageBoxIcon.Information);

                Limpiar();

                OnOffBtn(true);
                empate = 0;
            }

        }

        //Metodo para validar un ganador
        public void Validacion(Button b)
        {
            empate = -1;

            if (b.Text == "X")
            {
                MessageBox.Show("The Winner is " + playerX
                    , " Congratulations!"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                //Suma 1 cada vez que X gana
                ganadasX++;
            }
            else if (b.Text == "O")
            {
                MessageBox.Show("The Winner is " + playerO
                    , " Congratulations!"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                //Suma 1 cada vez que O gana
                ganadasO++;
            }


            if (RbUser1X.Checked && RbUser2O.Checked)
            {
                ptsPlayer1.Text = ganadasX.ToString();
                ptsPlayer2.Text = ganadasO.ToString();
            }

            if (RbUser1O.Checked && RbUser2X.Checked)
            {
                ptsPlayer1.Text = ganadasO.ToString();
                ptsPlayer2.Text = ganadasX.ToString();
            }

            //Cuando todo lo anterior se cumpla, se limpian las casillas 
            Limpiar();
            OnOffBtn(true); //Se activa boton On/Off
        }

        //Limpia los simbolos en cada cuadro
        private void Limpiar()
        {
            a1.Text = "";
            a2.Text = "";
            a3.Text = "";
            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            c1.Text = "";
            c2.Text = "";
            c3.Text = "";
        }

        //Limpia los botones y da valor 0 a empate
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            OnOffBtn(true);
            empate = 0;
        }
    }
}

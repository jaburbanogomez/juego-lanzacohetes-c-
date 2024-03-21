using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace JuegoLanzaCohetesJB
{
    public partial class Form1 : Form
    {
        public int puntaje = 0;
        public int vidas = 3;
        String ruta_vida = "C:/Users/JORGE BURBANO/Documents/Visual Studio 2017/StartPages/JorgeBurbano/JuegoLanzaCohetesJB/JuegoLanzaCohetesJB/Resources/";
        //String ruta_barco = "C:/Users/JORGE BURBANO/Documents/Visual Studio 2017/StartPages/JorgeBurbano/JuegoLanzaCohetesJB/JuegoLanzaCohetesJB/Resources/";
        public System.Media.SoundPlayer musica = new System.Media.SoundPlayer();
        public Form1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            timer1.Stop();
            misil1.Visible = false;           
            misil2.Visible = false;
            misil3.Visible = false;
            misil4.Visible = false;
            misil5.Visible = false;
            misil6.Visible = false;
            misil7.Visible = false;
            misil8.Visible = false;
            misil9.Visible = false;
            misil10.Visible = false;
            barco.Visible = false;
            pirata1.Visible = false;
            pirata2.Visible = false;
            pirata3.Visible = false;
            pirata4.Visible = false;
            pirata5.Visible = false;
            pirata6.Visible = false;
            
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Define la velocidad en la que se desplaza el objeto
            misil1.Left = misil1.Left - 10;
            misil2.Left = misil2.Left - 10;
            misil3.Left = misil3.Left - 10;
            misil4.Left = misil4.Left - 10;
            misil5.Left = misil5.Left - 10;
            misil6.Left = misil6.Left - 10;
            misil7.Left = misil7.Left - 10;
            misil8.Left = misil8.Left - 10;
            misil9.Left = misil9.Left - 10;
            misil10.Left = misil10.Left - 10;

            //Define la posicion en x y el tiempo en reaparecer
            if (misil1.Location.X < -60)
            {
                //Nueva posicion que toma el objeto
                misil1.Location = new Point(940, 155);
            }
            if (misil2.Location.X < -60)
            {
                misil2.Location = new Point(940, 252);

            }
            if (misil3.Location.X < -60)
            {
                misil3.Location = new Point(940, 347);

            }
            if (misil4.Location.X < -60)
            {
                misil4.Location = new Point(940, 446);

            }
            if (misil5.Location.X < -60)
            {
                misil5.Location = new Point(940, 203);

            }
            if (misil6.Location.X < -60)
            {
                misil6.Location = new Point(940, 294);

            }
            if (misil7.Location.X < -60)
            {
                misil7.Location = new Point(940, 393);

            }
            if (misil8.Location.X < -60)
            {
                misil8.Location = new Point(900, 203);

            }
            if (misil9.Location.X < -60)
            {
                misil9.Location = new Point(900, 293);

            }
            if (misil10.Location.X < -60)
            {
                misil10.Location = new Point(900, 393);

            }

            //comprueba si choca el barco con los misiles
            verificarColision(misil1);
            verificarColision(misil2);
            verificarColision(misil3);
            verificarColision(misil4);
            verificarColision(misil5);
            verificarColision(misil6);
            verificarColision(misil7);
            verificarColision(misil8);
            verificarColision(misil9);
            verificarColision(misil10);
            //comprueba si choca el barco con los piratas
            verificarPirata(pirata1);
            verificarPirata(pirata2);
            verificarPirata(pirata3);
            verificarPirata(pirata4);
            verificarPirata(pirata5);
            verificarPirata(pirata6);          
                        
        }//Cierre timer

        public void verificarColision(PictureBox misil)
        {
            if (barco.Bounds.IntersectsWith(misil.Bounds))
            {
                vidas = vidas - 1;
                barco.Location = new Point(12, 104);
                //barco.Image = Image.FromFile(ruta_barco + "explosion_barco.png");
                
                //timer1.Stop();
                //if (timer1.Interval==15)
                //{
                //    barco.Location = new Point(3, 110);
                //   barco.Image = Image.FromFile(ruta_barco + "barquito.png");
                //    timer1.Interval = 15; ;
                
                //}
                if (vidas == 2)
                {
                    vida3.Image = Image.FromFile(ruta_vida + "corazonnegro.png");

                }
                if (vidas == 1)
                {
                    vida2.Image = Image.FromFile(ruta_vida + "corazonnegro.png");
                }
                if (vidas == 0)
                {
                    vida1.Image = Image.FromFile(ruta_vida + "corazonnegro.png");                    
                    gameOver();
                }
            }
        }
        public void verificarPirata(PictureBox pirata)
        {
            if (barco.Bounds.IntersectsWith(pirata.Bounds))
            {                
                puntaje = puntaje + 20;
                label3.Text = " " + puntaje;
                pirata.Location = new Point(786, 27);
                pirata.Visible = false;
                if (puntaje == 120)
                {
                    gameWon();                  
                   
                }            
                
            }
        }

        public void gameOver()
        {
            timer1.Stop();           
            Perdiste Intenta = new Perdiste();
            Intenta.Show();
            misil1.Visible = false;
            misil2.Visible = false;
            misil3.Visible = false;
            misil4.Visible = false;
            misil5.Visible = false;
            misil6.Visible = false;
            misil7.Visible = false;
            misil8.Visible = false;
            misil9.Visible = false;
            misil10.Visible = false;
            barco.Visible = false;
            pirata1.Visible = false;
            pirata2.Visible = false;
            pirata3.Visible = false;
            pirata4.Visible = false;
            pirata5.Visible = false;
            pirata6.Visible = false;
            pictureBox9.Visible = true;

        }
        public void gameWon()
        {
            timer1.Stop();
            Ganador Intenta = new Ganador();
            Intenta.Show();
            misil1.Visible = false;
            misil2.Visible = false;
            misil3.Visible = false;
            misil4.Visible = false;
            misil5.Visible = false;
            misil6.Visible = false;
            misil7.Visible = false;
            misil8.Visible = false;
            misil9.Visible = false;
            misil10.Visible = false;
            barco.Visible = false;
            pictureBox9.Visible = true;

        }

        //Mueve el Barco con el Teclado
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                barco.Left = barco.Left + 9;
            }
            if (e.KeyCode == Keys.Left)
            {
                barco.Left = barco.Left - 9;
            }
            if (e.KeyCode == Keys.Up)
            {
                barco.Top = barco.Top - 9;
            }
            if (e.KeyCode == Keys.Down)
            {
                barco.Top = barco.Top + 9;
            }
        }

        //Iniciar Juego
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //musica.Stream = Properties.Resources.cancion_juego;
            //musica.Play();
            timer1.Start();
            misil1.Visible = true;
            misil2.Visible = true;
            misil3.Visible = true;
            misil4.Visible = true;
            misil5.Visible = true;
            misil6.Visible = true;
            misil7.Visible = true;
            misil8.Visible = true;
            misil9.Visible = true;
            misil10.Visible = true;
            barco.Visible = true;
            pirata1.Visible = true;
            pirata2.Visible = true;
            pirata3.Visible = true;
            pirata4.Visible = true;
            pirata5.Visible = true;
            pirata6.Visible = true;
            pirata1.Location = new Point(556, 155);
            pirata2.Location = new Point(556, 443);
            pirata3.Location = new Point(720, 289);
            pirata4.Location = new Point(550, 334);
            pirata5.Location = new Point(786, 203);
            pirata6.Location = new Point(791, 393);
            barco.Location = new Point(12, 104);
            vidas = 3;                        
            puntaje = 0;
            label3.Text = "0";
            vida3.Image = Image.FromFile(ruta_vida + "corazon2.png");
            vida2.Image = Image.FromFile(ruta_vida + "corazon2.png");
            vida1.Image = Image.FromFile(ruta_vida + "corazon2.png");
            pictureBox9.Visible = false;
            
        }

    }//Fin Clase
}//Fin Name

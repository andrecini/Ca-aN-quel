using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

namespace ProjetoCacaNiquel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //ClearPictureColumn('A');
            //ClearPictureColumn('B');
            //ClearPictureColumn('C');
        }

        private static Random random = new Random();
        private bool ativaMovimentoA = false;
        private bool ativaMovimentoB = false;
        private bool ativaMovimentoC = false;
        private static int contadorTempo = 1;
        private static int deslocamento = 25;
        private static int multiplicadorVoltas;
        private static int voltaCompleta = 4;
        private static char[] columns = { 'A', 'B', 'C' };
        private static int indexColumns = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            SetPictureColumn(columns[indexColumns]);
            AtivaTimer(columns[indexColumns], timer1);

            if (indexColumns == 2)
            {
                indexColumns = 0;
            }
            else
            {
                indexColumns++;
            }

        }

        #region Controle Movimento das PictureBox's

        public void Movimenta(bool ativaMovimento, PictureBox pic1, PictureBox pic2, PictureBox pic3, PictureBox pic4, PictureBox pic5)
        {
            if (ativaMovimento)
            {
                pic1.Top -= deslocamento;
                pic2.Top -= deslocamento;
                pic3.Top -= deslocamento;
                pic4.Top -= deslocamento;
                pic5.Top -= deslocamento;
            }
        }

        public void VerificaExtremos(bool ativaMovimento, PictureBox pic1, PictureBox pic2, PictureBox pic3, PictureBox pic4, PictureBox pic5)
        {
            if (ativaMovimento)
            {
                if (pic1.Top <= -200)
                {
                    pic1.Top = 300;
                }
                if (pic2.Top <= -200)
                {
                    pic2.Top = 300;
                }
                if (pic3.Top <= -200)
                {
                    pic3.Top = 300;
                }
                if (pic4.Top <= -200)
                {
                    pic4.Top = 300;
                }
                if (pic5.Top <= -200)
                {
                    pic5.Top = 300;
                }
            }
        }
        
        #endregion

        #region Timers

        private void timer1_Tick(object sender, EventArgs e)
        {
           if (contadorTempo <= voltaCompleta * multiplicadorVoltas)
            {
                if(ativaMovimentoA)
                {
                    Movimenta(ativaMovimentoA, picA1, picA2, picA3, picA4, picA5);
                    VerificaExtremos(ativaMovimentoA, picA1, picA2, picA3, picA4, picA5);
                }
                else if(ativaMovimentoB)
                {
                    Movimenta(ativaMovimentoB, picB1, picB2, picB3, picB4, picB5);
                    VerificaExtremos(ativaMovimentoB, picB1, picB2, picB3, picB4, picB5);
                }
                else if(ativaMovimentoC)
                {
                    Movimenta(ativaMovimentoC, picC1, picC2, picC3, picC4, picC5);
                    VerificaExtremos(ativaMovimentoC, picC1, picC2, picC3, picC4, picC5);
                }
                
                contadorTempo++;
            }
           else
            {
                timer1.Enabled = false;
                ativaMovimentoA = false;
                ativaMovimentoB = false;
                ativaMovimentoC = false;
                contadorTempo = 1;
           }
        }

        private void AtivaTimer(char c, System.Windows.Forms.Timer t)
        {
            if (c == 'A')
                ativaMovimentoA = true;
            else if (c == 'B')
                ativaMovimentoB = true;
            else if (c == 'C')
                ativaMovimentoC = true;

            multiplicadorVoltas = random.Next(5, 15);
            t.Enabled = true;
        }

        #endregion

    }
}

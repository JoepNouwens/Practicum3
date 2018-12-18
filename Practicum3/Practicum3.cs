using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Practicum3
{
    class Scherm : Form
    {
        //Members
        public PictureBox plaatje;
        public Bitmap spelBord;
        public Button nieuwSpel;
        public Button help;

        public Scherm()
        {
            //Scherm
            this.Text = "Reversi";
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.BackColor = Color.FromArgb(204, 204, 255);

            //Knoppen
            help = new Button();
            {
                help.Text = "Help";
                help.Location = new Point(ClientSize.Width / 2 + 100, 40);
                help.Size = new Size(80, 40);
            };
            this.Controls.Add(help);

            nieuwSpel = new Button();
            {
                nieuwSpel.Text = "Nieuw Spel";
                nieuwSpel.Location = new Point(ClientSize.Width / 2 - 80 - 100, 40);
                nieuwSpel.Size = new Size(80, 40);
            };
            this.Controls.Add(nieuwSpel);

            //PictureBox
            plaatje = new PictureBox();
            {
                plaatje.BorderStyle = BorderStyle.Fixed3D;
                plaatje.Location = new Point(ClientSize.Width / 2 - 150, ClientSize.Height / 3);
                plaatje.Size = new Size(300, 300);
                plaatje.Image = spelBord;
            };
            this.Controls.Add(this.plaatje);
            plaatje.Paint +=tekenSpelBord;

           void tekenSpelBord(object obj, PaintEventArgs pea)
            {
                Graphics g = pea.Graphics;
                spelBord = new Bitmap(plaatje.Size.Width, plaatje.Size.Height);
                int lijnen = 7;
                int afstand = 50;
                Pen zwart = new Pen(Color.Black)
                {
                    Width = 2
                };
                int x = 0;
                int y = 0;
                

                //Horizontale lijnen
                for (y = 0; y < lijnen; ++y)
                {
                    g.DrawLine(zwart, 0, y * afstand, lijnen * afstand, y * afstand);
                }

                //Verticale lijnen
                for (x = 0; x < lijnen; ++x)
                {
                    g.DrawLine(zwart, x * afstand, 0, x * afstand, lijnen * afstand);
                }
                this.BackgroundImage = spelBord;
            }
        }

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Scherm());
        }

    }

     public class BitmapControl : UserControl
        {
        
    }
}

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reversi
{
    class Reversischerm : Form
    {
        private Button help, nieuwspel;
        private Panel panel;
        private Label roodstenen, blauwstenen, aanzet;
        public int grootte = 650, xpanelgrootte = 301, ypanelgrootte = 301, diameter = 50, muisX, muisY, arrayX = 6, arrayY = 6;
        int beurt = 0;
        int[,] veld;
        bool geklikt;

        public Reversischerm()
        {
            this.Text = "Reversi";
            this.ClientSize = new Size(grootte, grootte);
            this.BackColor = Color.LightGray;

            nieuwspel = new Button();
            nieuwspel.Text = "Nieuw spel";
            nieuwspel.Location = new Point(200, 75);
            nieuwspel.Size = new Size(75, 50);

            help = new Button();
            help.Text = "Help";
            help.Location = new Point(325, 75);
            help.Size = new Size(75, 50);

            roodstenen = new Label();
            roodstenen.Text = /* aantalstenenrood + */ "2 stenen";
            roodstenen.Location = new Point(150, 150);
            roodstenen.ForeColor = Color.Red;

            blauwstenen = new Label();
            blauwstenen.Text = /* aantalstenenblauw + */ "2 stenen";
            blauwstenen.Location = new Point(150, 200);
            blauwstenen.ForeColor = Color.Blue;

            aanzet = new Label();
            aanzet.Text = /* wiensbeurt + */ "... aan zet";
            aanzet.Location = new Point(150, 250);

            panel = new Panel();
            panel.Location = new Point(grootte*3/13, grootte/2-25);
            panel.Size = new Size(xpanelgrootte, ypanelgrootte);
            panel.BackColor = Color.White;

            this.Controls.Add(nieuwspel);
            this.Controls.Add(help);
            this.Controls.Add(panel);
            this.Controls.Add(roodstenen);
            this.Controls.Add(blauwstenen);
            this.Controls.Add(aanzet);
            this.Paint += Cirkeltjes;
            panel.Paint += TekenBord;
            panel.MouseClick += PlaatsSteen;
            //help.Click += Help;
            //nieuwspel.Click += NieuwBord;

            veld = new int[6, 6];
        }

        void TekenBord(object o, PaintEventArgs pea)
        {
            for (int x = 0; x < veld.GetLength(0); x++)
                for (int y = 0; y < veld.GetLength(1); y++)
                    pea.Graphics.DrawRectangle(Pens.Black, x*50, y*50, 50, 50);

            pea.Graphics.FillEllipse(Brushes.Red, 150, 150, diameter, diameter);
            pea.Graphics.FillEllipse(Brushes.Blue, 100, 150, diameter, diameter);
            pea.Graphics.FillEllipse(Brushes.Red, 100, 100, diameter, diameter);
            pea.Graphics.FillEllipse(Brushes.Blue, 150, 100, diameter, diameter);

            pea.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        }

        //cirkels naast aantal stenen
        void Cirkeltjes(object o, PaintEventArgs pea)
        {
            pea.Graphics.FillEllipse(Brushes.Red, 100, 137, 40, 40);
            pea.Graphics.FillEllipse(Brushes.Blue, 100, 187, 40, 40);
        }

        void NieuwBord(object o, PaintEventArgs pea)
        {
            if (geklikt == true && beurt == 1)
            {
                pea.Graphics.FillEllipse(Brushes.Red, arrayX, arrayY, diameter, diameter);
                beurt = 0;
            }

            else if (geklikt == true && beurt == 0)
            {
                pea.Graphics.FillEllipse(Brushes.Blue, arrayX, arrayY, diameter, diameter);
                beurt = 1;
            }
        }

        void PlaatsSteen(object o, MouseEventArgs mea)
        {
            muisX = (int)mea.X / 50;
            muisY = (int)mea.Y / 50;
            if (muisX < veld[arrayX, arrayY])
            {
                geklikt = true;
            }


        }

        void Help(object o, MouseEventArgs mea)
        {

        }


    }

    class Program
    {
        public static void Main()
        {
            Application.Run(new Reversischerm());
        }
    }
}

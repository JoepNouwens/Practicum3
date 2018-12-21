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
        //Members
        private Button help, nieuwspel;
        private Panel panel;
        private Label roodstenen, blauwstenen, aanzet;
        private int grootte = 650, xpanelgrootte, ypanelgrootte, diameter = 50, muisX, muisY, spelgrootteX, spelgrootteY;
        int wit = 0, blauw = 1, rood = 2;
        int aantalBlauw = 2, aantalRood = 2;
        int[,] veld;
        //bool geklikt
        int beurt = 0;

        public Reversischerm()
        {
            //Form
            this.Text = "Reversi";
            this.ClientSize = new Size(grootte, grootte);
            this.BackColor = Color.LightGray;

            //Nieuwspel knop
            nieuwspel = new Button();
            nieuwspel.Text = "Nieuw spel";
            nieuwspel.Location = new Point(200, 75);
            nieuwspel.Size = new Size(75, 50);

            //Help knop
            help = new Button();
            help.Text = "Help";
            help.Location = new Point(325, 75);
            help.Size = new Size(75, 50);

            //Aantal rode stenen
            roodstenen = new Label();
            roodstenen.Text = aantalRood.ToString("") + " stenen";
            roodstenen.Location = new Point(150, 150);
            roodstenen.ForeColor = Color.Red;

            //Aantal blauwe stenen
            blauwstenen = new Label();
            blauwstenen.Text = aantalBlauw.ToString("") + " stenen";
            blauwstenen.Location = new Point(150, 200);
            blauwstenen.ForeColor = Color.Blue;

            aanzet = new Label();
            String beurtS;
            if (beurt % 2 == 0)
            {
                beurtS = "Blauw";
                aanzet.Text = beurtS + " is aan zet";
            }
            else if (beurt % 2 != 0)
            {
                beurtS = "Rood";
                aanzet.Text = beurtS + " is aan zet";
            }
            aanzet.Location = new Point(150, 250);

            //Panel (grootte verandert als )
            spelgrootteX = 6;
            spelgrootteY = 6;
            xpanelgrootte = spelgrootteX * 50;
            ypanelgrootte = spelgrootteY * 50;
            panel = new Panel();
            panel.Location = new Point(grootte * 3 / 13, grootte / 2 - 25);
            panel.Size = new Size(xpanelgrootte, ypanelgrootte);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.Fixed3D;

            this.Controls.Add(nieuwspel);
            this.Controls.Add(help);
            this.Controls.Add(panel);
            this.Controls.Add(roodstenen);
            this.Controls.Add(blauwstenen);
            this.Controls.Add(aanzet);
            this.Paint += CirkeltjesNaastAantal;
            panel.Paint += Startpositie;
            panel.MouseClick += PlaatsSteen;
            //help.Click += Help;
            nieuwspel.Click += NieuwBord;
        }

        void Startpositie(object o, PaintEventArgs pea)
        {
            //Mooiere cirkels
            pea.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen zwart = new Pen(Color.Black)
            {
                Width = 2,
            };

            veld = new int[spelgrootteX, spelgrootteY];

            for (int x = 0; x < veld.GetLength(0); x++)
                for (int y = 0; y < veld.GetLength(1); y++)
                    pea.Graphics.DrawRectangle(zwart, x * 50, y * 50, 50, 50);

            veld[spelgrootteX / 2 - 1, spelgrootteX / 2 - 1] = blauw;
            veld[spelgrootteX / 2, spelgrootteX / 2 - 1] = rood;
            veld[spelgrootteX / 2, spelgrootteX / 2] = blauw;
            veld[spelgrootteX / 2 - 1, spelgrootteX / 2] = rood;

            for (int x = 0; x < spelgrootteX; x++)
            {
                for (int y = 0; y < spelgrootteY; y++)
                {
                    if (veld[x, y] == blauw)
                        pea.Graphics.FillEllipse(Brushes.Blue, x * 50, y * 50, diameter, diameter);

                    if (veld[x, y] == rood)
                        pea.Graphics.FillEllipse(Brushes.Red, x * 50, y * 50, diameter, diameter);
                }
            }

            if (veld[muisX, muisY] == 1)
                pea.Graphics.FillEllipse(Brushes.Blue, muisX * 50, muisY * 50, diameter, diameter);
            if (veld[muisX, muisY] == 2)
                pea.Graphics.FillEllipse(Brushes.Red, muisX * 50, muisY * 50, diameter, diameter);
            panel.Invalidate();
        }

        void PlaatsSteen(object sender, MouseEventArgs mea)
        {
            muisX = mea.Location.X/50;
            muisY = mea.Location.Y/50;

            if (veld[muisX, muisY] == wit && beurt % 2 == 0)
            {
                veld[muisX, muisY] = blauw;
                aantalBlauw++;
                aanzet.Invalidate();
                blauwstenen.Invalidate();
                beurt++;

            }
            else if (veld[muisX, muisY] == wit && beurt % 2 != 0)
            {
                veld[muisX, muisY] = rood;
                aantalRood++;
                aanzet.Invalidate();
                roodstenen.Invalidate();
                beurt++;
            }
            panel.Invalidate();
        }

        /*void Help(object sender, EventArgs e)
        {

        }
*/

        void NieuwBord(object sender, EventArgs e)
        {
            //Startpositie();
        } 

        void CirkeltjesNaastAantal(object o, PaintEventArgs pea)
        {
            pea.Graphics.FillEllipse(Brushes.Red, 105, 142, 30, 30);
            pea.Graphics.FillEllipse(Brushes.Blue, 105, 192, 30, 30);
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

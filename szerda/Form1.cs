using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace szerda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public struct Szamok
        {
            public int a, b, c;
            public static bool operator < (Szamok x, Szamok y) 
            {
                if ((x.a + x.b + x.c) < (y.a + y.b + y.c))
                    return true;
                else
                    return false;
            }
            public static bool operator > (Szamok x, Szamok y)
            {
                if ((x.a + x.b + x.c) > (y.a + y.b + y.c))
                    return true;
                else
                    return false;
            }
            public static bool operator == (Szamok x, Szamok y)
            {
                if ((x.a + x.b + x.c) == (y.a + y.b + y.c))
                    return true;
                else
                    return false;
            }
            public static bool operator != (Szamok x, Szamok y)
            {
                if ((x.a + x.b + x.c) != (y.a + y.b + y.c))
                    return true;
                else
                    return false;
            }
        }

        Random rnd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
        }

        public Szamok szamokFeltoltese = new Szamok();
        public List<Szamok> szamokLista = new List<Szamok>();

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";

            for (int i = 0; i < 20; i++)
            {
                szamokFeltoltese.a = rnd.Next(1, 51);
                szamokFeltoltese.b = rnd.Next(1, 51);
                szamokFeltoltese.c = rnd.Next(1, 51);
                szamokLista.Add(szamokFeltoltese);

                label1.Text += $"{i + 1}. {szamokLista[i].a}, {szamokLista[i].b}, {szamokLista[i].c} = {szamokLista[i].a + szamokLista[i].b + szamokLista[i].c}\n";
            }

            Szamok peldany1 = szamokLista.ElementAt(3);
            Szamok peldany2 = szamokLista.ElementAt(5);

            // -----------------------------------------

            var eredmeny1 = from i in szamokLista select i.a.ToString();

            foreach (var item in eredmeny1)
                label3.Text = $"{item}";

            // -----------------------------------------

            var eredmeny2 = szamokLista.Select(i => i.a);

            foreach (var item in eredmeny2)
                label4.Text = $"{item}";

            // -----------------------------------------

            var eredmeny3 = from i in szamokLista where i.c > 10 select i.c;

            foreach (var item in eredmeny3)
                label5.Text = $"{item}";

            // -----------------------------------------

            label2.Text = $"< {peldany1 < peldany2}\n";
            label2.Text += $"> {peldany1 > peldany2}\n";
            label2.Text += $"== {peldany1 == peldany2}\n";
            label2.Text += $"!= {peldany1 != peldany2}\n";
        }
    }
}

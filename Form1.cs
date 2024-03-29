﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vyjimky07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dnes = DateTime.Today;
            double prumerVeku = 0;
            int pocet = 0;
            int soucet = 0;
            try
            {
                using (StreamReader sr = new StreamReader("Osoby.txt"))
                {
                    while(!sr.EndOfStream)
                    {
                        string radek = sr.ReadLine();
                        try
                        {
                            DateTime datumNarozeni = DateTime.Parse(radek);
                            try
                            {
                                int let = dnes.Year - datumNarozeni.Year;
                                DateTime narozeninyLetos = datumNarozeni.AddYears(let);
                                if (dnes < narozeninyLetos) let--;
                                MessageBox.Show(let.ToString() + " " + datumNarozeni.ToString());
                                try
                                {
                                    pocet++;
                                    soucet += let;
                                }
                                catch (OverflowException)
                                {
                                    MessageBox.Show("Moc velké hodnoty");
                                }
                            }
                            catch(FormatException)
                            {
                                MessageBox.Show("Špatná informace");
                            }                          
                        }
                        catch(FormatException)
                        {
                            MessageBox.Show("Vadný zápis");
                        }
                    }
                    MessageBox.Show("Průměrný věk: " + (double)soucet / pocet);
                }
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("Soubor nebyl nalezen");
            }
            catch (IOException)
            {
                MessageBox.Show("chyba při čtení souboru (soubor je poškozený)");
            }
        }
    }
}

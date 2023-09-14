using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Projektowaniewizualne7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string get_seq()
        {
            return textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            // Sprawdź, czy cały tekst zawiera tylko litery A, C, T i G
            if (!Regex.IsMatch(input, "^[ACTG]*$"))
            {
                // Jeżeli tekst zawiera inne znaki, usuń ostatnio wprowadzone
                // znaki, które nie pasują do wzorca
                int cursorPosition = textBox1.SelectionStart;
                textBox1.Text = Regex.Replace(input, "[^ACTG]", string.Empty);
                textBox1.SelectionStart = cursorPosition - 1; // Przywróć pozycję kursora

                MessageBox.Show("Możesz używać tylko liter A, C, T i G.");
            }
        }
    }
}

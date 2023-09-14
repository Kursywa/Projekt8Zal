using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Text.RegularExpressions;
using System.IO;

namespace Projektowaniewizualne7
{
    public partial class Form2 : Form
    {
        List<string> seqs = new List<string>();
        public Form2()
        {
            InitializeComponent();
            Count();
        }

        public void Count()
        {
            string sequence = (Application.OpenForms.OfType<Form1>().FirstOrDefault()).get_seq();
            for(int i = 0; i < sequence.Length - 3; i++)
            {
                string littleseq = sequence.Substring(i, 4);
                if (!seqs.Contains(littleseq))
                {
                    seqs.Add(littleseq);
                    int occurances = Regex.Matches(sequence, littleseq).Count;

                    int rowId = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[rowId];
                    row.Cells["Column1"].Value = littleseq;
                    row.Cells["Column2"].Value = occurances;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TextWriter tw = new StreamWriter("data.csv"))
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        tw.Write($"{dataGridView1.Rows[i].Cells[j].Value.ToString()}");

                        if (!(j == dataGridView1.Columns.Count - 1))
                        {
                            tw.Write(",");
                        }
                    }
                    tw.WriteLine();
                }
            }
        }
    }
}

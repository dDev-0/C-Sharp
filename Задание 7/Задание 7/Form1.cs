using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 1;
            dataGridView2.RowCount = 1;
            dataGridView3.RowCount = 1;
            dataGridView4.RowCount = 1;

            int n = Convert.ToInt32(numericUpDown1.Value), m = Convert.ToInt32(numericUpDown2.Value);

            dataGridView1.ColumnCount = dataGridView3.ColumnCount = dataGridView4.ColumnCount = n;
            dataGridView2.ColumnCount = m;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(numericUpDown1.Value);
            dataGridView1.ColumnCount = dataGridView3.ColumnCount = dataGridView4.ColumnCount = n;

            dataGridView1.RowCount = 1;
            dataGridView2.RowCount = 1;
            dataGridView3.RowCount = 1;
            dataGridView4.RowCount = 1;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int m = Convert.ToInt32(numericUpDown2.Value);
            dataGridView2.ColumnCount = m;

            dataGridView1.RowCount = 1;
            dataGridView2.RowCount = 1;
            dataGridView3.RowCount = 1;
            dataGridView4.RowCount = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(numericUpDown1.Value), m = Convert.ToInt32(numericUpDown2.Value);

            A_Class a = new A_Class(n);
            B_Class b = new B_Class(m);

            for (int i = 0; i < n; i++)
                a[i] = Convert.ToInt32(dataGridView1[i, 0].Value);

            for (int i = 0; i < m; i++)
                b[i] = Convert.ToInt32(dataGridView2[i, 0].Value);

            int t;
            for (int i = 1; i < n;)
            {
                if (i > 0 && a[i] < a[i - 1])
                {
                    t = a[i - 1];
                    a[i - 1] = a[i];
                    a[i] = t;

                    i--;
                }
                else
                    i++;
            }

            int minimum = b.minimim;
            for (int i = 0; i < n; i++)
            {
                dataGridView3[i, 0].Value = a[i];
                dataGridView4[i, 0].Value = a[i] * minimum;
            }
        }
    }
}

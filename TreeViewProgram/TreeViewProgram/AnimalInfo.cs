using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewProgram
{
    public partial class AnimalInfo : Form
    {
        public AnimalInfo()
        {
            InitializeComponent();
        }

        private void AnimalInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult == DialogResult.OK)
            {
                try
                {
                    if (textBox1.Text.Trim() == "")
                    {
                        textBox1.Focus();
                        throw new Exception("Введите имя животного");
                    }

                    if (textBox2.Text.Trim() == "")
                    {
                        textBox1.Focus();
                        throw new Exception("Введите тип пищи для животного");
                    }
                }
                catch (Exception exc)
                {
                    e.Cancel = true;
                    MessageBox.Show(exc.Message, "Информация");
                }
            }
        }
    }
}

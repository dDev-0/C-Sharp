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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<AviaryClass> Aviary = new List<AviaryClass>();

        private void addButton_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Level == 0)
                {
                    AviaryInfo aviaryWindow = new AviaryInfo();
                    aviaryWindow.Text = "Добавление вольера";

                    if (aviaryWindow.ShowDialog() == DialogResult.OK)
                    {
                        AviaryClass aviary = new AviaryClass();

                        aviary.aviaryName = aviaryWindow.textBox1.Text;
                        aviary.aviarySquare = Convert.ToInt32(aviaryWindow.numericUpDown1.Value);
                        aviary.heightOfWall = Convert.ToInt32(aviaryWindow.numericUpDown2.Value);

                        Aviary.Add(aviary);

                        TreeNode temp = treeView1.SelectedNode.Nodes.Add(aviary.aviaryName);

                        temp.Nodes.Add("Площадь: " + aviary.aviarySquare + " кв. м.");
                        temp.Nodes.Add("Высота ограды: " + aviary.heightOfWall + " м.");
                        temp.Nodes.Add("Список животных");
                    }
                }
                else
                {
                    if (treeView1.SelectedNode.Level == 2 && treeView1.SelectedNode.Index == 2)
                    {
                        AnimalInfo animalWindow = new AnimalInfo();
                        animalWindow.Text = "Добавление нового животного";

                        if (animalWindow.ShowDialog() == DialogResult.OK)
                        {
                            AnimalClass animal = new AnimalClass();

                            animal.animalName = animalWindow.textBox1.Text;
                            animal.animalFoodType = animalWindow.textBox2.Text;

                            animal.animalWeight = Convert.ToInt32(animalWindow.numericUpDown1.Value);
                            animal.countOfFood = Convert.ToInt32(animalWindow.numericUpDown2.Value);

                            AviaryClass aviary = Aviary.ElementAt(treeView1.SelectedNode.Parent.Index);
                            aviary.animals.Add(animal);

                            TreeNode temp = treeView1.SelectedNode.Nodes.Add(animal.animalName);

                            temp.Nodes.Add("Вес животного: " + animal.animalWeight + " кг.");
                            temp.Nodes.Add("Тип пищи: " + animal.animalFoodType);
                            temp.Nodes.Add("Ест в день: " + animal.countOfFood + " кг.");
                        }
                    }
                    else
                        MessageBox.Show("Добавление возможно только в разделы Список вольеров или Список животных", "Информация");
                }
            }
            else
                MessageBox.Show("Выберите раздел для добавления", "Информация");
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Level == 1 || treeView1.SelectedNode.Level == 3)
                {
                    if (treeView1.SelectedNode.Level == 1)
                    {
                        AviaryClass aviary = Aviary.ElementAt(treeView1.SelectedNode.Index);

                        AviaryInfo aviaryWindow = new AviaryInfo();

                        aviaryWindow.Text = "Изменение вольера";

                        aviaryWindow.textBox1.Text = aviary.aviaryName;
                        aviaryWindow.numericUpDown1.Value = aviary.aviarySquare;
                        aviaryWindow.numericUpDown2.Value = aviary.heightOfWall;

                        if (aviaryWindow.ShowDialog() == DialogResult.OK)
                        {
                            aviary.aviaryName = aviaryWindow.textBox1.Text;
                            aviary.aviarySquare = Convert.ToInt32(aviaryWindow.numericUpDown1.Value);
                            aviary.heightOfWall = Convert.ToInt32(aviaryWindow.numericUpDown2.Value);

                            treeView1.SelectedNode.Text = aviary.aviaryName;
                            treeView1.SelectedNode.Nodes[0].Text = "Площадь: " + aviary.aviarySquare + " кв. м.";
                            treeView1.SelectedNode.Nodes[1].Text = "Высота ограды: " + aviary.heightOfWall + " м.";
                        }
                    }
                    else
                    {
                        AviaryClass aviary = Aviary.ElementAt(treeView1.SelectedNode.Parent.Parent.Index);
                        AnimalClass animal = aviary.animals.ElementAt(treeView1.SelectedNode.Index);

                        AnimalInfo animalWindow = new AnimalInfo();

                        animalWindow.Text = "Изменение животного";

                        animalWindow.textBox1.Text = animal.animalName;
                        animalWindow.textBox2.Text = animal.animalFoodType;

                        animalWindow.numericUpDown1.Value = animal.animalWeight;
                        animalWindow.numericUpDown2.Value = animal.countOfFood;

                        if (animalWindow.ShowDialog() == DialogResult.OK)
                        {
                            animal.animalName = animalWindow.textBox1.Text;
                            animal.animalFoodType = animalWindow.textBox2.Text;

                            animal.animalWeight = Convert.ToInt32(animalWindow.numericUpDown1.Value);
                            animal.countOfFood = Convert.ToInt32(animalWindow.numericUpDown2.Value);

                            treeView1.SelectedNode.Text = animal.animalName;
                            treeView1.SelectedNode.Nodes[0].Text = "Вес животного: " + animal.animalWeight + " кг.";
                            treeView1.SelectedNode.Nodes[1].Text = "Тип пищи: " + animal.animalFoodType;
                            treeView1.SelectedNode.Nodes[2].Text = "Ест в день: " + animal.countOfFood + " кг.";
                        }
                    }
                }
                else
                    MessageBox.Show("Вы можете изменить либо данные о вольере, либо о животном", "Информация");
            }
            else
                MessageBox.Show("Выберите вольер или животное для изменения", "Информация");
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Level == 1 || treeView1.SelectedNode.Level == 3)
                {
                    if (treeView1.SelectedNode.Level == 1)
                        Aviary.RemoveAt(treeView1.SelectedNode.Index);
                    else
                    {
                        AviaryClass aviary = Aviary.ElementAt(treeView1.SelectedNode.Parent.Parent.Index);
                        aviary.animals.RemoveAt(treeView1.SelectedNode.Index);
                    }

                    treeView1.SelectedNode.Remove();
                }
                else
                {
                    MessageBox.Show("Удалить возможно либо вольер либо животное", "Информация");
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AviaryClass aviary;

            switch (treeView1.SelectedNode.Level)
            {
                case 0:
                    textBox1.Text = "Это корень дерева";
                    addButton.Enabled = true;
                    changeButton.Enabled = false;
                    deleteButton.Enabled = false;
                    break;

                case 1:
                    aviary = Aviary.ElementAt(treeView1.SelectedNode.Index);

                    textBox1.Text = "Всего животных: " + aviary.animals.Count;
                    addButton.Enabled = false;
                    changeButton.Enabled = true;
                    deleteButton.Enabled = true;
                    break;

                case 2:
                    aviary = Aviary.ElementAt(treeView1.SelectedNode.Parent.Index);

                    textBox1.Text = "Вольер: " + aviary.aviaryName;
                    if (treeView1.SelectedNode.Index == 2)
                        addButton.Enabled = true;
                    else
                        addButton.Enabled = false;

                    changeButton.Enabled = false;
                    deleteButton.Enabled = false;
                    break;

                case 3:
                    aviary = Aviary.ElementAt(treeView1.SelectedNode.Parent.Parent.Index);

                    AnimalClass animal = aviary.animals.ElementAt(treeView1.SelectedNode.Index);

                    textBox1.Text = "Вес животного: " + animal.animalWeight;
                    addButton.Enabled = false;
                    changeButton.Enabled = true;
                    deleteButton.Enabled = true;
                    break;

                case 4:
                    aviary = Aviary.ElementAt(treeView1.SelectedNode.Parent.Parent.Parent.Index);

                    animal = aviary.animals.ElementAt(treeView1.SelectedNode.Parent.Index);

                    textBox1.Text = "Животное: " + animal.animalName;
                    addButton.Enabled = false;
                    changeButton.Enabled = false;
                    deleteButton.Enabled = false;
                    break;

            }
        }
    }
    }


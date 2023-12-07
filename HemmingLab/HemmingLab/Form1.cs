using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HemmingLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

        }
        Graph graph = new Graph();
        
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
        private async Task parseFileAsync(string filename)
        {

            StreamReader reader = new StreamReader(filename);
            string number = "";
            int currentVertex = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (graph.getVertex() == 0)
                {
                    graph.setVertex(Convert.ToInt32(line));
                }
                else
                {
                    List<int> matrixLine = new List<int>();
                    for (int i = 0; i < line.Length; i++)
                    {

                        while (line[i] != ' ')
                        {
                            number += line[i];
                            if (i == line.Length - 1)
                            {
                                break;
                            }
                            i++;
                        }
                        if (line[i] == ' ' || i == line.Length - 1)
                        {

                            matrixLine.Add(Convert.ToInt32(number));
                            number = "";

                        }
                    }
                    graph.setEdges(matrixLine, currentVertex);
                    currentVertex++;
                }
            }
        }
        StringBuilder stringBuilder = new StringBuilder();
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            parseFileAsync(filename);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hemming hemming = new Hemming();
            
            switch (hemming.hemmingAlg(graph)) {
                case 0:
                    textBox1.Text = "010\r\n101\r\n010";
                    break;
                case 1:
                    textBox1.Text = "111\r\n101\r\n101";
                    break;
                case 2:
                    textBox1.Text = "101\r\n111\r\n101\r\n";
                    break;
                case 3:
                    textBox1.Text = "111\r\n100\r\n100";
                    break;
                case 4:
                    textBox1.Text = "000\r\n010\r\n000";
                    break;
                default:
                    textBox1.Text = "Изображение не распознано";
                    break;
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

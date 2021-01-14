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

namespace game_negative
{
    public partial class Form1 : Form
    {
        int n = 10, m = 15;
        int[,] matr;
        string fileName;
        public Form1()
        {
            InitializeComponent();
            
        }


        void change_dataGrid()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (matr[i, j] == 1)
                        //dataGridView1.Rows[i].Cells[j].Value = "1";
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Aqua;
                    else
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int stroka = e.RowIndex;
            int stolbec = e.ColumnIndex;

            /*for (int i = 0; i < m; i++)
                matr[stroka, i] = (matr[stroka, i] + 1) % 2;
            for (int i = 0; i < n; i++)
                if (matr[i, stolbec] == 1)
                    matr[i, stolbec] = 0;
                else
                    matr[i, stolbec] = 1;
            */
            matr[stroka, stolbec] = 1;
            change_dataGrid();
            dataGridView1.ClearSelection();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter sw = new StreamWriter(fileName);
            sw.WriteLine(n + " " + m);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    sw.Write(matr[i, j] + " ");
                sw.WriteLine();
            }
            sw.Close();
            MessageBox.Show("Карта сохранена в файл");
        }

        int[,] readFromFileMatr(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string[] temp = sr.ReadLine().Split();
            int n = Convert.ToInt32(temp[0]);
            int m = Convert.ToInt32(temp[1]);

            int[,] matr = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                temp = sr.ReadLine().Split();
                for (int j = 0; j < m; j++)
                    matr[i, j] = Convert.ToInt32(temp[j]);
            }
            sr.Close();
            return matr;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fileName = "matr.txt";
            matr = readFromFileMatr(fileName);
            n = matr.GetLength(0);
            m = matr.GetLength(1);

            dataGridView1.ColumnCount = m;
            dataGridView1.RowCount = n;
            dataGridView1.RowTemplate.Height = 45;
            for (int i = 0; i < m; i++)
                dataGridView1.Columns[i].Width = 45;
            dataGridView1.Width = (45 + 1) * m;
            dataGridView1.Height = (45 + 1) * n;
            change_dataGrid();
        }
    }
}

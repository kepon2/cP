﻿using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using expHashTable;
using guben;

namespace cP
{
    public partial class hashTableMethodsExperimental : Form
    {
        experimetalHashTable eht = new experimetalHashTable(0);
        experimentalHTGuben eHTG = new experimentalHTGuben(0);


        public hashTableMethodsExperimental()
        {
            InitializeComponent();
        }

        private void __Load(object sender, EventArgs e)
        {
            this.Width = 1400;
            this.Height = 780;
            this.Location = new Point(100, 35);
            StreamReader sr = new StreamReader("C:\\Users\\al\\source\\repos\\cP\\cP\\эксперимент.txt");
            eht = new experimetalHashTable(Convert.ToInt32(this.textBox7.Text));
            eHTG = new experimentalHTGuben(Convert.ToInt32(this.textBox7.Text));
            string fromFile = "";

            while (fromFile != null)
            {
                fromFile = sr.ReadLine();
                if (fromFile == null)
                {
                    break;
                }
                eht.pushBackArray(fromFile);
                eHTG.pushBackArray(fromFile);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (eht.mapSize == 0)
            {
                return;
            }
            if (textBox1.Text == "")
            {
                textBox4.Clear();
                return;
            }
            int compCounterOA = eht.calcHash(textBox1.Text).Item2;
            if (compCounterOA == -1)
            {
                textBox4.Clear();
                textBox4.Text = "не найден";
                return;
            }
            int compCounterCh = eHTG.arrayRoot[eHTG.getHash(textBox1.Text)].Contains(textBox1.Text).Item2;
            textBox4.Text = compCounterOA + " - " + compCounterCh;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.textBox6.Text) > Convert.ToInt32(this.textBox7.Text))
            {
                MessageBox.Show("Число записей не может быть больше размера хеш-таблицы", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox5.Text != "")
            {
                eHTG.constanta = Convert.ToDouble(textBox5.Text);
            }
            this.dataGridView1.Rows.Clear();
            this.dataGridView2.Rows.Clear();

            if (eht.mapSize == 0)
            {
                eht = new experimetalHashTable(Convert.ToInt32(this.textBox7.Text));
                eHTG = new experimentalHTGuben(Convert.ToInt32(this.textBox7.Text));
            }

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                string fromFile = "";
                sr = new StreamReader(ofd.FileName);
                for (int i = 0; i < Convert.ToInt32(this.textBox6.Text); i++)
                {
                    fromFile = sr.ReadLine();
                    if (fromFile == null)
                    {
                        MessageBox.Show("Число записей в справочнике меньше заданного числа для эксперимента\n" +
                        "Проведён эксперимент для " + i + " записей", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Tuple <int, string, int> y = eht.calcHashAndInsertion(eht.array[i], i, dataGridView1, Convert.ToInt32(this.textBox6.Text));
                    eHTG.addHashTable(eht.array[i], dataGridView2);
                }
                sr.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                return;
            }
            if (eHTG.validator(textBox2.Text) == 1)
            {
                return;
            }
            eht.pushBackArray(textBox2.Text);
            eHTG.pushBackArray(textBox2.Text);
            Tuple <int, string, int> x = eht.calcHashAndInsertion(textBox2.Text, eht.arraySize - 1, dataGridView1, Convert.ToInt32(this.textBox6.Text));
            textBox8.Text = x.Item1.ToString();
            eHTG.addHashTable(textBox2.Text, dataGridView2);
            if (x.Item2 != "")
            {
                textBox3.Text = "произошло";
                eHTG.rehashing(dataGridView2, Convert.ToInt32(this.textBox6.Text));
            }
            else
            {
                textBox3.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sr = new StreamWriter(sfd.FileName, false);
                for(int i = 0; i < eHTG.arraySize - 1; i++)
                {   
                    if(i == eHTG.arraySize - 1)
                    {
                        sr.Write(eHTG.array[i]);
                        return;
                    } 
                    sr.WriteLine(eHTG.array[i]);
                }
                sr.Close();
            }
            else
            {
                return;
            }
        }
    }
} 

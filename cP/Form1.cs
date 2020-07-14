﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using bynTree;
using pMap;
using avlTree;
using HashTable;
using repClass;

namespace cP
{
    public partial class mainWindow : Form
    {

        public void rewriteFile()
        {

        }
        public static bynaryTree bynaryTreeSourceData = new bynaryTree();
        fileRW objRW = new fileRW();
        public static payMap payInfoMap = new payMap();
        public static hashTable personnelMap = new hashTable();
        public static hashTable employeeMap = new hashTable();
        AVL avl = new AVL();
        string sourceFileName;

        public mainWindow()
        {
            InitializeComponent();
        }

        private void initPersonnelInfo_Click(object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                objRW.openReader(openFileDialog.FileName);
                sourceFileName = openFileDialog.FileName;
            }
            else
            {
                return;
            }
            string tmpStringFromFile = objRW.reader.ReadLine();
            string[] parsedStringForHashTable = new string[3];

            while (tmpStringFromFile != null && tmpStringFromFile[0] != '2')
            {
                parsedStringForHashTable = objRW.readerPars(tmpStringFromFile, 1);
                parsedStringForHashTable[1] = parsedStringForHashTable[1].Remove(0, 2);
                parsedStringForHashTable[0] = payInfoMap.getEmptyHashAddress(parsedStringForHashTable[1]).ToString();
                this.listBonusInfo.Rows.Add(parsedStringForHashTable);
                payInfoMap.pushBackArray(parsedStringForHashTable[1], parsedStringForHashTable[2], parsedStringForHashTable[3]);
                pMap.info record = new pMap.info(parsedStringForHashTable[2], parsedStringForHashTable[1], parsedStringForHashTable[3]);
                payInfoMap.addInArrayForReport(record);
                tmpStringFromFile = objRW.reader.ReadLine();
            }

            string[] parsedString = new string[2];
            while (tmpStringFromFile[0] != '3')
            {
                parsedString = objRW.readerPars(tmpStringFromFile);
                parsedString[0] = parsedString[0].Remove(0, 2);
                this.listPayInfo.Rows.Add(parsedString);
                bynaryTreeSourceData.pushBackArray(parsedString[0], parsedString[1], parsedString[2]);
                tmpStringFromFile = objRW.reader.ReadLine();
            }
            bynaryTreeSourceData.initTreeFromePayArray(ref bynaryTreeSourceData.array);

            parsedString = null;

            while (tmpStringFromFile[0] != '4')
            {
                parsedStringForHashTable = objRW.readerPars(tmpStringFromFile, 1);
                parsedStringForHashTable[1] = parsedStringForHashTable[1].Remove(0, 2);
                parsedStringForHashTable[0] = personnelMap.getHash(parsedStringForHashTable[1]).ToString();
                HashTable.info record = new HashTable.info(parsedStringForHashTable[0], parsedStringForHashTable[1], parsedStringForHashTable[2]);
                this.listPersonnelInfo.Rows.Add(parsedStringForHashTable);
                personnelMap.pushBackArray(parsedStringForHashTable[1], parsedStringForHashTable[2], parsedStringForHashTable[3]);
                tmpStringFromFile = objRW.reader.ReadLine();
            }
            personnelMap.initHashTableFromArray();

            while (tmpStringFromFile != null)
            {
                parsedStringForHashTable = objRW.readerPars(tmpStringFromFile, 1);
                parsedStringForHashTable[1] = parsedStringForHashTable[1].Remove(0, 2);
                parsedStringForHashTable[0] = employeeMap.getHash(parsedStringForHashTable[1]).ToString();
                HashTable.info record = new HashTable.info(parsedStringForHashTable[0], parsedStringForHashTable[1], parsedStringForHashTable[2]);
                this.listEmployeeInfo.Rows.Add(parsedStringForHashTable);
                employeeMap.pushBackArray(parsedStringForHashTable[1], parsedStringForHashTable[2], parsedStringForHashTable[3]);
                tmpStringFromFile = objRW.reader.ReadLine();
            }
            employeeMap.initHashTableFromArray();

            objRW.closeReader();
        }

        private void button18_Click(object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                objRW.openReader(openFileDialog.FileName);
                sourceFileName = openFileDialog.FileName;
            }
            else
            {
                return;
            }
            string tmpStringFromFile = objRW.reader.ReadLine();
            string[] parsedStringForHashTable = new string[3];

            while (tmpStringFromFile != null && tmpStringFromFile[0] != '2')
            {
                parsedStringForHashTable = objRW.readerPars(tmpStringFromFile, 1);
                parsedStringForHashTable[1] = parsedStringForHashTable[1].Remove(0, 2);
                parsedStringForHashTable[0] = payInfoMap.getEmptyHashAddress(parsedStringForHashTable[1]).ToString();
                this.listBonusInfo.Rows.Add(parsedStringForHashTable);
                payInfoMap.pushBackArray(parsedStringForHashTable[1], parsedStringForHashTable[2], parsedStringForHashTable[3]);
                pMap.info record = new pMap.info(parsedStringForHashTable[2], parsedStringForHashTable[1], parsedStringForHashTable[3]);
                payInfoMap.addInArrayForReport(record);
                tmpStringFromFile = objRW.reader.ReadLine();
            }

            string[] parsedString = new string[2];
            while (tmpStringFromFile[0] != '3')
            {
                parsedString = objRW.readerPars(tmpStringFromFile);
                parsedString[0] = parsedString[0].Remove(0, 2);
                this.listPayInfo.Rows.Add(parsedString);
                bynaryTreeSourceData.pushBackArray(parsedString[0], parsedString[1], parsedString[2]);
                tmpStringFromFile = objRW.reader.ReadLine();
            }
            bynaryTreeSourceData.initTreeFromePayArray(ref bynaryTreeSourceData.array);

            parsedString = null;

            while (tmpStringFromFile[0] != '4')
            {
                parsedStringForHashTable = objRW.readerPars(tmpStringFromFile, 1);
                parsedStringForHashTable[1] = parsedStringForHashTable[1].Remove(0, 2);
                parsedStringForHashTable[0] = personnelMap.getHash(parsedStringForHashTable[1]).ToString();
                HashTable.info record = new HashTable.info(parsedStringForHashTable[0], parsedStringForHashTable[1], parsedStringForHashTable[2]);
                this.listPersonnelInfo.Rows.Add(parsedStringForHashTable);
                personnelMap.pushBackArray(parsedStringForHashTable[1], parsedStringForHashTable[2], parsedStringForHashTable[3]);
                tmpStringFromFile = objRW.reader.ReadLine();
            }
            personnelMap.initHashTableFromArray();

            while (tmpStringFromFile != null)
            {
                parsedStringForHashTable = objRW.readerPars(tmpStringFromFile, 1);
                parsedStringForHashTable[1] = parsedStringForHashTable[1].Remove(0, 2);
                parsedStringForHashTable[0] = employeeMap.getHash(parsedStringForHashTable[1]).ToString();
                HashTable.info record = new HashTable.info(parsedStringForHashTable[0], parsedStringForHashTable[1], parsedStringForHashTable[2]);
                this.listEmployeeInfo.Rows.Add(parsedStringForHashTable);
                employeeMap.pushBackArray(parsedStringForHashTable[1], parsedStringForHashTable[2], parsedStringForHashTable[3]);
                tmpStringFromFile = objRW.reader.ReadLine();
            }
            employeeMap.initHashTableFromArray();

            objRW.closeReader();
        }

        private void getPayInfo_Click(object sender, EventArgs e)
        {
            findPayInfo fpi = new findPayInfo();
            fpi.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int[] array = new int[16];
            //string str = "вафельница";
            //int ha1 = payInfoMap.hFunction1(str);
            //int ha2 = payInfoMap.hFunction2(str);
            //for(int i = 0; i < 16; i++)
            //{
            //    array[i] = (ha1 + i * ha2)%16;
            //}
            //classToReport.pushArray("Губенко Иван Геннадьевич", "asdad", null, null);
            //classToReport.pushArray("Доронин Егор Александрович", "asda", null, null);
            //classToReport.pushArray("Жлуткин Роман Валерьевич", "adffa", null, null);
            //classToReport.pushArray("Каймаков Роман Константинович", "asda", null, null);

        }

        

        private void button15_Click(object sender, EventArgs e)
        {
            findPayInfo fpi = new findPayInfo();
            fpi.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (listBonusInfo.Rows.Count == 1)
            {
                return;
            }
            int indexRow = listBonusInfo.SelectedCells[0].RowIndex;
            
            if (MessageBox.Show("Удаление может повлечь нарушение целостности информации?\n" +
                "Продолжить удаление?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                == DialogResult.Yes)
            {
                listBonusInfo.Rows.RemoveAt(indexRow);
            }
            else
            {
                return;
            }

        }

        private void listBonusInfo_Click(object sender, EventArgs e)
        {
            if (listBonusInfo.Rows.Count == 1)
            {
                return;
            }
            int indexRow = listBonusInfo.SelectedCells[0].RowIndex;

            int index = this.listBonusInfo.CurrentCell.RowIndex;
            this.listBonusInfo.Rows[index].Selected = false;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            addInfo ai = new addInfo(this.listBonusInfo);
            ai.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            reportClass classToReport = new reportClass();
            bynaryTreeSourceData.getReport(bynaryTreeSourceData.root, classToReport, payInfoMap);
            reportPayBonus rep = new reportPayBonus(classToReport);
            rep.Show();
            for (int i = 0; i < classToReport.arraySize - 1; i++)
            {
                string[] toInsert = new string[4];
                toInsert[0] = classToReport.array[i].field1;
                toInsert[1] = classToReport.array[i].field2 ?? "не найденный данные о зп";
                toInsert[2] = classToReport.array[i].field3;
                toInsert[3] = classToReport.array[i].field4;
                rep.dataGridView1.Rows.Add(toInsert);
            }
            MessageBox.Show("Обратите внимание - корректность данных может быть нарушена!\n" +
                "Соответсвующие данные будут отмечены", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            reportClass classToReport = new reportClass();
            personnelMap.getReport(classToReport, payInfoMap);
            reportFioPay rep = new reportFioPay(classToReport);
            rep.Show();
            for (int i = 0; i < classToReport.arraySize - 1; i++)
            {
                string[] toInsert = new string[2];
                toInsert[0] = classToReport.array[i].field1;
                toInsert[1] = classToReport.array[i].field2 ?? "не найденный данные о зп";
                rep.dataGridView1.Rows.Add(toInsert);
            }
            MessageBox.Show("Обратите внимание - корректность данных может быть нарушена!\n" +
                "Соответсвующие данные будут отмечены", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            reportClass classToReport = new reportClass();
            personnelMap.getReport(classToReport, employeeMap, payInfoMap);
            reportFioUnitExpPay rep = new reportFioUnitExpPay(classToReport);
            rep.Show();
            for (int i = 0; i < classToReport.arraySize - 1; i++)
            {
                string[] toInsert = new string[4];
                toInsert[0] = classToReport.array[i].field1;
                toInsert[1] = classToReport.array[i].field2;
                toInsert[2] = classToReport.array[i].field3 ?? "не найденный данные о стаже";
                toInsert[3] = classToReport.array[i].field4 ?? "не найденный данные о зп";
                rep.dataGridView1.Rows.Add(toInsert);
            }
            MessageBox.Show("Обратите внимание - корректность данных может быть нарушена!\n" +
                "Соответсвующие данные будут отмечены", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button6_Click(object sender, EventArgs e)
        {   reportClass classToReport = new reportClass();
            personnelMap.getReport(classToReport, employeeMap);
            reportFioPostExp rep = new reportFioPostExp(classToReport);
            rep.Show();
            for (int i = 0; i < classToReport.arraySize - 1; i++)
            {
                string[] toInsert = new string[3];
                toInsert[0] = classToReport.array[i].field1;
                toInsert[1] = classToReport.array[i].field2;
                toInsert[2] = classToReport.array[i].field3 ?? "не найденный данные о стаже";
                rep.dataGridView1.Rows.Add(toInsert);
            }
            MessageBox.Show("Обратите внимание - корректность данных может быть нарушена!\n" +
                "Соответсвующие данные будут отмечены", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
 
}

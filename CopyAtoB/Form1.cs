using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CopyAtoB
{
  

    public partial class Form1 : Form
    {
        List<string> pdfnames;
        List<string> csvPdfNames;
        List<string> copyFiles;

        public Form1()
        {
            InitializeComponent();
            pdfnames = new List<string>(Directory.EnumerateFiles(@"A/"));
            csvPdfNames = new List<string>(File.ReadAllLines(@"CSVFile/PDFNames.csv", Encoding.UTF8));
            copyFiles = new List<string>();
            foreach (string item in pdfnames)
            {
                listBox1.Items.Add(item.Substring(2));
            }
            foreach (string item in csvPdfNames)
            {
                if (item.Count() != 0 && item.Trim().Count() !=0)
                {
                    int temp = item.LastIndexOf(';');
                    listBox3.Items.Add(item.Remove(temp, 1));
                }
             

            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (string item in listBox1.Items)
            {
                foreach (string item2 in listBox3.Items)
                {
                    if (item == item2)
                    {
                        copyFiles.Add(item);
                       
                    }
                }
            }
            lb2Refresh();
           copyToB();
        }

        private void copyToB()
        {
            foreach (string item in copyFiles)
            {
                File.Copy($"A/{item}", $"B/{item}");
            }
        }

        private void lb2Refresh()
        {
            listBox2.DataSource = null;
            listBox2.DataSource = copyFiles;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string folderName;
        public string selectlink;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             selectlink = comboBox1.Text;
            //MessageBox.Show(selectlink);
            if (selectlink == "")
            {
                MessageBox.Show("Did you selecet the Page?", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"E:\";      
                saveFileDialog1.Title = "Save text Files";
                saveFileDialog1.CheckFileExists = false;
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog1.FileName;
                    try
                    {
                        // Check if file already exists. If yes, delete it.     
                        if (File.Exists(fileName))
                        {
                            File.Delete(fileName);
                        }

                        // Create a new file     
                        using (StreamWriter sw = File.CreateText(fileName))
                        {
                            


                            using (WebClient wc = new WebClient())
                            {

                               

                                string json = wc.DownloadString("https://finfo-api.vndirect.com.vn/stocks?utm_source=trade.vndirect.com.vn");

                                sw.Write(json);
                                sw.Close();
                                richTextBox1.Text = json;
                            }
                        }

                        // Write file contents on console.     
                        using (StreamReader sr = File.OpenText(fileName))
                        {
                            string s = "";
                            while ((s = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(s);
                            }
                            MessageBox.Show("Successfully saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.ToString());
                    }
                }
                
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
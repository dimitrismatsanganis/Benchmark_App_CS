using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Benchmark_App
{
    public partial class Benchmark : Form
    {
        public Benchmark()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.LoadFile("Benchmarks.txt", RichTextBoxStreamType.PlainText);
        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            Stopwatch watch1 = new Stopwatch();
            Stopwatch watch2 = new Stopwatch();
            Stopwatch watch3 = new Stopwatch();
            long count_1 = 0;
            long count_2 = 1;
            long count_3 = 1;

            watch1.Start();
            for (int i = 0; i < int.MaxValue; i++)
            {
                count_1 += i;
            }
            watch1.Stop();
            
            watch2.Start();
            for (int i = 0; i < int.MaxValue; i++)
            {
                count_2 *= i;
            }
            watch2.Stop();
            
            watch3.Start();
            for (int i = 1; i < int.MaxValue; i++)
            {
                count_3 += 4*i - i;
            }
            watch3.Stop();

            StreamWriter sw = new StreamWriter("Benchmarks.txt", true);
            {
                sw.WriteLine("Tested PC : " + System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString() + "  Test's Date : " + DateTime.Today.ToString("dd-MM-yyyy") + Environment.NewLine  
                                                                                                 + "Part 1 : " + watch1.ElapsedMilliseconds.ToString() + Environment.NewLine 
                                                                                                 + "Part 2 : " + watch2.ElapsedMilliseconds.ToString() + Environment.NewLine 
                                                                                                 + "Part 3 : " + watch3.ElapsedMilliseconds.ToString() + Environment.NewLine);
                sw.Close();
                richTextBox1.LoadFile("Benchmarks.txt", RichTextBoxStreamType.PlainText);
                MessageBox.Show("Benchmark's Result : " + Environment.NewLine + "Part 1 : " +
                  watch1.ElapsedMilliseconds.ToString() + Environment.NewLine + "Part 2 : " +
                  watch2.ElapsedMilliseconds.ToString() + Environment.NewLine + "Part 3 : " +
                  watch3.ElapsedMilliseconds.ToString());
            }
        }
    }
}
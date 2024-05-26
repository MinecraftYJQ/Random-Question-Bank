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

namespace Random_Question_Bank.Window
{
    public partial class Setting_Window : Form
    {
        public Setting_Window()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText("Font.txt", textBox2.Text);
                if (File.ReadAllLines(File.ReadAllText("TK.txt")).Length < int.Parse(textBox1.Text))
                {
                    MessageBox.Show("出题数量大于题库的题目数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                else
                {
                    File.WriteAllText("Number.txt", textBox1.Text);
                    Close();
                }
            }catch (Exception ex)
            {
                MessageBox.Show("未填写信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Setting_Window_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = File.ReadAllText("Number.txt");
                textBox2.Text = File.ReadAllText("Font.txt");
            }catch (Exception ex) { }
        }

        private string xzwj()
        {
            while (true)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "文本文件 (*.txt)|*.txt";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog1.FileName;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText("TK.txt", xzwj());
        }
    }
}

using Random_Question_Bank.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Random_Question_Bank
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            Label.CheckForIllegalCrossThreadCalls=false;
            try
            {
                pattern = File.ReadAllLines(File.ReadAllText("TK.txt"));
                foreach (string nei in pattern)
                {
                    Console.WriteLine(nei);
                }
            }catch (Exception ex)
            {

            }
        }

        string m = "0", ssss = "15";
        string[] pattern = new string[0];
        List<int> list = new List<int>(); // 创建一个空的 List<int>
        List<string> oktm = new List<string>(); // 创建一个空的 List<int>
        int jss = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            Setting_Window setting = new Setting_Window();
            setting.ShowDialog();
            label1.Font = new Font(label1.Font.FontFamily, int.Parse(File.ReadAllText("Font.txt")), label1.Font.Style);
        }

        Thread thread;

        private void MainWindow_Load(object sender, EventArgs e)
        {
            m = "5";

            try
            {
                label1.Font = new Font(label1.Font.FontFamily, int.Parse(File.ReadAllText("Font.txt")), label1.Font.Style);
            }
            catch { }
            ssss = "0";
            if (int.Parse(ssss) <= 9)
            {
                time.Text = m.ToString() + ":0" + ssss.ToString();
            }
            else
            {
                time.Text = m.ToString() + ":" + ssss.ToString();
            }
        }

        private void 关于此程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(pattern.Length<=0){
                MessageBox.Show("无题库！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (button1.Text == "开始答题")
                {
                    int min = int.Parse(m);
                    int sss = int.Parse(ssss);
                    if (sss == 0)
                    {
                        sss = 59;
                        min--;
                    }

                    thread = new Thread(() =>
                    {
                        for (int i = min; i >= 0; i--)
                        {
                            for (int j = sss; j >= 0; j--)
                            {
                                if (j <= 9)
                                {
                                    if (i == 0)
                                    {
                                        time.ForeColor = Color.Red;
                                    }
                                }
                                Thread.Sleep(1000);
                                if (j <= 9)
                                {
                                    time.Text = i.ToString() + ":0" + j.ToString();
                                }
                                else
                                {
                                    time.Text = i.ToString() + ":" + j.ToString();
                                }
                            }
                            if (i <= 1)
                            {
                                time.ForeColor = Color.Red;
                            }
                        }
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            MessageBox.Show("结束！");
                        });
                        time.ForeColor = Color.Black;
                    });
                    thread.Start();
                    button1.Text = "下一题";
                    Random random = new Random();
                    int ss = random.Next(0, pattern.Length);
                    label1.Text = pattern[ss];
                    oktm.Add(label1.Text);
                    list.Add(ss);
                    jss++;
                }
                else
                {
                    if (jss == int.Parse(File.ReadAllText("Number.txt")))
                    {
                        thread.Suspend();
                        button1.Text = "开始答题";
                        if (int.Parse(ssss) <= 9)
                        {
                            time.Text = m.ToString() +":0"+ ssss.ToString();
                        }
                        else
                        {
                            time.Text = m.ToString() + ":" + ssss.ToString();
                        }
                        MessageBox.Show("都答完啦！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information); return;
                    }
                    button1.Text = "下一题";
                    Random random = new Random();
                    /*while (true)
                    {
                        int s = random.Next(0, pattern.Length);
                        int js = 0;
                        for(int i=0;i<=oktm.LongCount()-1;i++)
                        {
                            if (pattern[s] == oktm[i])
                            {
                                js++;
                            }
                        }
                        if(js == 0)
                        {
                            label1.Text = pattern[s];
                        }
                    }*/
                    jss++;
                    int s = random.Next(0, pattern.Length);
                    label1.Text = pattern[s];
                }
            }
        }
    }
}

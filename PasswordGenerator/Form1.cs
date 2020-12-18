using System;
using System.Windows.Forms;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //保存出字典
        private void 保存button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.TrimEnd();
            textBox2.Text = textBox2.Text.TrimEnd();
            textBox3.Text = textBox3.Text.TrimEnd();
            textBox4.Text = textBox4.Text.TrimEnd();
            textBox5.Text = textBox5.Text.TrimEnd();
            textBox6.Text = textBox6.Text.TrimEnd();
            textBox7.Text = textBox7.Text.TrimEnd();
            textBox8.Text = textBox8.Text.TrimEnd();
            string[] array1 = textBox1.Lines.Length == 0 ? new string[] { "" } : textBox1.Lines;
            string[] array2 = textBox2.Lines.Length == 0 ? new string[] { "" } : textBox2.Lines;
            string[] array3 = textBox3.Lines.Length == 0 ? new string[] { "" } : textBox3.Lines;
            string[] array4 = textBox4.Lines.Length == 0 ? new string[] { "" } : textBox4.Lines;
            string[] array5 = textBox5.Lines.Length == 0 ? new string[] { "" } : textBox5.Lines;
            string[] array6 = textBox6.Lines.Length == 0 ? new string[] { "" } : textBox6.Lines;
            string[] array7 = textBox7.Lines.Length == 0 ? new string[] { "" } : textBox7.Lines;
            string[] array8 = textBox8.Lines.Length == 0 ? new string[] { "" } : textBox8.Lines;
            long count1 = array1.LongLength * array2.Length * array3.Length * array4.Length * array5.Length * array6.Length * array7.Length * array8.Length;
            saveFileDialog1.Title = "预计生成" + (count1 / 100000000.0).ToString("F4") + "亿行";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                FileStream stream = new FileStream(saveFileDialog1.FileName, checkBox2.Checked ? FileMode.Create : FileMode.Append);
                StreamWriter writer = new StreamWriter(stream);
                long index = 0;
                long count2 = 0;
                foreach(string item1 in array1)
                {
                    foreach(string item2 in array2)
                    {
                        foreach(string item3 in array3)
                        {
                            foreach(string item4 in array4)
                            {
                                foreach(string item5 in array5)
                                {
                                    foreach(string item6 in array6)
                                    {
                                        foreach(string item7 in array7)
                                        {
                                            foreach(string item8 in array8)
                                            {
                                                string text = item1 + item2 + item3 + item4 + item5 + item6 + item7 + item8;
                                                if(text.Length > 0 && (!checkBox1.Checked || text.Length >= 8))
                                                {
                                                    writer.WriteLine(text);
                                                    count2++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        writer.Flush();
                        progressBar1.Value = (int)(++index * 100 / array1.Length / array2.Length);
                    }
                }
                writer.Close();
                stream.Close();
                Cursor = Cursors.Default;
                MessageBox.Show("累计生成" + (count2 / 100000000.0).ToString("F4") + "亿行");
            }
        }


        //显示行数
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int old = textBox.Lines.Length;
            string index = textBox.Name.Replace("textBox", "");
            if(tableLayoutPanel1.Controls["label" + index] is Label label)
            {
                label.Text = "第" + index + "段  " + (textBox.Text.EndsWith("\r\n") ? textBox.Lines.Length - 1 : textBox.Lines.Length) + "行";
            }
        }


        //符号
        private void _toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i <= 9; i++)
            {
                builder.AppendLine(i.ToString());
            }
            textBox.Text += builder.ToString();
        }
        private void azToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            StringBuilder builder = new StringBuilder();
            for(char i = 'a'; i <= 'z'; i++)
            {
                builder.AppendLine(i.ToString());
            }
            textBox.Text += builder.ToString();
        }
        private void aZToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            StringBuilder builder = new StringBuilder();
            for(char i = 'A'; i <= 'Z'; i++)
            {
                builder.AppendLine(i.ToString());
            }
            textBox.Text += builder.ToString();
        }
        private void 特殊符号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            StringBuilder builder = new StringBuilder();
            for(char i = ' '; i <= '~'; i++)
            {
                if(i < '0' || (i > '9' && i < 'A') || (i > 'Z' && i < 'a') || i > 'z')
                    builder.AppendLine(i.ToString());
            }
            textBox.Text += builder.ToString();
        }
        private void 全部符号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            StringBuilder builder = new StringBuilder();
            for(char i = ' '; i <= '~'; i++)
            {
                builder.AppendLine(i.ToString());
            }
            textBox.Text += builder.ToString();
        }
        //日期
        private void 年份ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            StringBuilder builder = new StringBuilder();
            for(int i = 1980; i <= DateTime.Now.Year; i++)
            {
                builder.AppendLine(i.ToString());
            }
            textBox.Text += builder.ToString();
        }
        private void yyyyMMddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            StringBuilder builder = new StringBuilder();
            for(DateTime i = new DateTime(1980, 1, 1); i <= DateTime.Now; i = i.AddDays(1))
            {
                builder.AppendLine(i.ToString(sender.ToString()));
            }
            textBox.Text += builder.ToString();
        }
        //号码
        private void 北京手机7位号段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            WebClient client = new WebClient();
            string html = client.DownloadString("http://www.bixinshui.com/city/1");
            MatchCollection matchs = Regex.Matches(html, "href=\"/phone/(\\d{7})\"");
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            StringBuilder builder = new StringBuilder();
            foreach(Match match in matchs)
            {
                if(match.Success)
                    builder.AppendLine(match.Groups[1].Value);
            }
            textBox.Text += builder.ToString();
            Cursor = Cursors.Default;
        }
        //拼音
        private string[] pys = "a\nai\nan\nang\nao\nba\nbai\nban\nbang\nbao\nbei\nben\nbeng\nbi\nbian\nbiao\nbie\nbin\nbing\nbo\nbu\nca\ncai\ncan\ncang\ncao\nce\ncen\nceng\ncha\nchai\nchan\nchang\nchao\nche\nchen\ncheng\nchi\nchong\nchou\nchu\nchua\nchuai\nchuan\nchuang\nchui\nchun\nchuo\nci\ncong\ncou\ncu\ncuan\ncui\ncun\ncuo\nda\ndai\ndan\ndang\ndao\nde\ndei\nden\ndeng\ndi\ndia\ndian\ndiao\ndie\nding\ndiu\ndong\ndou\ndu\nduan\ndui\ndun\nduo\ne\nei\nen\neng\ner\nfa\nfan\nfang\nfei\nfen\nfeng\nfo\nfou\nfu\nga\ngai\ngan\ngang\ngao\nge\ngei\ngen\ngeng\ngong\ngou\ngu\ngua\nguai\nguan\nguang\ngui\ngun\nguo\nha\nhai\nhan\nhang\nhao\nhe\nhei\nhen\nheng\nhong\nhou\nhu\nhua\nhuai\nhuan\nhuang\nhui\nhun\nhuo\nji\njia\njian\njiang\njiao\njie\njin\njing\njiong\njiu\nju\njuan\njue\njun\nka\nkai\nkan\nkang\nkao\nke\nken\nkeng\nkong\nkou\nku\nkua\nkuai\nkuan\nkuang\nkui\nkun\nkuo\nla\nlai\nlan\nlang\nlao\nle\nlei\nleng\nli\nlia\nlian\nliang\nliao\nlie\nlin\nling\nliu\nlong\nlou\nlu\nluan\nlue\nlun\nluo\nlv\nm\nma\nmai\nman\nmang\nmao\nme\nmei\nmen\nmeng\nmi\nmian\nmiao\nmie\nmin\nming\nmiu\nmo\nmou\nmu\nna\nnai\nnan\nnang\nnao\nne\nnei\nnen\nneng\nng\nni\nnian\nniang\nniao\nnie\nnin\nning\nniu\nnong\nnou\nnu\nnuan\nnun\nnuo\nnv\nnve\no\nou\npa\npai\npan\npang\npao\npei\npen\npeng\npi\npian\npiao\npie\npin\nping\npo\npou\npu\nqi\nqia\nqian\nqiang\nqiao\nqie\nqin\nqing\nqiong\nqiu\nqu\nquan\nque\nqun\nran\nrang\nrao\nre\nren\nreng\nri\nrong\nrou\nru\nruan\nrui\nrun\nruo\nsa\nsai\nsan\nsang\nsao\nse\nsen\nseng\nsha\nshai\nshan\nshang\nshao\nshe\nshei\nshen\nsheng\nshi\nshou\nshu\nshua\nshuai\nshuan\nshuang\nshui\nshun\nshuo\nsi\nsong\nsou\nsu\nsuan\nsui\nsun\nsuo\nta\ntai\ntan\ntang\ntao\nte\nteng\nti\ntian\ntiao\ntie\nting\ntong\ntou\ntu\ntuan\ntui\ntun\ntuo\nwa\nwai\nwan\nwang\nwei\nwen\nweng\nwo\nwu\nxi\nxia\nxian\nxiang\nxiao\nxie\nxin\nxing\nxiong\nxiu\nxu\nxuan\nxue\nxun\nya\nyan\nyang\nyao\nye\nyi\nyin\nying\nyo\nyong\nyou\nyu\nyuan\nyue\nyun\nza\nzai\nzan\nzang\nzao\nze\nzei\nzen\nzeng\nzha\nzhai\nzhan\nzhang\nzhao\nzhe\nzhei\nzhen\nzheng\nzhi\nzhong\nzhou\nzhu\nzhua\nzhuai\nzhuan\nzhuang\nzhui\nzhun\nzhuo\nzi\nzong\nzou\nzu\nzuan\nzui\nzun\nzuo".Split('\n');
        private void 小写拼音ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            StringBuilder builder = new StringBuilder();
            foreach(string py in pys)
            {
                builder.AppendLine(py);
            }
            textBox.Text += builder.ToString();
        }
        private void 首字母大写拼音ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            StringBuilder builder = new StringBuilder();
            foreach(string py in pys)
            {
                builder.AppendLine(char.ToUpper(py[0]) + py.Substring(1));
            }
            textBox.Text += builder.ToString();
        }
        private void 大写拼音ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            StringBuilder builder = new StringBuilder();
            foreach(string py in pys)
            {
                builder.AppendLine(py.ToUpper());
            }
            textBox.Text += builder.ToString();
        }

        //清空
        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            textBox.Clear();
        }

        //连接
        private void 交叉连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            textBox.Text = textBox.Text.TrimEnd();
            StringBuilder builder = new StringBuilder();
            foreach(string item1 in textBox.Lines)
            {
                foreach(string item2 in textBox.Lines)
                {
                    builder.AppendLine(item1 + item2);
                }
            }
            textBox.Text = builder.ToString();
        }
        private void 横向连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            StringBuilder builder = new StringBuilder();
            foreach(string item in textBox.Lines)
            {
                builder.AppendLine(item + item);
            }
            textBox.Text = builder.ToString();
        }

        //剔除
        private void 剔除长度小于等于1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            StringBuilder builder = new StringBuilder();
            foreach(string item in textBox.Lines)
            {
                if(item.Length > 1)
                    builder.AppendLine(item);
            }
            textBox.Text = builder.ToString();
        }
        private void 剔除长度小于等于2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            StringBuilder builder = new StringBuilder();
            foreach(string item in textBox.Lines)
            {
                if(item.Length > 2)
                    builder.AppendLine(item);
            }
            textBox.Text = builder.ToString();
        }
        private void 剔除长度小于等于3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = contextMenuStrip1.SourceControl as TextBox;
            StringBuilder builder = new StringBuilder();
            foreach(string item in textBox.Lines)
            {
                if(item.Length > 3)
                    builder.AppendLine(item);
            }
            textBox.Text = builder.ToString();
        }
    }
}

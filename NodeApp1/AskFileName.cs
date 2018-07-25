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

namespace NodeApp1
{
    public partial class AskFileName : Form
    {
        public Form1 form;
        public AskFileName(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }
        //public boolean show()
        //{
        //    this.show();
        //    while (true)
        //    {
        //        console.writeline("123");
        //    }
        //    return false;
        //}
        //点击取消按钮
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            form.initCatalogue();
            return;
        }
        //点击确定按钮
        private void button1_Click(object sender, EventArgs e)
        {
            String path = String.Empty;
            if (textBox1.Text == null)
            {
                MessageBox.Show("请输入文件名");
            }
            else {
                String name = textBox1.Text;
                //文件名中不含后缀名
                if (!name.Contains(Commans.wordTail)) {
                    name += ".docx";
                }
                 path = Commans.workPath + "\\" + name;
                //该文件已经存在
                if (FileSystem.contains(path))
                {
                    DialogResult dr = MessageBox.Show("该文件已经存在？是否覆盖？", "文件存在", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        //覆盖文件
                        FileSystem.create(path);
                    }
                    else
                    {
                        return;
                    }
                }
                //该文件并不存在
                else {
                    FileSystem.create(path);
                }
               
            }
            this.Close();
            this.Dispose();
            form.initCatalogue();
            //但是上面这个showFile执行了！！！！
            form.showFile(path);
            //这里现在有一个问题，这个并没有自动打开???
            form.openFile(path);
            
            return;
        }

        //private void AskFileName_KeyDown(object sender, KeyEventArgs e)
        //{
          
        //}

        //private void button1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    button1_Click(sender, e);
        //}
    }
}

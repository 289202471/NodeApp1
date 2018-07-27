using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NodeApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //axFramerControl1.Open("W:\\Projects\\C#workspace\\NodeApp1.0\\NodeApp1\\NodeApp1\\bin\\Debug\\Notes\\nihao.docx");
            //这个实验成功了！！！！！！
            winWordControl1.LoadDocument("W:\\Projects\\C#workspace\\NodeApp1.0\\NodeApp1\\NodeApp1\\bin\\Debug\\Notes\\nihao.docx");
        }
    }
}

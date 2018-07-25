using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NodeApp1
{
    public partial class Form1 : Form
    {
        //窗口初始化函数
        public Form1()
        {
            InitializeComponent();
            //格式化所有的表格，让表格充满灰色区域
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            //创建表格内容
            dataGridView1.DataSource = createTable();
            //格式化每一个表格大小，让每个表项根据内容大小调整宽度
            dataGridView1.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[0].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        }
        //填充目录
        private void fillCatalogue(FileInfo[] files) {
       
            DataTable tb = createTable();
            for (int i = 0; i < files.Length; i++) {
                DataRow dr = tb.NewRow();
                dr["Id"] = (i + 1).ToString();
                dr["Name"] = files[i].Name;
                dr["Time"] = DateTime.Now.ToString("yyyy-MM-dd").ToString();
                tb.Rows.Add(dr);
            }
            dataGridView1.DataSource = tb;

        }
        //初始化目录
        public void initCatalogue() {
            FileInfo[] files = FileSystem.scanCatalogue(Commans.workPath,Commans.wordType);
            fillCatalogue(files);
        }
       //创建目录表格
        private DataTable createTable()
        {
            //新建表
            DataTable dt = new DataTable();
            //定义表结构
            dt.Columns.Add("Id", typeof(System.Int32));//列名  列所在数据类型
            dt.Columns.Add("Name", typeof(System.String));
            dt.Columns.Add("Time", typeof(System.String));
            //添加新行
            //for (int i = 0; i <= 3; i++)
            //{
            //    DataRow dr = dt.NewRow();   //行
            //    dr[0] = i;
            //    dr[1] = "wandfsdfsadfsadfwfawefsdfadfasdfasdfasdfasdfasdfg" + i;
            //    dr[2] = "5" + i;
            //    dt.Rows.Add(dr);    //将行添加到DataTabl 格中```
            //}
            return dt;
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            initCatalogue();
        }
        private void test() {
            Console.WriteLine("Hello World!");
            FileInfo[] files=FileSystem.scanCatalogue(Commans.workPath,"*.docx");
            for (int i = 0; i < files.Length; i++) {
                Console.WriteLine(files[i].Name);
            }
        }
        //对外打开文件接口
        public void openFile(String path) {
            webBrowser1.Navigate(path);
        }
        public void showFile(String path) {
            docViewer1.LoadFromFile(path);
        }
        //打开按钮
        private void button3_Click(object sender, EventArgs e)
        {
            //获取用户选择的行
            int row = this.dataGridView1.CurrentRow.Index;
            //获取那行对应的IP地址
            String name = dataGridView1.Rows[row].Cells["Name"].Value.ToString();
            String path = Commans.workPath+ "\\" + name;
            //webBrowser1.Navigate(path);
            showFile(path);
            openFile(path);
        }
        //预览按钮
        private void button4_Click(object sender, EventArgs e)
        {
            //获取用户选择的行
            int row = this.dataGridView1.CurrentRow.Index;
            //获取那行对应的IP地址
            String name = dataGridView1.Rows[row].Cells["Name"].Value.ToString();
            String path = Commans.workPath + "\\" + name;
            Console.WriteLine(path);
            docViewer1.LoadFromFile(path);
        }
        //删除按钮
        private void button2_Click(object sender, EventArgs e)
        {
            //获取用户选择的行
            int row = this.dataGridView1.CurrentRow.Index;
            //获取那行对应的IP地址
            String name = dataGridView1.Rows[row].Cells["Name"].Value.ToString();
            String path = Commans.workPath + "\\" + name;
            FileSystem.delete(path);
            initCatalogue();
        }
        //创建按钮
        private void button1_Click(object sender, EventArgs e)
        {
            ////获取用户选择的行
            //int row = this.dataGridView1.CurrentRow.Index;
            ////获取那行对应的IP地址
            //String name = dataGridView1.Rows[row].Cells["Name"].Value.ToString();
            //String path = Commans.workPath + "\\" + name;
                //这里还是可以独立出来成为一个获得路径函数
            AskFileName askFileName = new AskFileName(this);//这里注意，这个新窗口和原来的主窗口是在不同进程中，所以下面如果直接写一些操作，
                                                        //但是这些操作需要等到用户输入完文件姓名的话，就会出现错误，因为两个进程并发执行，、
                                                        //用户还没来得及输入完姓名，下面的操作就已经结束了
            askFileName.Show();

        }
    }
}

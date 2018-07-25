using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp1
{
   public class FileSystem
    {
        //扫描文件目录，将获取的所有word文件的目录填入目录表格当中
        //第一个参数是路径，第二个参数是类型
        public static FileInfo[] scanCatalogue(String path, String type)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles(type);
            //Commans.hashtable.Clear();
            //for (int i = 0; i < files.Length; i++) {
            //    Commans.hashtable.Add(files[i].Name,path+"//"+files[i].Name);
            //}
            return files;
        }
        //扫描文件目录，将获取的所有word文件的目录填入目录表格当中
        //第一个参数是路径，第二个参数是类型
        public static FileInfo[] scanCatalogue(String path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            //Commans.hashtable.Clear();
            //for (int i = 0; i < files.Length; i++) {
            //    Commans.hashtable.Add(files[i].Name,path+"//"+files[i].Name);
            //}
            return files;
        }
        //判断某个文件目录下是否有这个文件
        public static Boolean contains(String path) {
            return File.Exists(path);
        }
        //创建文件
        public static void create(String path) {
            File.Create(path);
        }
        //删除文件
        public static void delete(String path) {
            File.Delete(path);
        }
    }
}

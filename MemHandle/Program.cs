using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace MemHandle
{
    class Program
    {
        static void Main(string[] args)
        {
          Console.WriteLine("请输入要监测进程的ID：");

            string s = Console.ReadLine();
            int prossId;
            if(int.TryParse(s,out prossId))
            {
                Console.WriteLine("输入的进程的ID为：{0}：", prossId);
            }
            else
            {
                Console.WriteLine("输入的进程的ID有误！");
            }

            //创建记录数据的文件
            //使用appdomain获取当前应用程序集的执行目录
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            string filename = dir + "/handle.txt";
            string filename1 = dir + "/memory.txt";
           
            StreamWriter sr = File.AppendText(filename);
            StreamWriter sr1 = File.AppendText(filename1);

           

            //获取句柄数（一共采集24小时，每分钟采集一次）
            for (int i=1;i<=1440;i++)
            {
                string a = Handle.GetHandle(prossId);
                //以年-月-日时分秒的格式命名文件 
                /*string tempTimeStr = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0')
                + "-" + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0')
                + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0'); 
                Console.WriteLine(tempTimeStr+":"+a); */

                Console.WriteLine("句柄数为："+a);
                sr.WriteLine(a);

                long b = Memory.GetMemroy(prossId);
                Console.WriteLine("内存为:"+b+"kb");
                sr1.WriteLine(b);

                Thread.Sleep(60000); //每隔60秒采集一次数据
            }
            sr.Close(); sr1.Close();

            Console.WriteLine("数据采集完成！");
            Console.ReadKey();

           
            







        }



    }




    }


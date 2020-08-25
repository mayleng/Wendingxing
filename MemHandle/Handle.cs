using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MemHandle
{
   public static  class Handle
    {
        public static string GetHandle(int prossId)
        {
            //获取当前进程
           // Process p = Process.GetCurrentProcess();

            Process p1 = Process.GetProcessById(prossId);
            string a = p1.HandleCount.ToString();

            return a;
        }
       
    }
}

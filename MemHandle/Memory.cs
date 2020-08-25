using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MemHandle
{
   public static class Memory
    {
        public static long GetMemroy(int prossId)
        {
            Process p = Process.GetProcessById(prossId);

            //专用内存，由该进程使用，其他进程无法使用的物理内存
           long memroy= p.PrivateMemorySize64 / 1024;

            //工作集内存，当前进程正在使用的内存
            //工作集(内存):此值就是该进程所占用的总物理内存. 但是这个值是由两部分组成, 即 '专用工作集' + '共享工作集'.
            long a = p.WorkingSet64 / 1024;


           // return memroy;
            return a;
        }

    }
}

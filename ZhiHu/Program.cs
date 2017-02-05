using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Model;
using Common;
using System.Threading;

namespace ZhiHu
{
    class Program
    {
        static void Main(string[] args)
        {
         
         //   ThreadPool.SetMaxThreads(10, 10);//设置最大线程数量
            //while (true)
            //{
            //    int AvailableThreadsCount = 0;
            //    int Available = 0;
            //    ThreadPool.GetAvailableThreads(out AvailableThreadsCount, out Available);
            //    if (AvailableThreadsCount > 0)
            //    {
            //        try
            //        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(GetUser);
            }
                     //     ThreadPool.QueueUserWorkItem(GetUser);
            //        }
            //        catch
            //        {
                       
            //        }
            //    }
            //    else
            //    {
            //        Thread.Sleep(100);
            //    }
            //}
            Console.ReadLine();
        }

        private static void GetUser(object data)
        {

            while (true)
            {
                string url_token = RedisCore.PopFromList(1, "urltoken");
                Console.WriteLine(url_token);
                if (!string.IsNullOrEmpty(url_token))
                {
                    UserManage manage = new UserManage(url_token);
                    manage.analyse();
                }
                else
                {
                    GetNexturl();
                }
            }
              
        }
        private static void GetNexturl()
        {
            string nexturl = RedisCore.PopFromList(1, "nexturl");
            if (!string.IsNullOrEmpty(nexturl))
            {
                UrlTask task = new UrlTask(nexturl);
                task.Analyse();
            }
        }
      
    }
}


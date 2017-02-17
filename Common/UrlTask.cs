using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Diagnostics;
using System.Threading;

namespace Common
{
    public class UrlTask
    {
        private  string url { get; set; }
        private string JSONstring { get; set; }
        public UrlTask(string _url)
        {
            url = _url;  
        }
        private bool GetHtml()
        {
            JSONstring= HttpHelp.DownLoadString(url);
            Console.WriteLine("Json下载完成");
            return !string.IsNullOrEmpty(JSONstring);
        }
        public  void  Analyse() 
        {
            try
            {
                if (GetHtml())
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
               
                    followerResult result = SerializeHelper.DeserializeToObject<followerResult>(JSONstring);
                     if (!result.paging.is_end)
                     {
                      
                         RedisManage.AddNextUrl(result.paging.next);
                      }                           
                    foreach (var item in result.data)
                    {
                     
                        RedisManage.AddUrltoken(item.url_token);
                    }
                    watch.Stop();
                    Console.WriteLine("解析json用了{0}毫秒",watch.ElapsedMilliseconds.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
          
        }
    }
}

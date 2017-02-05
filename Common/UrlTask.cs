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
                         RedisCore.PushIntoList(1, "nexturl", result.paging.next);                
                      }                           
                    foreach (var item in result.data)
                    {
                         int type=Math.Abs(item.GetHashCode())% 3 + 3;
                         if (RedisCore.InsetIntoHash(type, "urltokenhash", item.url_token, "存在"))
                         {
                             RedisCore.PushIntoList(1, "urltoken", item.url_token);
                           
                         }
                      
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

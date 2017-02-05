using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class HttpHelp
    {
         public static string DownLoadString(string url)
         {

             try
             {
                 HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                 request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:49.0) Gecko/20100101 Firefox/49.0";
                 request.Headers.Add("Authorization", "Bearer Mi4wQUJCS0c2ZmVTUWtBZ0FMRXpRWUxDeGNBQUFCaEFsVk5xLUNGV0FCSV96RnhlMFhXTEdyRDJLcHBBazVzYllFUmhB|1482576928|e8eb7aeafaa8967040018749e51b6117aac6268a");
                 request.Headers.Add("Cookie", "q_c1=83e6114181b446cf8d7466b7170722aa|1482498542000|1482498542000; l_cap_id=\"NWE1NTA1OTY4YzhkNGJkOWE5ZjlkMzRmNzJiZDJlN2Q=|1482576778|229fbce9a467bb4d775a2da16ad487d881f72985\"; cap_id=\"ZmIzZWIzZGE0OTAyNGI4Y2I2MDhjMjZiYjFmNzRlZDk=|1482576778|86cc3a713579014bb2842a210e2dbc697b9a7eac\"; d_c0=\"AIACxM0GCwuPThs-yU5VfWR2bZkix3yL2gI=|1482498542\"; r_cap_id=\"ZTI0OWVjYzNhNjZhNDM1MDg1YzEzYzMzZTY1NWYxNmY=|1482576780|c5947a54eb95b365735892d0048786cb0e87515c\"; __utma=51854390.1994869475.1482498545.1482498545.1482576782.2; __utmz=51854390.1482576782.2.2.utmcsr=baidu|utmccn=(organic)|utmcmd=organic; __utmv=51854390.100-1|2=registration_date=20160110=1^3=entry_date=20160110=1; _xsrf=4d75dd8958dfe9b129bef878f8d330a4; n_c=1; _zap=b4e1f464-b1e6-4a52-b272-231e749d5009; __utmb=51854390.13.9.1482576890989; __utmc=51854390; login=\"YTViZjk0Mzc2YjkwNDU1NDkyYjYwNzUzNGFlMmMyNTY=|1482576798|0d4999bd33997683a2677d550674cb9cedd772c0\"; z_c0=Mi4wQUJCS0c2ZmVTUWtBZ0FMRXpRWUxDeGNBQUFCaEFsVk5xLUNGV0FCSV96RnhlMFhXTEdyRDJLcHBBazVzYllFUmhB|1482576928|e8eb7aeafaa8967040018749e51b6117aac6268a");
                 HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                 using (Stream dataStream = response.GetResponseStream())
                 {
                     using (StreamReader reader = new StreamReader(dataStream, Encoding.UTF8))
                     {
                         string html = reader.ReadToEnd();
                         return html;

                     }
                 }
             }
             catch
             {
                 return "";
             }
         }
    }
}

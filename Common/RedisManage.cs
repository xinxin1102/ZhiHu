using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public  class RedisManage
    {
        public static void AddUrltoken(string urltoken)
        {
            int type = Math.Abs(urltoken.GetHashCode()) % 3 + 3;
            if (RedisCore.InsetIntoHash(type, "urltokenhash", urltoken, "存在"))
            {
                RedisCore.PushIntoList(1, "urltoken", urltoken);

            }
        }
        public static string GetUrltoken()
        {
            return RedisCore.PopFromList(1, "urltoken");
        }
        public static void AddNextUrl(string next)
        {
            RedisCore.PushIntoList(1, "nexturl",next); 
        }
        public static string GetNextUrl()
        {
            return RedisCore.PopFromList(1, "nexturl");
        }
        public static void PushUserInfo(string UserInfo)
        {
            RedisCore.PushIntoList(2, "User", UserInfo);
        }
        public static string  GetUserInfo()
        {
            return   RedisCore.PopFromList(2, "User");
        }
    }
}

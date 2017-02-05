using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace Common
{
    public class RedisCore
    {
        //public static List<string> ips = new List<string>()
        //{
        //    "59.74.169.54",
        //    "59.74.169.57",
        //    "59.74.169.52",
        //    "59.74.169.58",
        //    "59.74.169.39"
        //};
        //public static List<string> ips = new List<string>()
        //{
        //    "127.0.0.1",
        //    "127.0.0.1",
        //    "127.0.0.1",
        //    "127.0.0.1",
        //    "127.0.0.1"
        //};
        public static bool PushIntoList(int type, string key, string value)
        {
            bool Result = false;
            using (RedisClient Redis = new RedisClient("127.0.0.1", 6379))
            {
                Redis.ConnectTimeout = 2000;
                Result = Redis.RPush(key, Encoding.UTF8.GetBytes(value)) > 0;
            }
            return Result;
        }
        public static string PopFromList(int type, string key)
        {
            try
            {
                string result = string.Empty;
                using (RedisClient Redis = new RedisClient("127.0.0.1", 6379))
                {
                    Redis.ConnectTimeout = 2000;
                    result = Encoding.UTF8.GetString(Redis.LPop(key));
                }
                return result;
            }
            catch
            {
                return "";
            }
        }
        public static bool InsetIntoHash(int type, string hashid, string key, string value)
        {
            bool result = false;
            try
            {
                using (RedisClient Redis = new RedisClient("127.0.0.1", 6379))
                {
                    Redis.ConnectTimeout = 2000;
                    result = Redis.SetEntryInHashIfNotExists(hashid, key, value);
                }
            }
            catch { }

            return result;
        }
      
    }
}

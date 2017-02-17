using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Runtime.Remoting.Messaging;

namespace Common
{
    public    class DBContextFactory
    {
        public static ZhihuEntity GetDbcontext()
        {
            ZhihuEntity Entity = CallContext.GetData("ZhihuEntity") as ZhihuEntity;
            if (Entity==null)
            {
                Entity = new ZhihuEntity();
                CallContext.SetData("ZhihuEntity", Entity);
            }
            return Entity;
        }
        public static TempEntity GetTempContext()
        {
            TempEntity Entity = CallContext.GetData("TempEntity") as TempEntity;
            if (Entity==null)
            {
                Entity = new TempEntity();
                CallContext.SetData("TempEntity", Entity);
            }
            return Entity;
        }
  
    }
}

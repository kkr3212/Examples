using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EchoServer.Logic
{
    public static class Protocol
    {
        public const int Hello_Ntf = 1000;
        public const int Echo_Req = 1001;
        public const int Echo_Res = 1002;
    }
}

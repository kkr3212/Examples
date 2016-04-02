using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis.Utils;
using RPGGame.Common;



namespace RPGGame.GameServer.ServerSystem
{
    public static class Statistics
    {
        public static Int32 CCU { get; }
        public static IntervalCounter SentBytes { get; } = new IntervalCounter(1000);
        public static IntervalCounter SentCount { get; } = new IntervalCounter(1000);
        public static IntervalCounter ReceivedBytes { get; } = new IntervalCounter(1000);
        public static IntervalCounter ReceivedCount { get; } = new IntervalCounter(1000);

        public static Int32 QPSAuthDB { get { return AuthDB.TotalQPS; } }
        public static Int32 QPSGameDB { get { return GameDB.TotalQPS; } }
    }
}

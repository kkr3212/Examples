using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;



namespace RPGGame.GameServer.GameMap
{
    public static class GameMapLoader
    {
        public static void Refresh()
        {
            Logger.Write(LogType.Info, 2, "Loading GameMap......");
            {
                PvE_World.Refresh();
                PvE_Field.Refresh();
                PvE_Dungeon.Refresh();
                PvE_Round.Refresh();
                PvE_MonsterPool.Refresh();
            }
            Logger.Write(LogType.Info, 2, "Completed.");
        }
    }
}

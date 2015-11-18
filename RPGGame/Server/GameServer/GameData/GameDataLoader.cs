using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;



namespace RPGGame.GameServer.GameData
{
    public static class GameDataLoader
    {
        public static void Refresh()
        {
            Logger.Write(LogType.Info, 2, "Loading GameData......");
            {
                Codes.Refresh();
                PlayerBook.Refresh();
                CharacterBook.Refresh();
                MonsterBook.Refresh();
                ItemBook.Refresh();
                FirstSupply.Refresh();
            }
            Logger.Write(LogType.Info, 2, "Completed.");
        }
    }
}

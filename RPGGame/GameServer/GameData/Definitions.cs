using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RPGGame.GameServer.GameData
{
    public enum DeckType
    {
        PvE_Normal,
        PvE_Training,
        PvP_BattleField,
        PvP_Crusade,
        Count
    }


    public static class Constants
    {
        public const Int32 MaxDeckSlotCount = 5;
    }
}

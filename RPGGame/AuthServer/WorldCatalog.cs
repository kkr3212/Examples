using System;
using System.Collections.Generic;
using System.Linq;
using Aegis.Data.MySql;
using RPGGame.Common;



namespace RPGGame.AuthServer
{
    public class WorldInfo
    {
        public Int32 WorldId;
        public String WorldName;
        public Boolean IsOpen;
    }



    public static class WorldCatalog
    {
        public static List<WorldInfo> Items { get; private set; } = new List<WorldInfo>();



        public static void Refresh()
        {
            Items.Clear();

            using (DBCommand cmd = SystemDB.NewCommand())
            using (DataReader reader = cmd.Query("select worldid, worldname, isopen from t_listworld;"))
            {
                while (reader.Read())
                {
                    Int32 worldId = reader.GetInt32(0);
                    String worldName = reader.GetString(1);
                    Boolean isOpen = (reader.GetInt16(2) == 1);

                    Items.Add(new WorldInfo()
                    {
                        WorldId = worldId,
                        WorldName = worldName,
                        IsOpen = isOpen
                    });
                }
            }
        }


        public static Boolean IsValidWorldId(Int32 worldId)
        {
            WorldInfo world = Items.Find(v => v.WorldId == worldId);
            return (world != null && world.IsOpen == true);
        }
    }
}

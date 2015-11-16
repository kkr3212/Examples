using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aegis;
using Aegis.Data.MySql;
using RPGGame.Common;
using RPGGame.GameServer.ServerSystem;



namespace RPGGame.GameServer.UserData
{
    public partial class GameUser
    {
        public ClientSession Session { get; set; }


        public Int32 SeqNo { get; set; }
        public Int32 UserNo { get; }
        public String Nickname { get; private set; }
        public Int32 Level { get; private set; }
        public Int32 Exp { get; private set; }
        public Int32 VIPLevel { get; private set; }
        public Int32 VIPExp { get; private set; }
        public Int32 LastManagerMailNo { get; private set; }

        public readonly Energy Energy;
        public readonly Resource Resource;
        public readonly InvenCharacter InvenCharacter;
        public readonly InvenItem InvenItem;
        public readonly PlayDeck PlayDeck;
        public Character MainCharacter { get; private set; }





        public GameUser(Int32 userNo)
        {
            UserNo = userNo;
            Energy = new Energy(this);
            Resource = new Resource(this);
            InvenCharacter = new InvenCharacter(this);
            InvenItem = new InvenItem(this);
            PlayDeck = new PlayDeck(this);
        }


        public void SendPacket(StreamBuffer buffer, Action<StreamBuffer> onSent = null)
        {
            Session?.SendPacket(buffer, onSent);
        }
    }
}

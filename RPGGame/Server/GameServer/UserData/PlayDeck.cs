using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;
using RPGGame.Common;
using RPGGame.GameServer.GameData;
using MySql.Data.MySqlClient;



namespace RPGGame.GameServer.UserData
{
    public class PlayDeck
    {
        public class Deck
        {
            public readonly DeckType DeckType;
            public readonly Character[] Characters = new Character[Constants.MaxDeckSlotCount];
            public Deck(DeckType type)
            {
                DeckType = type;
            }
            public void Clear()
            {
                Array.Clear(Characters, 0, Characters.Length);
            }
        }
        public readonly List<Deck> Decks = new List<Deck>();
        private readonly GameUser _user;

        public Deck this[DeckType deckType]
        {
            get
            {
                if (deckType >= DeckType.Count)
                    throw new AegisException(ResultCode.InvalidDeckType);

                Deck deck = Decks.Find(v => v.DeckType == deckType);
                if (deck == null)
                {
                    deck = new Deck(deckType);
                    Decks.Add(deck);
                }

                return deck;
            }
        }





        public PlayDeck(GameUser user)
        {
            _user = user;
        }


        public void LoadFromDB(MySqlDataReader reader)
        {
            Decks.ForEach(v => v.Clear());


            while (reader.Read())
            {
                DeckType deckType = (DeckType)reader.GetInt32(0);
                Int32 slotNo = reader.GetInt16(1);
                Int32 characterNo = reader.GetInt32(2);

                this[deckType].Characters[slotNo] = _user.InvenCharacter.Find(characterNo);
            }
        }


        public void UpdateToDB(DeckType deckType)
        {
            using (var cmd = GameDB.NewCommand(_user.UserNo))
            {
                Deck deck = this[deckType];
                Int32 idx = 0;


                cmd.CommandText.Append("delete from t_playdeck where userno=@userno and decktype=@decktype;");
                cmd.BindParameter("@userno", _user.UserNo);
                cmd.BindParameter("@decktype", (Int16)deckType);


                if (deck.Characters.Where(v => v != null).Count() > 0)
                {
                    cmd.CommandText.Append("insert into t_playdeck values");
                    for (Int32 slotNo = 0; slotNo < deck.Characters.Length; ++slotNo)
                    {
                        if (deck.Characters[slotNo] == null)
                            continue;

                        cmd.CommandText.AppendFormat("(@{0}, @{1}, @{2}, @{3}),", idx + 0, idx + 1, idx + 2, idx + 3);
                        cmd.BindParameter(String.Format("@{0}", idx + 0), _user.UserNo);
                        cmd.BindParameter(String.Format("@{0}", idx + 1), deckType);
                        cmd.BindParameter(String.Format("@{0}", idx + 2), slotNo);
                        cmd.BindParameter(String.Format("@{0}", idx + 3), deck.Characters[slotNo].CharacterNo);

                        idx += 4;
                    }
                    cmd.CommandText[cmd.CommandText.Length - 1] = ';';
                }
                cmd.PostQueryNoReader();
            }
        }
    }
}

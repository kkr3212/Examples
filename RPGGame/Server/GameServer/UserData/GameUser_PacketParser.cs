using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Aegis;
using Aegis.Converter;
using Aegis.Data.MySql;
using RPGGame.Common;
using RPGGame.GameServer.GameData;



namespace RPGGame.GameServer.UserData
{
    public partial class GameUser
    {
        private void OnCS_UserData_InitUser_Req(SecurePacketRequest reqPacket)
        {
            SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket);
            String nickname = reqPacket.GetStringFromUtf16();


            resPacket.ResultCodeNo = InitUser(nickname);
            SendPacket(resPacket);
        }


        private void OnCS_UserData_UserInfo_Req(SecurePacketRequest reqPacket)
        {
            SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket);
            resPacket.ResultCodeNo = ResultCode.Ok;
            resPacket.PutStringAsUtf16(Nickname);
            resPacket.PutInt32(Level);
            resPacket.PutInt32(Exp);
            resPacket.PutInt32(VIPLevel);
            resPacket.PutInt32(VIPExp);


            //  Energy
            resPacket.PutInt32(Energy.Items.Count);
            foreach (var energy in Energy.Items)
            {
                resPacket.PutInt32(energy.EnergyId);
                resPacket.PutInt32(energy.Point);
                resPacket.PutInt32(energy.RemainSecond);
            }


            //  Resource
            resPacket.PutInt32(Resource.Items.Count);
            foreach (var resource in Resource.Items)
            {
                resPacket.PutInt32(resource.ResourceId);
                resPacket.PutInt32(resource.Point);
            }

            SendPacket(resPacket);
        }


        private void OnCS_UserData_InvenCharacter_Req(SecurePacketRequest reqPacket)
        {
            SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket, 65000);
            resPacket.ResultCodeNo = ResultCode.Ok;


            resPacket.PutInt32(MainCharacter.CharacterNo);
            resPacket.PutInt32(PlayerBook.PlayerLevel.Items[Level].MaxCharacterInventory);
            resPacket.PutInt32(InvenCharacter.Items.Count);
            foreach (var ch in InvenCharacter.Items)
            {
                resPacket.PutInt32(ch.CharacterNo);
                resPacket.PutInt32(ch.Base.CharacterId);
                resPacket.PutInt32(ch.Level);
                resPacket.PutInt32(ch.Exp);
                resPacket.PutInt32(ch.GradeId);
                resPacket.PutInt32(ch.PromotionId);
            }

            SendPacket(resPacket);
        }


        private void OnCS_UserData_InvenItem_Req(SecurePacketRequest reqPacket)
        {
            SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket, 65000);
            resPacket.ResultCodeNo = ResultCode.Ok;


            resPacket.PutInt32(PlayerBook.PlayerLevel.Items[Level].MaxItemInventory);
            resPacket.PutInt32(InvenItem.Items.Count);
            foreach (var item in InvenItem.Items)
            {
                resPacket.PutInt32(item.ItemNo);
                resPacket.PutInt32(item.Base.ItemId);
                resPacket.PutInt32(item.PromotionId);
                resPacket.PutInt32(item.Quantity);
            }

            SendPacket(resPacket);
        }
    }
}

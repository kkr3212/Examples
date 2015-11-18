using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis.Client;
using Aegis.Client.Network;



namespace NetworkAPI
{
    public static partial class Requester
    {
        private static Request _request = new Request();
        private static String _aesIV = "NP_Contents_001 ";
        private static String _aesKey = "#@a73S  ls$#che_";
        private static String _authIpAddress;
        private static Int32 _authPortNo;


        public static Int32 ConnectionAliveTime
        {
            get { return _request.ConnectionAliveTime; }
            set { _request.ConnectionAliveTime = value; }
        }
        public static ConnectionStatus ConnectionStatus { get { return _request.ConnectionStatus; } }
        public static event NetworkStatusHandler NetworkStatusChanged;





        public static void Initialize()
        {
            _request.EnableSend = false;
            _request.AESIV = _aesIV;
            _request.AESKey = _aesKey;
            _request.ConnectionAliveTime = 3000;
            _request.NetworkStatusChanged += OnNetworkStatusChanged;
            _request.PacketPreprocessing += OnPacketPreprocessing;
            _request.PacketSending += OnPacketSending;
            _request.Initialize();
        }


        public static void SetAuthServer(String ipAddress, Int32 portNo)
        {
            if (_request.HostAddress == null)
            {
                _request.HostAddress = _authIpAddress = ipAddress;
                _request.HostPortNo = _authPortNo = portNo;
            }
            else
            {
                _authIpAddress = ipAddress;
                _authPortNo = portNo;
            }
        }


        public static void Update()
        {
            _request.Update();
        }


        public static void Disconnect()
        {
            _request.Disconnect();
        }


        public static void Release()
        {
            _request.Release();
        }


        private static void OnNetworkStatusChanged(NetworkStatus status)
        {
            if (status == NetworkStatus.Disconnected)
            {
                _request.AESIV = _aesIV;
                _request.AESKey = _aesKey;
                _request.EnableSend = false;
            }

            if (NetworkStatusChanged != null)
                NetworkStatusChanged(status);
        }


        private static bool OnPacketPreprocessing(SecurePacket packet)
        {
            if (packet.PacketId == Protocol.GetID("CS_Hello_Ntf"))
            {
                OnHello(packet);
                return true;
            }
            if (packet.PacketId == Protocol.GetID("CS_Auth_ForceClosing_Ntf"))
            {
                OnNetworkStatusChanged(NetworkStatus.SessionForceClosed);
                return true;
            }

            return false;
        }


        private static bool OnPacketSending(SecurePacket packet)
        {
            if ((packet.PacketId & 0xF000) == 0x2000 &&
                (_request.HostAddress != _authIpAddress || _request.HostPortNo != _authPortNo))
            {
                _request.HostAddress = _authIpAddress;
                _request.HostPortNo = _authPortNo;
                _request.ConnectionAliveTime = 3000;
                _request.EnableSend = false;
                _request.Disconnect();
                return false;
            }

            return true;
        }


        private static void OnHello(SecurePacket packet)
        {
            Int32 ret = packet.GetInt32();
            Int32 serverType = packet.GetInt32();

            if (serverType == (Int32)ServerType.GameServer)
            {
                Int32 seed = packet.GetInt32();
                String characterSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
                char[] ascii = new char[16];


                for (Int32 i = 0; i < 16; ++i)
                {
                    Int32 val = seed & (0x6E << i);
                    ascii[i] = characterSet[(val % characterSet.Length)];
                }
                _request.AESIV = new String(ascii);


                for (Int32 i = 0; i < 16; ++i)
                {
                    Int32 val = seed & (0xF4 << i);
                    ascii[i] = characterSet[(val % characterSet.Length)];
                }
                _request.AESKey = new String(ascii);
            }

            _request.EnableSend = true;
        }
    }
}

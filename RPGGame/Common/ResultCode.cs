using System;



namespace RPGGame.Common
{
    public static class ResultCode
    {
        public const Int32 Ok = 0;
        public const Int32 Unknown_Error = 1;
        public const Int32 Database_Error = 2;
        public const Int32 System_Error = 3;
        public const Int32 InvalidUid = 4;

        public const Int32 NoAvailableServer = 100;
        public const Int32 ServiceClosed = 101;
        public const Int32 ExistsUserToken = 102;
        public const Int32 NewUser = 103;

        public const Int32 InvalidUserToken = 200;
        public const Int32 InvalidUserNo = 201;
        public const Int32 InvalidAuthKey = 202;
        public const Int32 InvalidOperation = 203;
        public const Int32 InvalidDeckType = 204;
    }
}

using System;
using System.Diagnostics;



namespace RPGGame.Common
{
    public static class ExtendMethod
    {
        public static Int32 SafeAdd(this Int32 src, Int32 val)
        {
            if (val < 0 && src < (0 - val))
                src = 0;
            else
                src += (Int32)val;

            return src;
        }


        public static Int32 SafeSubstract(this Int32 src, Int32 val)
        {
            if (src < val)
                return 0;

            return src - val;
        }
    }





    public static class Debugging
    {
        [Conditional("Debug")]
        public static void DebugBreak()
        {
            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }


        [Conditional("Debug")]
        public static void Assert(Boolean cond)
        {
            if (cond == false && System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }
    }
}

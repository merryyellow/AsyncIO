using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncIO
{
    public static class ForceDotNet
    {
        internal static bool Forced { get; private set; }

        static ForceDotNet()
        {
            // Set to true by default since it's for Unity
            Forced = true;
        }

        public static void Force()
        {
            Forced = true;
        }

        public static void Unforce()
        {
            Forced = false;
        }
    }
}

using System;
using System.Runtime.InteropServices;

namespace quiz_app_example.Utils
{
    public static class OperationSystemHelper
    {
        public static OSPlatform GetOperationSystem()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OSPlatform.OSX;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return OSPlatform.Linux;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return OSPlatform.Windows;
            }

            throw new Exception("Cannot determine operating system!");
        }

        public static Boolean ISOSXSystem()
        {
            return GetOperationSystem() == OSPlatform.OSX;
        }
    }
}


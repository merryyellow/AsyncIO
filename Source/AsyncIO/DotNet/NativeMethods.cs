// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

// https://github.com/aspnet/KestrelHttpServer/blob/5c1fcd664d39db8fe5c8e38052a3cc29f90322f6/src/Kestrel.Transport.Sockets/Internal/NativeMethods.cs

using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;

//namespace Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets.Internal
namespace AsyncIO.DotNet
{
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetHandleInformation(IntPtr hObject, HANDLE_FLAGS dwMask, HANDLE_FLAGS dwFlags);

        [Flags]
        private enum HANDLE_FLAGS : uint
        {
            None = 0,
            INHERIT = 1,
            PROTECT_FROM_CLOSE = 2
        }

        internal static void DisableHandleInheritance(Socket socket)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                SetHandleInformation(socket.Handle, HANDLE_FLAGS.INHERIT, 0);
            }
        }
    }
}
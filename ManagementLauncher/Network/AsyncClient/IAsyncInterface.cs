﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementLauncher.Network.AsyncClient
{
    public interface IAsyncInterface
    {
        bool OnConnect(AsyncContext context);

        bool OnReceive(AsyncContext context, byte[] buffer, int count);

        void OnDisconnect(AsyncContext context);

        void OnError(AsyncContext context, object user);

        void OnTick(AsyncContext context);
    }
}
﻿using ManagementLauncher.Network.AsyncClient;
using ManagementLauncher.Network.Security;
using System;
using System.Collections.Generic;
using System.IO;

namespace ManagementLauncher.Network
{
    class LauncherInterface : IAsyncInterface
    {
        public bool OnConnect(AsyncContext context)
        {
            LauncherClient.LData = new LauncherData
            {
                m_connected = true
            };
            context.User = LauncherClient.LData;
            return true;
        }

        public void OnDisconnect(AsyncContext context)
        {
            LauncherClient.LData = (LauncherData)context.User;
            LauncherClient.LData.m_connected = false;
        }

        public void OnError(AsyncContext context, object user)
        {
            if (context != null && context.User != null)
            {
                LauncherClient.LData = (LauncherData)context.User;
                LauncherClient.LData.m_connected = false;
            }
        }

        public bool OnReceive(AsyncContext context, byte[] buffer, int count)
        {
            LauncherClient.LData = (LauncherData)context.User;

            LauncherClient.LData.m_security.Recv(buffer, 0, count);
            List<Packet> packets = LauncherClient.LData.m_security.TransferIncoming();

            if (packets != null)
            {
                foreach (Packet packet in packets)
                {
                    if (packet.Opcode == 0xA001)
                    {
                        int version = packet.ReadInt();
                        if (Launcher.LConfig.Version != version)
                        {
                            Packet RequestUpdate = new Packet(0x3000);
                            RequestUpdate.WriteInt(Launcher.LConfig.Version);
                            LauncherClient.LData.m_security.Send(RequestUpdate);
                        }
                        else
                        {
                            Launcher.WriteStaticLine($"Studio version {Launcher.LConfig.Version} is up to date!");
                            Launcher.StaticLauncher.vSroSmallButtonPatch.Invoke(new Action(() => Launcher.StaticLauncher.vSroSmallButtonPatch.Enabled = false));
                            Launcher.StaticLauncher.vSroSmallButtonStart.Invoke(new Action(() => Launcher.StaticLauncher.vSroSmallButtonStart.Enabled = true));
                        }

                    }
                    else if (packet.Opcode == 0xA002)
                    {
                        int cversion = packet.ReadInt();
                        string fileName = packet.ReadAscii();
                        string fileDire = packet.ReadAscii();
                        byte[] cBinaryF = packet.ReadByteArray(packet.Remaining);


                        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileDire)))
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), fileDire));
                        }

                        //if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileDire, fileName)))
                        using (FileStream stream = File.Create(Path.Combine(Directory.GetCurrentDirectory(), fileDire, fileName)))
                        {
                            stream.Write(cBinaryF, 0, cBinaryF.Length);
                            stream.Close();
                        };

                        if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileDire, fileName)))
                        {
                            Launcher.WriteStaticLine($"Received file: {Path.Combine(Directory.GetCurrentDirectory(), fileDire, fileName)}");
                            continue;
                        }

                        return false;
                    }
                    else if (packet.Opcode == 0xA003)
                    {
                        int newVersion = packet.ReadInt();
                        Launcher.WriteStaticLine($"Update version {newVersion} finished!");
                        Config.InitializeConfig.ConfigFile.IniWriteValue("ToolServer", "Version", newVersion.ToString());
                        Launcher.StaticLauncher.vSroSmallButtonPatch.Enabled = false;
                        Launcher.StaticLauncher.vSroSmallButtonStart.Enabled = true;
                    }
                }
            }


            return true;
        }

        public void OnTick(AsyncContext context)
        {
            LauncherClient.LData = (LauncherData)context.User;

            if (LauncherClient.LData == null)
            {
                return;
            }

            if (!LauncherClient.LData.m_connected)
            {
                return;
            }

            List<KeyValuePair<TransferBuffer, Packet>> buffers = LauncherClient.LData.m_security.TransferOutgoing();
            if (buffers != null)
            {
                foreach (KeyValuePair<TransferBuffer, Packet> buffer in buffers)
                {
                    context.Send(buffer.Key.Buffer, 0, buffer.Key.Size);
                }
            }
        }
    }
}

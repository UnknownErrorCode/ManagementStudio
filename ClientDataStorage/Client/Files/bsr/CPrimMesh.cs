﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Client.Files.bsr
{
    public class CPrimMesh
    {

        public uint MeshPathLength { get; set; }
        public string MeshPath { get; set; }

        /// <summary>
        /// If (header.Int0 & 1)    =>   this->dword310 = 1
        /// </summary>
        public uint meshUnkUInt0 { get; set; }
    }
}
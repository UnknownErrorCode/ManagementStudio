﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Client.Files.bsr
{
    public class CPrimMaterialSet
    {

       public uint MaterialID { get; set; }
       public uint MaterialPathLength { get; set; }
       public string MaterialPath { get; set; }
    }
}
using Structs.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Editors.Teleport
{
    public class SingleTeleport
    {
        public bool IsNpcTeleport { get; set; }
        public RefObjCommon ObjCommon { get; set; }
        public RefTeleport Teleport { get; set; }

        public Tab_RefNest Nest { get; set; }
        public List<RefTeleLink> TeleLinks { get; set; } = new List<RefTeleLink>();

       // public PointF ControlPosition { get; set; }
        public SingleTeleport(RefTeleport teleport)
        {
            Teleport = teleport;
            InitializeTeleport();


        }

        private void InitializeTeleport()
        {
            if (!Teleport.AssocRefObjID.Equals(0))
            {
                if (ClientDataStorage.Database.SRO_VT_SHARD._RefObjCommon.TryGetValue(Teleport.AssocRefObjID, out RefObjCommon objCommon))
                {
                    ObjCommon = objCommon;
                    IsNpcTeleport = (ObjCommon.TypeID1 == 1 && ObjCommon.TypeID2 == 2 && ObjCommon.TypeID3 == 2 && ObjCommon.TypeID4 == 0);
                  // if (IsNpcTeleport)
                  // {
                  //     if (ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefTactics.Values.Any(tac => tac.dwObjID.Equals(ObjCommon.ID)))
                  //     {
                  //         var tac = ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefTactics.Values.First(tact => tact.dwObjID.Equals(ObjCommon.ID));
                  //
                  //         if (ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest.Values.Any(nest => nest.dwTacticsID.Equals(tac.dwTacticsID)))
                  //         {
                  //             Nest = ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest.Values.First(nest => nest.dwTacticsID.Equals(tac.dwTacticsID));
                  //             ControlPosition = new PointF(Nest.fLocalPosX, Nest.fLocalPosZ);
                  //         }
                  //     }
                  // }
                  // else
                  // {
                  //     ControlPosition = new PointF(ObjCommon.OffsetX, ObjCommon.OffsetZ);
                  // }
                }
            }
            for (int i = 0; i < ClientDataStorage.Database.SRO_VT_SHARD._RefTeleLink.Count; i++)
            {
                if (ClientDataStorage.Database.SRO_VT_SHARD._RefTeleLink[i].OwnerTeleport.Equals(Teleport.ID)
                    || ClientDataStorage.Database.SRO_VT_SHARD._RefTeleLink[i].TargetTeleport.Equals(Teleport.ID))
                    TeleLinks.Add(ClientDataStorage.Database.SRO_VT_SHARD._RefTeleLink[i]);
            }
        }
    }
}
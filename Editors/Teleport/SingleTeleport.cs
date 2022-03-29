using Structs.Database;
using System.Collections.Generic;

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
                }
            }
            for (int i = 0; i < ClientDataStorage.Database.SRO_VT_SHARD._RefTeleLink.Count; i++)
            {
                if (ClientDataStorage.Database.SRO_VT_SHARD._RefTeleLink[i].OwnerTeleport.Equals(Teleport.ID)
                    || ClientDataStorage.Database.SRO_VT_SHARD._RefTeleLink[i].TargetTeleport.Equals(Teleport.ID))
                {
                    TeleLinks.Add(ClientDataStorage.Database.SRO_VT_SHARD._RefTeleLink[i]);
                }
            }
        }
    }
}
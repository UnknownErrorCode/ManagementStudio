using Editors.Teleport;
using Structs.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal abstract class ITeleport
    {
        /// <summary>
        /// Contains all Database Informations about the spawn.
        /// </summary>
        internal SingleTeleport TeleportData { get; set; }
        /// <summary>
        /// Ordinate of Region Coorainate.
        /// </summary>
        internal byte X { get; set; }

        /// <summary>
        /// Abszisse of Region Coordinate.
        /// </summary>
        internal byte Y { get; set; }

        /// <summary>
        /// Region Identifier build as Int16 from a string that consists of HexString(Y) + HexString(X) .
        /// </summary>
        private short RegionID { get; set; }

        /// <summary>
        /// Location of spawn inside Region. Float coordinates.
        /// </summary>
        public PointF Location { get; set; }

        private Tab_RefNest TempNest;

        public ITeleport(SingleTeleport teleportData)
        {
            TeleportData = teleportData;
            if (TeleportData.IsNpcTeleport)
            {
                if (ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefTactics.Values.Any(tac => tac.dwObjID == TeleportData.ObjCommon.ID))
                {
                    var tacticsID = ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefTactics.Values.First(ta => ta.dwObjID == TeleportData.ObjCommon.ID);
                    if (ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest.Values.Any(nest => nest.dwTacticsID == tacticsID.dwTacticsID))
                    {
                        TempNest = ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest.Values.First(nest => nest.dwTacticsID == tacticsID.dwTacticsID);
                        RegionID = TempNest.nRegionDBID;
                        this.Location = new PointF(TempNest.fLocalPosX, TempNest.fLocalPosZ);
                    }
                }
            }
            else
            {
                RegionID = TeleportData.ObjCommon.RegionID;
                this.Location = new PointF(TeleportData.ObjCommon.OffsetX, TeleportData.ObjCommon.OffsetZ);
            }
            InitializeProperties();

        }

        /// <summary>
        /// Initialize required Properties to load Components with no error.
        /// </summary>
        void InitializeProperties()
        {
            if (RegionID == 0)
            {
                Y = 0; X = 0;
                return;
            }
            string convertedRegionID = RegionID.ToString("X");
            Y = Convert.ToByte(Convert.ToInt32(convertedRegionID.Substring(0, 2), 16));
            X = Convert.ToByte(Convert.ToInt32(convertedRegionID.Substring(2, 2), 16));
        }

    }
}

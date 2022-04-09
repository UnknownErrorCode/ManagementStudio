using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structs
{
    public struct SroPosition
    {
        public WRegionID wRegionID;
        public SVector3 fPosition;

        public SroPosition(WRegionID wRegionID, SVector3 fPosition)
        {
            this.wRegionID = wRegionID;
            this.fPosition = fPosition;
        }

        public SroPosition(short wRegionID, float fPositionX, float fPositionY, float fPositionZ)
        {
            this.wRegionID = new WRegionID(wRegionID);
            this.fPosition = new SVector3(fPositionX, fPositionY, fPositionZ);
        }
    }
}
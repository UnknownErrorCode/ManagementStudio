using System;

namespace Structs.Database
{
    public struct RefTeleport
    {
        // Private fields
        private int _service;
        private readonly int _id;
        private string _codeName128;
        private string _assocRefObjCodeName128;
        private int _assocRefObjID;
        private string _zoneName128;
        private short _genRegionID;
        private short _genPosX;
        private short _genPosY;
        private short _genPosZ;
        private short _genAreaRadius;
        private byte _canBeResurrectPos;
        private byte _canGotoResurrectPos;
        private short _genWorldID;
        private byte _bindInteractionMask;
        private byte _fixedService;

        // Public properties
        public int Service
        {
            get => _service;
            set => _service = value;
        }

        public int ID
        {
            get => _id;
        }

        public string CodeName128
        {
            get => _codeName128;
            set => _codeName128 = value;
        }

        public string AssocRefObjCodeName128
        {
            get => _assocRefObjCodeName128;
            set => _assocRefObjCodeName128 = value;
        }

        public int AssocRefObjID
        {
            get => _assocRefObjID;
            set => _assocRefObjID = value;
        }

        public string ZoneName128
        {
            get => _zoneName128;
            set => _zoneName128 = value;
        }

        public short GenRegionID
        {
            get => _genRegionID;
            set => _genRegionID = value;
        }

        public short GenPos_X
        {
            get => _genPosX;
            set => _genPosX = value;
        }

        public short GenPos_Y
        {
            get => _genPosY;
            set => _genPosY = value;
        }

        public short GenPos_Z
        {
            get => _genPosZ;
            set => _genPosZ = value;
        }

        public short GenAreaRadius
        {
            get => _genAreaRadius;
            set => _genAreaRadius = value;
        }

        public byte CanBeResurrectPos
        {
            get => _canBeResurrectPos;
            set => _canBeResurrectPos = value;
        }

        public byte CanGotoResurrectPos
        {
            get => _canGotoResurrectPos;
            set => _canGotoResurrectPos = value;
        }

        public short GenWorldID
        {
            get => _genWorldID;
            set => _genWorldID = value;
        }

        public byte BindInteractionMask
        {
            get => _bindInteractionMask;
            set => _bindInteractionMask = value;
        }

        public byte FixedService
        {
            get => _fixedService;
            set => _fixedService = value;
        }

        // Constructor to initialize the private fields
        public RefTeleport(object[] row)
        {
            _service = int.Parse(row[0].ToString());
            _id = int.Parse(row[1].ToString());
            _codeName128 = row[2].ToString();
            _assocRefObjCodeName128 = row[3].ToString();
            _assocRefObjID = int.Parse(row[4].ToString());
            _zoneName128 = row[5].ToString();
            _genRegionID = short.Parse(row[6].ToString());
            _genPosX = short.Parse(row[7].ToString());
            _genPosY = short.Parse(row[8].ToString());
            _genPosZ = short.Parse(row[9].ToString());
            _genAreaRadius = short.Parse(row[10].ToString());
            _canBeResurrectPos = byte.Parse(row[11].ToString());
            _canGotoResurrectPos = byte.Parse(row[12].ToString());
            _genWorldID = short.Parse(row[13].ToString());
            _bindInteractionMask = byte.Parse(row[14].ToString());
            _fixedService = byte.Parse(row[15].ToString());
        }
    }
}

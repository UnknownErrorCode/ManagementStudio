namespace Structs.Pk2.BinaryFiles.JMXRessource.Dungeon
{
    public struct DungeonRoomObjectExtraInformation
    {

        #region Fields
        public SVector3 Vector0;
        public SVector3 Vector1;
        private float unk_float0;
        private float unk_float1;
        private float unk_float2;
        private float unk_float3;
        private float unk_float4;
        private float unk_float5;
        private float unk_float6;

        #endregion Fields

        #region Properties

        public float[] Array { get => new float[7] { unk_float0, unk_float1, unk_float2, unk_float3, unk_float4, Unk_float5, unk_float6 }; }
        public float Unk_float0 { get => unk_float0; set => unk_float0 = value; }
        public float Unk_float1 { get => unk_float1; set => unk_float1 = value; }
        public float Unk_float2 { get => unk_float2; set => unk_float2 = value; }
        public float Unk_float3 { get => unk_float3; set => unk_float3 = value; }
        public float Unk_float4 { get => unk_float4; set => unk_float4 = value; }
        public float Unk_float5 { get => unk_float5; set => unk_float5 = value; }
        public float Unk_float6 { get => unk_float6; set => unk_float6 = value; }

        #endregion Properties

    }
}
namespace Structs.BinaryFiles.JMXInterface
{

    public struct JMX2dtFileStruct
    {

        public string Name { get; set; }
        public string Image { get; set; }
        public string Background { get; set; }
        public string Text { get; set; }                      //UI_STRING
        public string Description { get; set; }
        public string Prototype { get; set; }
        public uint Type { get; set; }
        public uint Id { get; set; }
        public uint ParentId { get; set; }
        public uint GrandParentId { get; set; }
        public uint Unk02 { get; set; }
        public uint Unk03 { get; set; }
        public uint Color { get; set; }
        public SRectangle ClientRectangle { get; set; }
        public float TopLeftX { get; set; }
        public float TopLeftY { get; set; }
        public float TopRightX { get; set; }
        public float TopRightY { get; set; }
        public float BottomRightX { get; set; }
        public float BottomRightY { get; set; }
        public float BottomLeftX { get; set; }
        public float BottomLeftY { get; set; }
        public uint Unk04 { get; set; }
        public uint ContentId { get; set; }
        public uint IsRoot { get; set; }
        public uint Unk07 { get; set; }
        public uint Unk08 { get; set; }
        public uint Unk09 { get; set; }
        public uint Unk10 { get; set; }
        public uint Unk11 { get; set; }
        public uint Unk12 { get; set; }
        public uint Unk13 { get; set; }
        public uint Unk14 { get; set; }
        public uint Unk15 { get; set; }

        public uint Unk16 { get; set; }
        public uint Unk17 { get; set; }
        public uint Unk18 { get; set; }
        public uint Unk19 { get; set; }
        public uint Style { get; set; }



        public float[] rect => new float[4] { ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Higth };
       
    }
}

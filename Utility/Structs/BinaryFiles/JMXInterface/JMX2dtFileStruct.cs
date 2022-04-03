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
        //placeholder (lorem ipsum)
        /*
         uint elementCount
foreach(element)
{how did you do that ?
64  string Name
256 string Image
256 string Background
128 string Text                      //UI_STRING
64  string Description
64  string Prototype                 //placeholder (lorem ipsum)
4   uint Type                      //NewInterfaceType
4   uint Id
4   uint ParentId
4   uint GrandParentId
4   uint Unk02
4   uint Unk03
4   uint Color                     //PixelFormat.RGBA_8888
4   uint ClientRectangle.X
4   uint ClientRectangle.Y
4   uint ClientRectangle.Width
4   uint ClientRectangle.Height
4   float TopLeft.X                 //UV mapping
4   float TopLeft.Y                 //UV mapping
4   float TopRight.X                //UV mapping
4   float TopRight.Y                //UV mapping
4   float BottomRight.X             //UV mapping
4   float BottomRight.Y             //UV mapping
4   float BottomLeft.X              //UV mapping
4   float BottomLeft.Y              //UV mapping
4   uint Unk04                     //CommandID?
4   uint ContentId                 //used on TabButton and is pointing to a Frame
4   uint IsRoot
4   uint Unk07
4   uint Unk08
4   uint Unk09
4   uint Unk10
4   uint Unk11
4   uint Unk12
4   uint Unk13
4   uint Unk14
4   uint Unk15
4   uint Unk16
4   uint Unk17
4   uint Unk18
4   uint Unk19
4   uint Style                     //NewInterfaceStyle
}
*/
    }
}

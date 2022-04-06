namespace Structs.BinaryFiles.JMXInterface
{
    public enum InterfaceStyle : uint
    {
        None = 0,
        FrameLRUD = 1,
        Image = 2,
        DDJFocusPress = 4,
        Background = 5,
        CheckBox = 11,
        CNIFVerticalSpinButtonCtrl = 18
    }

    public struct JMX2dtFileStruct
    {
        /// <summary>
        /// Interface Control Name
        /// </summary>
        public string Name { get; set; }

        public string Image { get; set; }

        /// <summary>
        /// frame_XXX.ddj or ddj image path
        /// </summary>
        public string Background { get; set; }

        /// <summary>
        /// UIIT String
        /// </summary>
        public string Text { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Placeholder lorem ipsum
        /// </summary>
        public string Prototype { get; set; }

        /// <summary>
        /// NewInterfaceType
        /// </summary>
        public uint Type { get; set; }

        /// <summary>
        /// ControlID
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Parent ControlID
        /// </summary>
        public uint ParentId { get; set; }

        public uint GrandParentId { get; set; }
        public uint Unk02 { get; set; }
        public uint Unk03 { get; set; }

        /// <summary>
        /// Color.FromAGB()
        /// </summary>
        public uint Color { get; set; }

        /// <summary>
        /// Size rectangle span
        /// </summary>
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

        /// <summary>
        /// New interface style
        /// </summary>
        public uint Style { get; set; }

        public float[] ClientRect => new float[4] { ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Higth };
    }
}
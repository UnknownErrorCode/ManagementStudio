using Structs.BinaryFiles.JMXInterface;
using System.IO;
using System.Text;

namespace BinaryFiles.PackFile.Media
{
    public class JMX2dtFile
    {
        public readonly bool Initialized = false;
        public JMX2dtFileStruct[] ElementList;
        private readonly uint elementCount;

        public JMX2dtFile(byte[] file)
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(new MemoryStream(file)))
                {
                    elementCount = reader.ReadUInt32();
                    ElementList = new JMX2dtFileStruct[(int)elementCount];
                    for (int i = 0; i < elementCount; i++)
                    {
                        var tempStruct = new JMX2dtFileStruct()
                        {
                            Name = Encoding.Default.GetString(reader.ReadBytes(64)),
                            Image = Encoding.Default.GetString(reader.ReadBytes(256)),
                            Background = Encoding.Default.GetString(reader.ReadBytes(256)),
                            Text = Encoding.Default.GetString(reader.ReadBytes(128)),
                            Description = Encoding.Default.GetString(reader.ReadBytes(64)),
                            Prototype = Encoding.Default.GetString(reader.ReadBytes(64)),
                            Type = reader.ReadUInt32(),
                            Id = reader.ReadUInt32(),
                            ParentId = reader.ReadUInt32(),
                            GrandParentId = reader.ReadUInt32(),
                            Unk02 = reader.ReadUInt32(),
                            Unk03 = reader.ReadUInt32(),
                            Color = reader.ReadUInt32(),//Color.FromArgb((int)reader.ReadUInt32()),
                            ClientRectangle = new Structs.SRectangle(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32()),

                            TopLeftX = reader.ReadSingle(),
                            TopLeftY = reader.ReadSingle(),
                            TopRightX = reader.ReadSingle(),
                            TopRightY = reader.ReadSingle(),
                            BottomRightX = reader.ReadSingle(),
                            BottomRightY = reader.ReadSingle(),
                            BottomLeftX = reader.ReadSingle(),
                            BottomLeftY = reader.ReadSingle(),

                            Unk04 = reader.ReadUInt32(),
                            ContentId = reader.ReadUInt32(),
                            IsRoot = reader.ReadUInt32(),
                            Unk07 = reader.ReadUInt32(),
                            Unk08 = reader.ReadUInt32(),
                            Unk09 = reader.ReadUInt32(),
                            Unk10 = reader.ReadUInt32(),
                            Unk11 = reader.ReadUInt32(),
                            Unk12 = reader.ReadUInt32(),
                            Unk13 = reader.ReadUInt32(),
                            Unk14 = reader.ReadUInt32(),
                            Unk15 = reader.ReadUInt32(),
                            Unk16 = reader.ReadUInt32(),
                            Unk17 = reader.ReadUInt32(),
                            Unk18 = reader.ReadUInt32(),
                            Unk19 = reader.ReadUInt32(),

                            Style = reader.ReadUInt32()
                        };

                        ElementList[i] = (tempStruct);
                    }
                }
                Initialized = true;
            }
            catch (System.Exception)
            {
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Client.Files
{

    internal enum PixelFormat
    {
        ARGB,
        RGB,
        DXT1,
        DXT2,
        DXT3,
        DXT4,
        DTX5,
        THREEDC,
        ATI1N,
        LUMINANCE,
        LUMINANCE_ALPHA,
        RXGB,
        A16B16G16R16,
        R16F,
        G16R16F,
        A16B16G16R16F,
        R32F,
        G32R32F,
        A32B32G32R32F,
        UNKNOWN,
    }
    public class DDSImage
    {
        private static byte[] DDS_HEADER = Convert.FromBase64String("RERTIA==");
        public const string SUPPORTED_ENCODERS = "DXT1 DXT3";
        private const uint FOURCC_DXT1 = 827611204;
        private const uint FOURCC_DXT2 = 844388420;
        private const uint FOURCC_DXT3 = 861165636;
        private const uint FOURCC_DXT4 = 877942852;
        private const uint FOURCC_DXT5 = 894720068;
        private const uint FOURCC_ATI1 = 826889281;
        private const uint FOURCC_ATI2 = 843666497;
        private const uint FOURCC_RXGB = 1111971922;
        private const uint FOURCC_DOLLARNULL = 36;
        private const uint FOURCC_oNULL = 111;
        private const uint FOURCC_pNULL = 112;
        private const uint FOURCC_qNULL = 113;
        private const uint FOURCC_rNULL = 114;
        private const uint FOURCC_sNULL = 115;
        private const uint FOURCC_tNULL = 116;
        private const uint DDS_LINEARSIZE = 524288;
        private const uint DDS_PITCH = 8;
        private const uint DDS_FOURCC = 4;
        private const uint DDS_LUMINANCE = 131072;
        private const uint DDS_ALPHAPIXELS = 1;
        private byte[] signature;
        private uint size1;
        private uint flags1;
        private uint height;
        private uint width;
        private uint linearsize;
        private uint depth;
        private uint mipmapcount;
        private uint alphabitdepth;
        private uint size2;
        private uint flags2;
        private uint fourcc;
        private uint rgbbitcount;
        private uint rbitmask;
        private uint bbitmask;
        private uint gbitmask;
        private uint alphabitmask;
        private uint ddscaps1;
        private uint ddscaps2;
        private uint ddscaps3;
        private uint ddscaps4;
        private uint texturestage;
        private PixelFormat CompFormat;
        private uint blocksize;
        private uint bpp;
        private uint bps;
        private uint sizeofplane;
        private uint compsize;
        private byte[] compdata;
        private byte[] rawidata;
        private BinaryReader br;
        private Bitmap img;

        public Bitmap BitmapImage
        {
            get
            {
                return this.img;
            }
        }

        public unsafe DDSImage(byte[] ddsimage, bool ddj)
        {
            MemoryStream memoryStream = new MemoryStream(ddj ? ddsimage.Length - 20 : ddsimage.Length);
            memoryStream.Write(ddj ? ddsimage.Skip(20).ToArray():ddsimage, 0, ddj ? ddsimage.Length-20: ddsimage.Length);
            memoryStream.Seek(0L, SeekOrigin.Begin);
            this.br = new BinaryReader((Stream)memoryStream);
            this.signature = this.br.ReadBytes(4);
            if (!DDSImage.IsByteArrayEqual(this.signature, DDSImage.DDS_HEADER))
                Console.WriteLine("Got header of '" + Encoding.ASCII.GetString(this.signature, 0, this.signature.Length) + "'.");
            this.size1 = this.br.ReadUInt32();
            this.flags1 = this.br.ReadUInt32();
            this.height = this.br.ReadUInt32();
            this.width = this.br.ReadUInt32();
            this.linearsize = this.br.ReadUInt32();
            this.depth = this.br.ReadUInt32();
            this.mipmapcount = this.br.ReadUInt32();
            this.alphabitdepth = this.br.ReadUInt32();
            for (int index = 0; index < 10; ++index)
            {
                int num = (int)this.br.ReadUInt32();
            }
            this.size2 = this.br.ReadUInt32();
            this.flags2 = this.br.ReadUInt32();
            this.fourcc = this.br.ReadUInt32();
            this.rgbbitcount = this.br.ReadUInt32();
            this.rbitmask = this.br.ReadUInt32();
            this.gbitmask = this.br.ReadUInt32();
            this.bbitmask = this.br.ReadUInt32();
            this.alphabitmask = this.br.ReadUInt32();
            this.ddscaps1 = this.br.ReadUInt32();
            this.ddscaps2 = this.br.ReadUInt32();
            this.ddscaps3 = this.br.ReadUInt32();
            this.ddscaps4 = this.br.ReadUInt32();
            this.texturestage = this.br.ReadUInt32();
            if (this.depth == 0U)
                this.depth = 1U;
            if ((this.flags2 & 4U) > 0U)
            {
                this.blocksize = (this.width + 3U) / 4U * ((this.height + 3U) / 4U) * this.depth;
                switch (this.fourcc)
                {
                    case 36:
                        this.CompFormat = PixelFormat.A16B16G16R16;
                        this.blocksize = (uint)((int)this.width * (int)this.height * (int)this.depth * 8);
                        break;
                    case 111:
                        this.CompFormat = PixelFormat.R16F;
                        this.blocksize = (uint)((int)this.width * (int)this.height * (int)this.depth * 2);
                        break;
                    case 112:
                        this.CompFormat = PixelFormat.G16R16F;
                        this.blocksize = (uint)((int)this.width * (int)this.height * (int)this.depth * 4);
                        break;
                    case 113:
                        this.CompFormat = PixelFormat.A16B16G16R16F;
                        this.blocksize = (uint)((int)this.width * (int)this.height * (int)this.depth * 8);
                        break;
                    case 114:
                        this.CompFormat = PixelFormat.R32F;
                        this.blocksize = (uint)((int)this.width * (int)this.height * (int)this.depth * 4);
                        break;
                    case 115:
                        this.CompFormat = PixelFormat.G32R32F;
                        this.blocksize = (uint)((int)this.width * (int)this.height * (int)this.depth * 8);
                        break;
                    case 116:
                        this.CompFormat = PixelFormat.A32B32G32R32F;
                        this.blocksize = (uint)((int)this.width * (int)this.height * (int)this.depth * 16);
                        break;
                    case 826889281:
                        this.CompFormat = PixelFormat.ATI1N;
                        this.blocksize *= 8U;
                        break;
                    case 827611204:
                        this.CompFormat = PixelFormat.DXT1;
                        this.blocksize *= 8U;
                        break;
                    case 843666497:
                        this.CompFormat = PixelFormat.THREEDC;
                        this.blocksize *= 16U;
                        break;
                    case 844388420:
                        this.CompFormat = PixelFormat.DXT2;
                        this.blocksize *= 16U;
                        break;
                    case 861165636:
                        this.CompFormat = PixelFormat.DXT3;
                        this.blocksize *= 16U;
                        break;
                    case 877942852:
                        this.CompFormat = PixelFormat.DXT4;
                        this.blocksize *= 16U;
                        break;
                    case 894720068:
                        this.CompFormat = PixelFormat.DTX5;
                        this.blocksize *= 16U;
                        break;
                    case 1111971922:
                        this.CompFormat = PixelFormat.RXGB;
                        this.blocksize *= 16U;
                        break;
                    default:
                        this.CompFormat = PixelFormat.UNKNOWN;
                        this.blocksize *= 16U;
                        break;
                }
            }
            else
            {
                this.CompFormat = (this.flags2 & 131072U) <= 0U ? ((this.flags2 & 1U) <= 0U ? PixelFormat.RGB : PixelFormat.ARGB) : ((this.flags2 & 1U) <= 0U ? PixelFormat.LUMINANCE : PixelFormat.LUMINANCE_ALPHA);
                this.blocksize = this.width * this.height * this.depth * (this.rgbbitcount >> 3);
            }
            int compFormat = (int)this.CompFormat;
            if (((int)this.flags1 & 524296) == 0 || this.linearsize == 0U)
            {
                this.flags1 |= 524288U;
                this.linearsize = this.blocksize;
            }
            this.ReadData();
            this.bpp = this.PixelFormatToBpp(this.CompFormat);
            this.bps = this.width * this.bpp * this.PixelFormatToBpc(this.CompFormat);
            this.sizeofplane = this.bps * this.height;
            this.rawidata = new byte[(uint)((int)this.depth * (int)this.sizeofplane + (int)this.height * (int)this.bps + (int)this.width * (int)this.bpp)];
            switch (this.CompFormat)
            {
                case PixelFormat.ARGB:
                case PixelFormat.RGB:
                case PixelFormat.LUMINANCE:
                case PixelFormat.LUMINANCE_ALPHA:
                    this.DecompressARGB();
                    break;
                case PixelFormat.DXT1:
                    this.DecompressDXT1();
                    break;
                case PixelFormat.DXT3:
                    this.DecompressDXT3();
                    break;
            }
            this.img = new Bitmap((int)this.width, (int)this.height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            System.Drawing.Imaging.BitmapData bitmapdata = this.img.LockBits(new Rectangle(0, 0, this.img.Width, this.img.Height), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            IntPtr scan0 = bitmapdata.Scan0;
            int num1 = this.img.Width * this.img.Height * 4;
            byte* numPtr = (byte*)(void*)scan0;
            for (int index = 0; index < num1; index += 4)
            {
                numPtr[index] = this.rawidata[index + 2];
                numPtr[index + 1] = this.rawidata[index + 1];
                numPtr[index + 2] = this.rawidata[index];
                numPtr[index + 3] = this.rawidata[index + 3];
            }
            this.img.UnlockBits(bitmapdata);
            this.rawidata = (byte[])null;
            this.compdata = (byte[])null;
        }

        private static bool IsByteArrayEqual(byte[] arg0, byte[] arg1)
        {
            if (arg0.Length != arg1.Length)
                return false;
            for (int index = 0; index < arg0.Length; ++index)
            {
                if ((int)arg0[index] != (int)arg1[index])
                    return false;
            }
            return true;
        }

        private uint PixelFormatToBpp(PixelFormat pf)
        {
            switch (pf)
            {
                case PixelFormat.ARGB:
                case PixelFormat.LUMINANCE:
                case PixelFormat.LUMINANCE_ALPHA:
                    return this.rgbbitcount / 8U;
                case PixelFormat.RGB:
                case PixelFormat.THREEDC:
                case PixelFormat.RXGB:
                    return 3;
                case PixelFormat.ATI1N:
                    return 1;
                case PixelFormat.A16B16G16R16:
                case PixelFormat.A16B16G16R16F:
                case PixelFormat.G32R32F:
                    return 8;
                case PixelFormat.R16F:
                    return 2;
                case PixelFormat.A32B32G32R32F:
                    return 16;
                default:
                    return 4;
            }
        }

        private uint PixelFormatToBpc(PixelFormat pf)
        {
            switch (pf)
            {
                case PixelFormat.A16B16G16R16:
                    return 2;
                case PixelFormat.R16F:
                case PixelFormat.G16R16F:
                case PixelFormat.A16B16G16R16F:
                    return 4;
                case PixelFormat.R32F:
                case PixelFormat.G32R32F:
                case PixelFormat.A32B32G32R32F:
                    return 4;
                default:
                    return 1;
            }
        }

        private uint PixelFormatToChannelCount(PixelFormat pf)
        {
            switch (pf)
            {
                case PixelFormat.RGB:
                case PixelFormat.THREEDC:
                case PixelFormat.RXGB:
                    return 3;
                case PixelFormat.ATI1N:
                case PixelFormat.LUMINANCE:
                case PixelFormat.R16F:
                case PixelFormat.R32F:
                    return 1;
                case PixelFormat.LUMINANCE_ALPHA:
                case PixelFormat.G16R16F:
                case PixelFormat.G32R32F:
                    return 2;
                default:
                    return 4;
            }
        }

        private void ReadData()
        {
            this.compdata = (byte[])null;
            if ((this.flags1 & 524288U) > 1U)
            {
                this.compdata = this.br.ReadBytes((int)this.linearsize);
                this.compsize = (uint)this.compdata.Length;
            }
            else
            {
                this.compsize = this.width * this.rgbbitcount / 8U * this.height * this.depth;
                this.compdata = new byte[this.compsize];
                MemoryStream memoryStream = new MemoryStream((int)this.compsize);
                for (int index1 = 0; (long)index1 < (long)this.depth; ++index1)
                {
                    for (int index2 = 0; (long)index2 < (long)this.height; ++index2)
                    {
                        byte[] buffer = this.br.ReadBytes((int)this.bps);
                        memoryStream.Write(buffer, 0, buffer.Length);
                    }
                }
                memoryStream.Seek(0L, SeekOrigin.Begin);
                memoryStream.Read(this.compdata, 0, this.compdata.Length);
                memoryStream.Close();
            }
        }

        private void DecompressARGB()
        {
            DecompressDXT3();
        }

        private void DecompressDXT1()
        {
            DDSImage.Colour8888[] colour8888Array = new DDSImage.Colour8888[4];
            MemoryStream memoryStream = new MemoryStream(this.compdata.Length);
            memoryStream.Write(this.compdata, 0, this.compdata.Length);
            memoryStream.Seek(0L, SeekOrigin.Begin);
            BinaryReader binaryReader = new BinaryReader((Stream)memoryStream);
            colour8888Array[0].a = byte.MaxValue;
            colour8888Array[1].a = byte.MaxValue;
            colour8888Array[2].a = byte.MaxValue;
            for (int index1 = 0; (long)index1 < (long)this.depth; ++index1)
            {
                for (int index2 = 0; (long)index2 < (long)this.height; index2 += 4)
                {
                    for (int index3 = 0; (long)index3 < (long)this.width; index3 += 4)
                    {
                        ushort Data1 = binaryReader.ReadUInt16();
                        ushort Data2 = binaryReader.ReadUInt16();
                        this.ReadColour(Data1, ref colour8888Array[0]);
                        this.ReadColour(Data2, ref colour8888Array[1]);
                        uint num1 = binaryReader.ReadUInt32();
                        if ((int)Data1 > (int)Data2)
                        {
                            colour8888Array[2].b = (byte)((2 * (int)colour8888Array[0].b + (int)colour8888Array[1].b + 1) / 3);
                            colour8888Array[2].g = (byte)((2 * (int)colour8888Array[0].g + (int)colour8888Array[1].g + 1) / 3);
                            colour8888Array[2].r = (byte)((2 * (int)colour8888Array[0].r + (int)colour8888Array[1].r + 1) / 3);
                            colour8888Array[3].b = (byte)(((int)colour8888Array[0].b + 2 * (int)colour8888Array[1].b + 1) / 3);
                            colour8888Array[3].g = (byte)(((int)colour8888Array[0].g + 2 * (int)colour8888Array[1].g + 1) / 3);
                            colour8888Array[3].r = (byte)(((int)colour8888Array[0].r + 2 * (int)colour8888Array[1].r + 1) / 3);
                            colour8888Array[3].a = byte.MaxValue;
                        }
                        else
                        {
                            colour8888Array[2].b = (byte)(((int)colour8888Array[0].b + (int)colour8888Array[1].b) / 2);
                            colour8888Array[2].g = (byte)(((int)colour8888Array[0].g + (int)colour8888Array[1].g) / 2);
                            colour8888Array[2].r = (byte)(((int)colour8888Array[0].r + (int)colour8888Array[1].r) / 2);
                            colour8888Array[3].b = (byte)0;
                            colour8888Array[3].g = (byte)0;
                            colour8888Array[3].r = (byte)0;
                            colour8888Array[3].a = (byte)0;
                        }
                        int num2 = 0;
                        int num3 = 0;
                        for (; num2 < 4; ++num2)
                        {
                            int num4 = 0;
                            while (num4 < 4)
                            {
                                int index4 = (int)(((long)num1 & (long)(3 << num3 * 2)) >> num3 * 2);
                                if ((long)(index3 + num4) < (long)this.width && (long)(index2 + num2) < (long)this.height)
                                {
                                    uint num5 = (uint)((long)index1 * (long)this.sizeofplane + (long)(index2 + num2) * (long)this.bps + (long)(index3 + num4) * (long)this.bpp);
                                    this.rawidata[num5] = colour8888Array[index4].r;
                                    this.rawidata[(num5 + 1U)] = colour8888Array[index4].g;
                                    this.rawidata[(num5 + 2U)] = colour8888Array[index4].b;
                                    this.rawidata[(num5 + 3U)] = colour8888Array[index4].a;
                                }
                                ++num4;
                                ++num3;
                            }
                        }
                    }
                }
            }
        }

        private void DecompressDXT3()
        {
            DDSImage.Colour8888[] colour8888Array = new DDSImage.Colour8888[4];
            MemoryStream memoryStream = new MemoryStream(this.compdata.Length);
            memoryStream.Write(this.compdata, 0, this.compdata.Length);
            memoryStream.Seek(0L, SeekOrigin.Begin);
            BinaryReader binaryReader = new BinaryReader((Stream)memoryStream);
            for (int index1 = 0; (long)index1 < (long)this.depth; ++index1)
            {
                for (int index2 = 0; (long)index2 < (long)this.height; index2 += 4)
                {
                    for (int index3 = 0; (long)index3 < (long)this.width; index3 += 4)
                    {
                        byte[] numArray = binaryReader.ReadBytes(8);
                        ushort Data1 = binaryReader.ReadUInt16();
                        ushort Data2 = binaryReader.ReadUInt16();
                        this.ReadColour(Data1, ref colour8888Array[0]);
                        this.ReadColour(Data2, ref colour8888Array[1]);
                        uint num1 = binaryReader.ReadUInt32();
                        colour8888Array[2].b = (byte)((2 * (int)colour8888Array[0].b + (int)colour8888Array[1].b + 1) / 3);
                        colour8888Array[2].g = (byte)((2 * (int)colour8888Array[0].g + (int)colour8888Array[1].g + 1) / 3);
                        colour8888Array[2].r = (byte)((2 * (int)colour8888Array[0].r + (int)colour8888Array[1].r + 1) / 3);
                        colour8888Array[3].b = (byte)(((int)colour8888Array[0].b + 2 * (int)colour8888Array[1].b + 1) / 3);
                        colour8888Array[3].g = (byte)(((int)colour8888Array[0].g + 2 * (int)colour8888Array[1].g + 1) / 3);
                        colour8888Array[3].r = (byte)(((int)colour8888Array[0].r + 2 * (int)colour8888Array[1].r + 1) / 3);
                        int num2 = 0;
                        int num3 = 0;
                        for (; num2 < 4; ++num2)
                        {
                            for (int index4 = 0; index4 < 4; ++index4)
                            {
                                int index5 = (int)(((long)num1 & (long)(3 << num3 * 2)) >> num3 * 2);
                                if ((long)(index3 + index4) < (long)this.width && (long)(index2 + num2) < (long)this.height)
                                {
                                    uint num4 = (uint)((long)index1 * (long)this.sizeofplane + (long)(index2 + num2) * (long)this.bps + (long)(index3 + index4) * (long)this.bpp);
                                    this.rawidata[num4] = colour8888Array[index5].r;
                                    this.rawidata[num4 + 1U] = colour8888Array[index5].g;
                                    this.rawidata[num4 + 2U] = colour8888Array[index5].b;
                                }
                                ++num3;
                            }
                        }
                        for (int index4 = 0; index4 < 4; ++index4)
                        {
                            ushort num4 = (ushort)((uint)numArray[2 * index4] + 256U * (uint)numArray[2 * index4 + 1]);
                            for (int index5 = 0; index5 < 4; ++index5)
                            {
                                if ((long)(index3 + index5) < (long)this.width && (long)(index2 + index4) < (long)this.height)
                                {
                                    uint num5 = (uint)((ulong)((long)index1 * (long)this.sizeofplane + (long)(index2 + index4) * (long)this.bps + (long)(index3 + index5) * (long)this.bpp) + 3UL);
                                    this.rawidata[num5] = (byte)((uint)num4 & 15U);
                                    this.rawidata[num5] = (byte)(this.rawidata[num5] | this.rawidata[num5] << 4);
                                }
                                num4 >>= 4;
                            }
                        }
                    }
                }
            }
        }

        private void ReadColour(ushort Data, ref DDSImage.Colour8888 op)
        {
            byte num1 = (byte)((uint)Data & 31U);
            byte num2 = (byte)(((int)Data & 2016) >> 5);
            byte num3 = (byte)(((int)Data & 63488) >> 11);
            op.r = (byte)((int)num3 * (int)byte.MaxValue / 31);
            op.g = (byte)((int)num2 * (int)byte.MaxValue / 63);
            op.b = (byte)((int)num1 * (int)byte.MaxValue / 31);
        }

        private struct Colour8888
        {
            public byte r;
            public byte g;
            public byte b;
            public byte a;
        }
    }
}

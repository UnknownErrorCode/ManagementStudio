using ClientDataStorage.Client;
using ClientDataStorage.Client.Files;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.OldMapGL
{
    internal class Terrain
    {
        private string pathPrefix = $"Map\\tile2d\\";
        private float[][][] Heights = new float[36][][];
        private int[][][] Tex = new int[36][][];
        private List<int> FileTexIDs = new List<int>();
        private int[] TexIDs;
        private string[] TexPaths;

        public Terrain(string path)
        {
            this.getTexPaths();
            BinaryReader binaryReader = new BinaryReader((Stream)File.Open(path, FileMode.Open));
            binaryReader.BaseStream.Position = 12L;
            for (int index1 = 0; index1 < 36; ++index1)
            {
                this.Heights[index1] = new float[17][];
                this.Tex[index1] = new int[17][];
                binaryReader.BaseStream.Position += 6L;
                for (int index2 = 0; index2 < 17; ++index2)
                {
                    this.Heights[index1][index2] = new float[17];
                    this.Tex[index1][index2] = new int[17];
                }
                for (int index2 = 0; index2 < 17; ++index2)
                {
                    for (int index3 = 0; index3 < 17; ++index3)
                    {
                        this.Heights[index1][index3][index2] = binaryReader.ReadSingle();
                        this.Tex[index1][index3][index2] = (int)binaryReader.ReadByte();
                        binaryReader.BaseStream.Position += 2L;
                    }
                }
                binaryReader.BaseStream.Position += 546L;
            }
            binaryReader.Close();
            binaryReader.Dispose();
            this.getTex();
        }

        private void getTex()
        {
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            for (int blocks = 0; blocks < 36; ++blocks)
            {
                for (int cellX = 0; cellX < 17; ++cellX)
                {
                    for (int cellY = 0; cellY < 17; ++cellY)
                    {
                        if (!intList1.Contains(this.Tex[blocks][cellX][cellY]))
                        {
                            intList1.Add(this.Tex[blocks][cellX][cellY]);
                            int texture = GL.GenTexture();
                            GL.BindTexture(TextureTarget.Texture2D, texture);
                            string path = this.pathPrefix + this.TexPaths[this.Tex[blocks][cellX][cellY]];
                            byte[] numArray = new byte[0];

                            System.Drawing.Bitmap bitmapImage = Map.TileTextureDictionary[this.Tex[blocks][cellX][cellY]].BitmapImage;
                            BitmapData bitmapdata = bitmapImage.LockBits(new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapdata.Width, bitmapdata.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapdata.Scan0);
                            bitmapImage.UnlockBits(bitmapdata);
                            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                            this.FileTexIDs.Add(this.Tex[blocks][cellX][cellY]);
                            intList2.Add(texture);
                        }
                    }
                }
            }
            this.TexIDs = intList2.ToArray();
            intList2.Clear();
        }

        public void Draw()
        {
            GL.Color3(byte.MaxValue, byte.MaxValue, byte.MaxValue);
            for (int index1 = 0; index1 < 36; ++index1)
            {
                for (int index2 = 0; index2 < 16; ++index2)
                {
                    for (int index3 = 0; index3 < 16; ++index3)
                    {
                        GL.Enable(EnableCap.Texture2D);
                        GL.BindTexture(TextureTarget.Texture2D, this.TexIDs[this.FileTexIDs.IndexOf(this.Tex[index1][index2][index3])]);
                        GL.Begin(BeginMode.TriangleStrip);
                        GL.TexCoord2((float)index2 / 2f, (float)index3 / 2f);
                        GL.Vertex3((double)(index2 * 20 + index1 % 6 * 320), (double)(index3 * 20) + Math.Floor((double)index1 / 6.0) * 320.0, (double)this.Heights[index1][index2][index3]);
                        GL.TexCoord2((float)(index2 + 1) / 2f, (float)index3 / 2f);
                        GL.Vertex3((double)((index2 + 1) * 20 + index1 % 6 * 320), (double)(index3 * 20) + Math.Floor((double)index1 / 6.0) * 320.0, (double)this.Heights[index1][index2 + 1][index3]);
                        GL.TexCoord2((float)index2 / 2f, (float)(index3 + 1) / 2f);
                        GL.Vertex3((double)(index2 * 20 + index1 % 6 * 320), (double)((index3 + 1) * 20) + Math.Floor((double)index1 / 6.0) * 320.0, (double)this.Heights[index1][index2][index3 + 1]);
                        GL.TexCoord2((float)(index2 + 1) / 2f, (float)(index3 + 1) / 2f);
                        GL.Vertex3((double)((index2 + 1) * 20 + index1 % 6 * 320), (double)((index3 + 1) * 20) + Math.Floor((double)index1 / 6.0) * 320.0, (double)this.Heights[index1][index2 + 1][index3 + 1]);
                        GL.End();
                        GL.Disable(EnableCap.Texture2D);
                    }
                }
            }
        }

        private void getTexPaths()
        {
            this.TexPaths = ClientDataStorage.Client.Map.Tile2d_ifo.TexturePaths;
        }
    }
}

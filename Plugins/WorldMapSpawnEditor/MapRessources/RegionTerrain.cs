using ClientDataStorage.Client;
using ClientDataStorage.Client.Files;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMapSpawnEditor.MapRessources
{
    class RegionTerrain
    {
        public mFile MFile;
        Dictionary<int, int> vSroTextureOpenTKTexture = new Dictionary<int, int>();
        private protected readonly string pathPrefix = $"Map\\tile2d\\";
       

        /// <summary>
        /// Converts a  .m file into a OpenTK Terrain
        /// </summary>
        /// <param name="file">.m file from Map.pk2</param>
        public RegionTerrain(mFile file)
        {
            MFile = file;
            
            this.GetTextures();
        }

        /// <summary>
        /// Loads required texture files as ddj format to ClientDataStore.Client.Map
        /// </summary>
        public void GetTextures()
        {
            var blocks = 0;
            for (int blockx = 0; blockx < 6; ++blockx)
            {
                for (int blocky = 0; blocky < 6; blocky++)
                {
                    for (int cellX = 0; cellX < 17; ++cellX)
                    {
                        for (int cellY = 0; cellY < 17; ++cellY)
                        {
                            if (!vSroTextureOpenTKTexture.ContainsKey(MFile.Blocks[new Point(blockx, blocky)].MapCells[new Point(cellY, cellX)].texture))
                            {
                                int OpenTKTextureID = GL.GenTexture();
                                GL.BindTexture(TextureTarget.Texture2D, OpenTKTextureID);

                               // var textureID = this.Tex[blocks][cellX][cellY];
                                var textureID2 = MFile.Blocks[new Point(blockx, blocky)].MapCells[new Point(cellY, cellX)].texture;

                                if (!Map.TileTextureDictionary.ContainsKey(textureID2))
                                    if (Map.MapPk2.GetByteArrayByDirectory($"Map\\tile2d\\{Map.Tile2d_ifo.TexturePaths[textureID2]}", out byte[] filebytearray))
                                        Map.TileTextureDictionary.Add(textureID2, new DDSImage(filebytearray, true));

                                System.Drawing.Bitmap bitmapImage = Map.TileTextureDictionary[textureID2].BitmapImage;
                                BitmapData bitmapdata = bitmapImage.LockBits(new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapdata.Width, bitmapdata.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapdata.Scan0);
                                bitmapImage.UnlockBits(bitmapdata);
                                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                                vSroTextureOpenTKTexture.Add(textureID2, OpenTKTextureID);
                            }
                        }
                    }
                    blocks++;
                }
            }
        }

        public void DrawTerrain(bool newload)
        {

            var index1 = 0;
            for (int blockX = 0; blockX < 6; blockX++)
            {
                for (int blockY = 0; blockY < 6; blockY++)
                {
                    var blockPoint = new Point(blockX, blockY);
                    for (int cellx = 0; cellx < 16; ++cellx)
                    {
                        for (int celly = 0; celly < 16; ++celly)
                        {
                            var meshCell = MFile.Blocks[blockPoint].MapCells[new Point(celly, cellx)];
                            var OpenTKTextureID = vSroTextureOpenTKTexture[meshCell.texture];

                            GL.Enable(EnableCap.Texture2D);
                            GL.BindTexture(TextureTarget.Texture2D, OpenTKTextureID);
                            GL.Begin(PrimitiveType.TriangleStrip);

                            var x1 = (double)(cellx * 20 + (index1 % 6) * 320);
                            var x2 = (double)((cellx + 1) * 20 + (index1 % 6) * 320);
                            var x3 = (double)(cellx * 20 + (index1 % 6) * 320);
                            var x4 = (double)((cellx + 1) * 20 + (index1 % 6) * 320);

                            var y1 = (double)(celly * 20 + Math.Floor((double)index1 / 6.0) * 320.0);
                            var y2 = (double)(celly * 20 + Math.Floor((double)index1 / 6.0) * 320.0);
                            var y3 = (double)((celly + 1) * 20 + Math.Floor((double)index1 / 6.0) * 320.0);
                            var y4 = (double)((celly + 1) * 20 + Math.Floor((double)index1 / 6.0) * 320.0);

                            var Nx1 = (double)(cellx * 20 + (index1 % 6) * 320);// + (MFile.X*1920);
                            var Nx2 = (double)((cellx + 1) * 20 + (index1 % 6) * 320);//+ (MFile.X * 1920);
                            var Nx3 = (double)(cellx * 20 + (index1 % 6) * 320);// + (MFile.X * 1920);
                            var Nx4 = (double)((cellx + 1) * 20 + (index1 % 6) * 320);// + (MFile.X * 1920);

                            var ny1 = (double)(celly * 20 + Math.Floor((double)index1 / 6.0) * 320.0);// + (MFile.Y * 1920);
                            var ny2 = (double)(celly * 20 + Math.Floor((double)index1 / 6.0) * 320.0);// + (MFile.Y * 1920);
                            var ny3 = (double)((celly + 1) * 20 + Math.Floor((double)index1 / 6.0) * 320.0);// + (MFile.Y * 1920);
                            var ny4 = (double)((celly + 1) * 20 + Math.Floor((double)index1 / 6.0) * 320.0);// + (MFile.Y * 1920);


                            GL.TexCoord2((float)cellx / 2f, (float)celly / 2f);
                            // GL.Vertex3((double)(cellx * 20 + (index1 % 6) * 320), (double)((celly * 20) + Math.Floor((double)index1 / 6.0) * 320.0) , (double)meshCell.Height);
                            GL.Vertex3(Nx1, ny1, (double)meshCell.Height);

                            GL.TexCoord2((float)(cellx + 1) / 2f, (float)celly / 2f);
                            // GL.Vertex3((double)((cellx + 1) * 20 + index1 % 6 * 320), (double)((celly * 20) + Math.Floor((double)index1 / 6.0) * 320.0) , (double)MFile.Blocks[blockPoint].MapCells[new Point(celly, cellx + 1)].Height);
                            GL.Vertex3(Nx2, ny2, (double)MFile.Blocks[blockPoint].MapCells[new Point(celly, cellx + 1)].Height);

                            GL.TexCoord2((float)cellx / 2f, (float)(celly + 1) / 2f);
                            //GL.Vertex3((double)(cellx * 20 + index1 % 6 * 320), (double)(((celly + 1) * 20) + Math.Floor((double)index1 / 6.0) * 320.0) , (double)MFile.Blocks[blockPoint].MapCells[new Point(celly + 1, cellx)].Height);
                            GL.Vertex3(Nx3, ny3, (double)MFile.Blocks[blockPoint].MapCells[new Point(celly + 1, cellx)].Height);

                            GL.TexCoord2((float)(cellx + 1) / 2f, (float)(celly + 1) / 2f);
                            GL.Vertex3(Nx4, ny4, (double)MFile.Blocks[blockPoint].MapCells[new Point(celly + 1, cellx + 1)].Height);
                            //GL.Vertex3((double)((cellx + 1) * 20 + index1 % 6 * 320), (double)(((celly + 1) * 20) + Math.Floor((double)index1 / 6.0) * 320.0) , (double)MFile.Blocks[blockPoint].MapCells[new Point(celly + 1, cellx + 1)].Height);

                            GL.End();
                            GL.Disable(EnableCap.Texture2D);
                        }
                    }
                    index1++;
                }
            }
        }

        public void DrawTerrain(bool newload, Point point)
        {

            var index1 = 0;
            for (int blockX = 0; blockX < 6; blockX++)
            {
                for (int blockY = 0; blockY < 6; blockY++)
                {
                    var blockPoint = new Point(blockX, blockY);
                    for (int cellx = 0; cellx < 16; ++cellx)
                    {
                        for (int celly = 0; celly < 16; ++celly)
                        {
                            var meshCell = MFile.Blocks[blockPoint].MapCells[new Point(celly, cellx)];
                            var OpenTKTextureID = vSroTextureOpenTKTexture[meshCell.texture];

                            GL.Enable(EnableCap.Texture2D);
                            GL.BindTexture(TextureTarget.Texture2D, OpenTKTextureID);
                            GL.Begin(PrimitiveType.TriangleStrip);

                            var Nx1 = (double)(cellx * 20 + (index1 % 6) * 320) + (point.X * 1920);
                            var Nx2 = (double)((cellx + 1) * 20 + (index1 % 6) * 320)+ (point.X * 1920);
                            var Nx3 = (double)(cellx * 20 + (index1 % 6) * 320)+ (point.X * 1920);
                            var Nx4 = (double)((cellx + 1) * 20 + (index1 % 6) * 320) + (point.X * 1920);

                            var ny1 = (double)(celly * 20 + Math.Floor((double)index1 / 6.0) * 320.0)+ (point.Y * 1920);
                            var ny2 = (double)(celly * 20 + Math.Floor((double)index1 / 6.0) * 320.0) + (point.Y * 1920);
                            var ny3 = (double)((celly + 1) * 20 + Math.Floor((double)index1 / 6.0) * 320.0) + (point.Y * 1920);
                            var ny4 = (double)((celly + 1) * 20 + Math.Floor((double)index1 / 6.0) * 320.0) + (point.Y * 1920);


                            GL.TexCoord2((float)cellx / 2f, (float)celly / 2f);
                            // GL.Vertex3((double)(cellx * 20 + (index1 % 6) * 320), (double)((celly * 20) + Math.Floor((double)index1 / 6.0) * 320.0) , (double)meshCell.Height);
                            GL.Vertex3(Nx1, ny1, (double)meshCell.Height);

                            GL.TexCoord2((float)(cellx + 1) / 2f, (float)celly / 2f);
                            // GL.Vertex3((double)((cellx + 1) * 20 + index1 % 6 * 320), (double)((celly * 20) + Math.Floor((double)index1 / 6.0) * 320.0) , (double)MFile.Blocks[blockPoint].MapCells[new Point(celly, cellx + 1)].Height);
                            GL.Vertex3(Nx2, ny2, (double)MFile.Blocks[blockPoint].MapCells[new Point(celly, cellx + 1)].Height);

                            GL.TexCoord2((float)cellx / 2f, (float)(celly + 1) / 2f);
                            //GL.Vertex3((double)(cellx * 20 + index1 % 6 * 320), (double)(((celly + 1) * 20) + Math.Floor((double)index1 / 6.0) * 320.0) , (double)MFile.Blocks[blockPoint].MapCells[new Point(celly + 1, cellx)].Height);
                            GL.Vertex3(Nx3, ny3, (double)MFile.Blocks[blockPoint].MapCells[new Point(celly + 1, cellx)].Height);

                            GL.TexCoord2((float)(cellx + 1) / 2f, (float)(celly + 1) / 2f);
                            GL.Vertex3(Nx4, ny4, (double)MFile.Blocks[blockPoint].MapCells[new Point(celly + 1, cellx + 1)].Height);
                            //GL.Vertex3((double)((cellx + 1) * 20 + index1 % 6 * 320), (double)(((celly + 1) * 20) + Math.Floor((double)index1 / 6.0) * 320.0) , (double)MFile.Blocks[blockPoint].MapCells[new Point(celly + 1, cellx + 1)].Height);

                            GL.End();
                            GL.Disable(EnableCap.Texture2D);
                        }
                    }
                    index1++;
                }
            }
        }
    }
}

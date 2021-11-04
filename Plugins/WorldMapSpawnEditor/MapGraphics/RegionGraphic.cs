using System;
using System.Drawing;
using System.IO;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class RegionGraphic
    {
        /// <summary>
        /// X abscissa.
        /// </summary>
        internal byte X;

        /// <summary>
        /// z ordinate.
        /// </summary>
        internal byte Z;

        /// <summary>
        /// World Region Identifier
        /// </summary>
        internal short wRegionID;

        /// <summary>
        /// TexturePath is combined by  {X}x{Y}.ddj.
        /// </summary>
        private protected string TexturePath { get => $"{ClientDataStorage.Config.StaticConfig.ClientExtracted}\\Media\\minimap\\{X}x{Z}.JPG"; }

        /// <summary>
        /// Region texture from media/minimap.
        /// TODO: Change to bitmap to decrease usage.
        /// </summary>
        internal Image RegionLayer;

        internal RegionGraphic(short regionID)
        {
            wRegionID = regionID;

            if (wRegionID > 0)
            {
                string convertedRegionID = wRegionID.ToString("X");
                Z = Convert.ToByte(Convert.ToInt32(convertedRegionID.Substring(0, 2), 16));
                X = Convert.ToByte(Convert.ToInt32(convertedRegionID.Substring(2, 2), 16));

                #region temp use of pk2 file
               //if (!ClientDataStorage.Client.Media.DDJFiles.ContainsKey($"Media\\minimap\\{X}x{Z}.ddj"))
               //{
               //    if (ClientDataStorage.Client.Media.MediaPk2.GetByteArrayByDirectory($"Media\\minimap\\{X}x{Z}.ddj", out byte[] rawByteimage))
               //        ClientDataStorage.Client.Media.DDJFiles.Add($"Media\\minimap\\{X}x{Z}.png", new ClientDataStorage.Client.Files.DDJImage(rawByteimage));
               //}
               //RegionLayer = ClientDataStorage.Client.Media.DDJFiles[$"Media\\minimap\\{X}x{Z}.ddj"].BitmapImage;
                #endregion
                if (File.Exists(TexturePath))
                    RegionLayer = Image.FromFile(TexturePath);
            }
        }
    }
}
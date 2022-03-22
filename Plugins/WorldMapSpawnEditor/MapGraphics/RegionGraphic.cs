using System;
using System.Drawing;
using System.IO;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class RegionGraphic
    {

        internal WRegionID RegionID { get; set; }

      
        /// <summary>
        /// TexturePath is combined by  {X}x{Y}.ddj.
        /// </summary>
        private protected string TexturePath { get => $"{ClientDataStorage.Config.StaticConfig.ClientExtracted}\\Media\\minimap\\{RegionID.X}x{RegionID.Z}.JPG"; }

        /// <summary>
        /// Region texture from media/minimap.
        /// TODO: Change to bitmap to decrease usage.
        /// </summary>
        internal Image RegionLayer;//{ get => GetRegionLayer(); }

        internal RegionGraphic(short regionID)
        {
            RegionID = new WRegionID(regionID);
            if (RegionID.IsDungeon || regionID < 0)
            {

                //ushort test = unchecked((ushort) regionID);
                return;

            }

            RegionLayer = File.Exists(TexturePath) ? Image.FromFile(TexturePath) : null;

                #region temp use of pk2 file
            //if (!ClientDataStorage.Client.Media.DDJFiles.ContainsKey($"Media\\minimap\\{X}x{Z}.ddj"))
            //{
            //    if (ClientDataStorage.Client.Media.MediaPk2.GetByteArrayByDirectory($"Media\\minimap\\{X}x{Z}.ddj", out byte[] rawByteimage))
            //        ClientDataStorage.Client.Media.DDJFiles.Add($"Media\\minimap\\{X}x{Z}.png", new ClientDataStorage.Client.Files.DDJImage(rawByteimage));
            //}
            //RegionLayer = ClientDataStorage.Client.Media.DDJFiles[$"Media\\minimap\\{X}x{Z}.ddj"].BitmapImage;
            #endregion
            // if (File.Exists(TexturePath))
            //     RegionLayer = Image.FromFile(TexturePath);

        }

    }
}
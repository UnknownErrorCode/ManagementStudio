namespace WorldMapSpawnEditor.MapGraphics
{
    internal sealed class WorldMapPanelBase
    {
        /// <summary>
        /// Weather the Spawn Editor should be open on click.
        /// </summary>
        internal bool showEditorOnClick = false;

        internal bool showMonster = false;
        internal bool showMeshBlocks = false;
        internal bool showMeshCells = false;
        internal bool showNestGenRadius = false;
        internal bool showNestRadius = false;
        internal bool showNpc = false;
        internal bool showPlayer = false;
        internal bool showRegionDb = true;
        internal bool showRegionDBnoDDJ = false;
        internal bool showRegionsUnassigned = false;
        internal bool showTeleport = false;

        /// <summary>
        /// Indicates weather the tooltip should be shown or not.
        /// </summary>
        internal bool showToolTip = true;

        internal bool showUniqueMonster = false;

        /// <summary>
        /// Defines the Pixel Size Width and Heigth from a single Region.
        /// </summary>
        internal int PictureSize = 256;
    }
}
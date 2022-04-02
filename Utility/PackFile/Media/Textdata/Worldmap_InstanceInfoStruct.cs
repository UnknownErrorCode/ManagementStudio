namespace PackFile.Media.Textdata
{
    public struct Worldmap_InstanceInfoStruct
    {
        //CodeName	Name(Skip)	RegionLeft	RegionTop	RegionRight	RegionBottom	MapRegionX	MapRegionZ	MapPosX	MapPosY	MapPosZ
        public string CodeName { get; set; }
        public string Name { get; set; }
        public int RegionLeft { get; set; }
        public int RegionTop { get; set; }
        public int RegionRight { get; set; }
        public int RegionBottom { get; set; }
        public int MapRegionX { get; set; }
        public int MapRegionZ { get; set; }
        public int MapPosX { get; set; }
        public int MapPosY { get; set; }
        public int MapPosZ { get; set; }

        public Worldmap_InstanceInfoStruct(string[] data)
        {
            CodeName = data[0].ToString();
            Name = data[1].ToString();
            RegionLeft = int.Parse(data[2]);
            RegionTop = int.Parse(data[3]);
            RegionRight = int.Parse(data[4]);
            RegionBottom = int.Parse(data[5]);
            MapRegionX = int.Parse(data[6]);
            MapRegionZ = int.Parse(data[7]);
            MapPosX = int.Parse(data[8]);
            MapPosY = int.Parse(data[9]);
            MapPosZ = int.Parse(data[10]);

        }
    }
}

using System.Collections.Generic;

namespace ClientDataStorage.Client.Files
{
    public class MapObject
    {

        public int nameI;
        public float X;
        public float Y;
        public float Z;
        public float Theta;
        public int ID;
        public List<int> groups = new List<int>();
        public string Unknown1;
        public string Unknown2;
        public bool DistFade;
        public string materialPath;
        public string pathPrefix;
        public float[][,] Verts;
        public float[][,] UV;
        public int[][,] Faces;
        public string[] Tex;
        public int[] TexIDs;
        public int readingMesh;
        public float[] boundingBoxp1;
        public float[] boundingBoxp2;
        public float[] rotBoundingBoxp1;
        public float[] rotBoundingBoxp2;
    }
}
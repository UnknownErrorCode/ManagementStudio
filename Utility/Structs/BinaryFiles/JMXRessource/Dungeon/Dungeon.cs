using Structs.Pk2.BinaryFiles.JMXRessource;

namespace Structs.BinaryFiles.JMXRessource.Dungeon
{
    public class Dungeon
    {
        CObjectInfo GeneralInformation;

        WRegionID RegionID;

        //pointer collision
        DungeonCollisionBox CollisionBox0;
        DungeonCollisionBox CollisionBox1; // not used in CRTNavMeshDungeon
    }

    struct DungeonBlock
    {
        string Path;
        string Name;
        uint UnknownUInt0;
        SVector3 Position;
        float Yaw;
        float IsEntrance; // obsolete?
        DungeonCollisionBox CollisionBox0;
        uint UnknownUInt1;
        DungeonFog Fog;
    }

    struct DungeonFog
    {
        uint Color;
        float NearPlane;
        float FarPlane;
        float Intensity;
        byte hasHeightFog;
        /* if(block.FogParam.hasHeightFog)  */        // == 0x01
        DungeonFogHeight HeightFog;
    }
    public struct DungeonFogHeight
    {
        float unkFloat0;
        float unkFloat1;
        float unkFloat2;
        float unkFloat3;
    }


    public struct DungeonCollisionBox
    {
        public Point32 Width;
        public Point32 Higth;
        public Point32 Length;

    }
}

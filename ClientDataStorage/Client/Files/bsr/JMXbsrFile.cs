using System.Collections.Generic;

namespace ClientDataStorage.Client.Files.bsr
{
    public class JMXbsrFile
    {
        #region Fields

        /// <summary>
        /// Number of Animation Groups.
        /// </summary>
        private readonly uint aniGroupCnt;

        /// <summary>
        /// Animation Groups.
        /// </summary>
        private readonly List<CPrimAniGroup> AniGroupList;

        /// <summary>
        /// CPrimBranch
        /// </summary>
        private readonly string attachmentBone;

        /// <summary>
        /// CPrimBranch
        /// </summary>
        private readonly uint attachmentBoneLength;

        /// <summary>
        /// if has Skeleton CPrimBranch gets read.
        /// </summary>
        private readonly uint hasSkeleton;

        /// <summary>
        /// Number of Mesh Groups.
        /// </summary>
        private readonly uint meshGroupCnt;

        /// <summary>
        /// Mesh Groups.
        /// </summary>
        private readonly List<CPrimMeshGroup> MeshGroupList;

        /// <summary>
        /// Number of ModelSets.
        /// </summary>
        private readonly uint modSetCnt;

        /// <summary>
        /// Model Data Sets.
        /// </summary>
        private readonly List<CModDataSet> ModSetDataSetList;

        /// <summary>
        /// CPrimBranch
        /// </summary>
        private readonly string skeletonPath;

        /// <summary>
        /// CPrimBranch
        /// </summary>
        private readonly uint skeletonPathLength;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Number of Animations inside the bsr.
        /// </summary>
        public uint animationCnt { get; set; }

        public uint AnimationOffset { get; set; }

        /// <summary>
        /// 0, "User Define Animation Type을 사용 하였습니다."
        /// </summary>
        public uint animationTypeUserDefine { get; set; }

        /// <summary>
        ///  ANIMATION_TOOL_VERSION = 0x1000, "Animation Type의 Version이 다릅니다."
        /// </summary>
        public uint animationTypeVersion { get; set; }

        public float[] collisionBox0 { get; set; }

        //24
        public float[] collisionBox1 { get; set; }

        //if(requireCollisionMatrix<>0)
        public byte[] collisionMatrix { get; set; }

        public string collisionMesh { get; set; }

        public uint collisionMeshLength { get; set; }

        public uint CollisionOffset { get; set; }

        /// <summary>
        /// Animation names.
        /// </summary>
        public List<string> CPrimAnimation { get; set; } = new List<string>();

        /// <summary>
        /// General information about the bsr object.
        /// </summary>
        public ObjectGeneralInfo Generalinfo { get; set; }

        public uint Int0 { get; set; }

        public uint Int1 { get; set; }

        public uint Int2 { get; set; }

        public uint Int3 { get; set; }

        public uint Int4 { get; set; }

        public uint MaterialOffset { get; set; }

        /// <summary>
        /// Material Sets of bsr file.
        /// </summary>
        public List<CPrimMaterialSet> MaterialSets { get; set; } = new List<CPrimMaterialSet>();

        /// <summary>
        /// CPrimMeshes inside the bsr file.
        /// </summary>
        public CPrimMesh[] MeshArray { get; set; }

        /// <summary>
        /// Number of Meshes contained in the bsr file.
        /// </summary>
        public uint meshCnt { get; set; }

        public uint MeshOffset { get; set; }

        public uint ModPaletteOffset { get; set; }

        /// <summary>
        /// MATERIALSET_MAXCOUNTMAX = 5.
        /// </summary>
        public uint mtrlSetCnt { get; set; }

        public uint PrimAniGroupOffset { get; set; }

        public uint PrimMeshGroupOffset { get; set; }

        //24
        public uint requireCollisionMatrix { get; set; }

        /// <summary>
        /// JMXVRES 0109
        /// </summary>
        public byte[] signature { get; set; }

        public uint SkeletonOffset { get; set; }

        /// <summary>
        /// reserved  40 length
        /// </summary>
        public byte[] unkBuffer0 { get; set; }

        #endregion Properties

        /*
         * TODO:

        //-> AniModSets
        4   uint    modSetCnt
        for (int i = 0; i < modSetCnt; i++)
        {
            //[see above...]
        }

        //CResAttachable : CResObject, IResObject;
        if(objInfo.Type == ObjectType.Character || objInfo.Type == ObjectType.Attachable)
        {
            4   uint    unkUInt0 //0 = CHAR, 1 = ITEM
            4   uint    unkUInt1 //see below
            4   uint    attachMethod //0 = BASE, 1 = REPLACE, 2 = ADD
            4   uint    slotCount
            for (int i = 0; i < slotCount; i++)
            {
                4   uint    slotId //see below
                4   uint    slotMeshIdx //PrimMeshIdx
            }

            //CResChar: CResAttachable, CResObject, IResObject;
            if(objInfo.Type == ObjectType.Character)
                4   uint    nComboNum               //0, "ASSERT(nComboNum == 0)"
        }

        //CResAttachable.unkUInt1:
        //-1 = NONE/Invalid? (for an arrow?!)
        //00 = _ha
        //01 = _ba (also for avatars?)
        //02 = _la
        //03 = _fa
        //04 = _sa
        //05 = _aa
        //06 = Left Hand (shield, bow)
        //07 = Right Hand (spear, tblade, blade, sword)
        //08 =
        //09 =
        //10 =
        //11 =
        //12 =
        //13 = char
        //14 =
        //15 =
        //16 = attach

        //CResAttachable.SlotId:
        //00 = Hair
        //01 = Face
        //02 = torso_upper
        //03 = torso_lower
        //04 = ??? (override in avatars but never set?)
        //05 = arm_upper
        //06 = arm_lower
        //07 = Left hand (Shield, Bow, Dagger, ...)
        //08 =
        //09 = Right hand (Blade, TBlade, Crossbow, Axe, ...)
        //10 = Spear
        //11 = pelvis
        //12 = thigh
        //13 = calf
        //14 = attach/cape (on the back)?

         */
    }
}
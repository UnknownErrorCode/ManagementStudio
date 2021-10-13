using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Client.Files.bsr
{
    public class JMXbsrFile
    {

        /// <summary>
        /// JMXVRES 0109
        /// </summary>
        public byte[] signature { get; set; }


        #region Header
        public uint MaterialOffset { get; set; }
        public uint MeshOffset { get; set; }
        public uint SkeletonOffset { get; set; }
        public uint AnimationOffset { get; set; }
        public uint PrimMeshGroupOffset { get; set; }
        public uint PrimAniGroupOffset { get; set; }
        public uint ModPaletteOffset { get; set; }
        public uint CollisionOffset { get; set; }

        public uint Int0 { get; set; }
        public uint Int1 { get; set; }
        public uint Int2 { get; set; }
        public uint Int3 { get; set; }
        public uint Int4 { get; set; }

        #endregion

        public ObjectGeneralInfo Generalinfo { get; set; }

        public byte[] unkBuffer0 { get; set; }                    //reserved  40 length


        #region CollisionOffset

        public uint collisionMeshLength { get; set; }
        public string collisionMesh { get; set; }
        public float[] collisionBox0 { get; set; }  //24
        public float[] collisionBox1 { get; set; }  //24
        public uint requireCollisionMatrix { get; set; }

        //if(requireCollisionMatrix<>0)
        public byte[] collisionMatrix { get; set; }

        #endregion

        #region MaterialOffset

        /// <summary>
        /// MATERIALSET_MAXCOUNTMAX = 5.
        /// </summary>
        public uint mtrlSetCnt { get; set; }
        public List<CPrimMaterialSet> MaterialSets { get; set; } = new List<CPrimMaterialSet>();

        #endregion

        #region MeshOffset
        public uint meshCnt { get; set; }
        public CPrimMesh[] MeshArray { get; set; }

        #endregion

        #region AnimationOffset

        /// <summary>
        ///  ANIMATION_TOOL_VERSION = 0x1000, "Animation Type의 Version이 다릅니다."
        /// </summary>
        public uint animationTypeVersion { get; set; }

        /// <summary>
        /// 0, "User Define Animation Type을 사용 하였습니다."
        /// </summary>
        public uint animationTypeUserDefine { get; set; }
        public uint animationCnt { get; set; }
        public List<string> CPrimAnimation { get; set; } = new List<string>();

        #endregion

        #region SkeletonOffset
        /// <summary>
        /// if has Skeleton CPrimBranch gets read.
        /// </summary>
        uint hasSkeleton;

        /// <summary>
        /// CPrimBranch
        /// </summary>
        uint skeletonPathLength;

        /// <summary>
        /// CPrimBranch
        /// </summary>
        string skeletonPath;

        /// <summary>
        /// CPrimBranch
        /// </summary>
        uint attachmentBoneLength;

        /// <summary>
        /// CPrimBranch
        /// </summary>
        string attachmentBone;
        #endregion

        #region PrimGroupOffset

        uint meshGroupCnt;
        List<CPrimMeshGroup> MeshGroupList;

        #endregion

        #region PrimAniGroupOffset

        uint aniGroupCnt;

        List<CPrimAniGroup> AniGroupList;
        #endregion

        #region ModPaletteOffset

        uint modSetCnt;
        List<CModDataSet> ModSetDataSetList;
        #endregion
    }
}




/*




//ModPaletteOffset (CModPalette)
//-> SystemModSets
4   uint    modSetCnt
for (int i = 0; i < modSetCnt; i++)
{
    //CModDataSet
    4   uint    modSet.Type                 // Locomotion = 0, Simple = 1, Ambient = 2,
    4   uint    modSet.AnimationType       // from PrimAnimationType
    4   uint    modSet.Name.Length
    *   string  modSet.Name
    
    4   uint    modSetDataCnt
    for (int i = 0; i < modSetCnt; i++)
    {
        4   uint    modDataType             // see ModDataType
        *   byte[]  modData                 // read ModData base on type...
    }
}

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
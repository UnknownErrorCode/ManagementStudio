﻿using PluginFramework.BasicControls;
using ShopEditor.Interface.ShopInterface;
using System.Data;
using System.Linq;

namespace ShopEditor.Interface
{
    internal class NpcShopData
    {
        #region Fields

        /// <summary>
        /// Name of NPC from _RefObjCommon
        /// </summary>
        internal readonly string NpcCodeName;

        /// <summary>
        /// Contains all RefShopGroups assigned to this NPC.
        /// </summary>
        internal readonly RefShopGroup[] ShopGroups;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Searches all Store Informations by a simpe NPC Name like NPC_TT_TEST
        /// _RefShopGroup > _RefMappingShopGroup >_RefMappingShopWithTab > _RefShopItemGroup +_RefShopTabGroup > _RefShopTab  > _RefShopGoods   >Edits can start
        /// </summary>
        /// <param name="npcCodeName128"></param>
        internal NpcShopData(string npcCodeName128)
        {
            NpcCodeName = npcCodeName128;

            if (!PluginFramework.Database.SRO_VT_SHARD._RefShopGroup.Any(group => group.RefNPCCodeName.Equals(npcCodeName128)))
            {
                vSroMessageBox.Show($"No Group CodeName128 found for NPC: {npcCodeName128}", "Error loading RefShopGroup");
                return;
            }
            Structs.Database.RefShopGroup[] shopGroups = PluginFramework.Database.SRO_VT_SHARD._RefShopGroup.Where(group => group.RefNPCCodeName.Equals(npcCodeName128)).ToArray();
            ShopGroups = new RefShopGroup[shopGroups.Length];

            for (int i = 0; i < ShopGroups.Length; i++)
            {
                ShopGroups[i] = new RefShopGroup(shopGroups[i].CodeName128);
            }
        }

        #endregion Constructors
    }
}
using ManagementFramework.Network.Security;
using Structs.Tool;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SkillEditor
{
    public partial class SkillEditorControl : UserControl
    {
        #region Fields

        private const PluginData PLUGINDATA = PluginData.SkillEditor;
        private const string STRING_DLL = "SkillEditor.dll";

        #endregion Fields

        #region Constructors

        public SkillEditorControl()
        {
            InitializeComponent();
            PluginFramework.ClientCore.AddEntry((ushort)PLUGINDATA, OnDataReceive);
            PluginFramework.Network.ClientPacketFormat.RequestPluginDataTables(STRING_DLL, (ushort)PLUGINDATA);
        }

        #endregion Constructors

        #region Methods

        private PacketHandlerResult OnDataReceive(ServerData arg1, Packet arg2)
        {
            return PacketHandlerResult.Block;
        }

        /// <summary>
        /// Takes action after click on a Monster. Opens the monster skill editor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMonsterClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewMonster.SelectedRows.Count > 0)
            {
                if (dataGridViewMonster.SelectedRows[0] != null)
                {
                    int commonID = (int)dataGridViewMonster.SelectedRows[0].Cells["ID"].Value;

                    if (PluginFramework.Database.SRO_VT_SHARD._RefObjCommon.ContainsKey(commonID))
                    {
                        Monster Monster = new Monster(commonID);
                        //TODO create skilleditor and redo monster class
                    }
                }
            }
        }

        /// <summary>
        /// After click on search button the datagridview will display the monsters containint the search text sequence.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchMonster(object sender, EventArgs e)
        {
            if (PluginFramework.Database.SRO_VT_SHARD.dbo.Tables["_RefObjCommon"].Rows.OfType<DataRow>().Any(row => row.Field<string>("CodeName128").ToLower().Contains(textBoxSearchMonster.Text.ToLower())))
            {
                dataGridViewMonster.DataSource = PluginFramework.Database.SRO_VT_SHARD.dbo.Tables["_RefObjCommon"].Rows.OfType<DataRow>().Where(row => row.Field<string>("CodeName128").ToLower().Contains(textBoxSearchMonster.Text.ToLower())).CopyToDataTable();
            }
            else { dataGridViewMonster.DataSource = null; }
        }

        private void vSroSmallButton1_vSroClickEvent()
        {
            //ClientFrameworkRes.Database.SRO_VT_SHARD.InitializeSkillEditor();
            buttonSearch.Enabled = true;
        }

        #endregion Methods
    }
}